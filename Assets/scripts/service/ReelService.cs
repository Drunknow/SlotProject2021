using System;
using System.Collections.Generic;
using UnityEngine;

namespace SlotProject
{

    public class ReelService : MonoBehaviour
    {

        [SerializeField] int frameRate;

        [SerializeField] ReelFactory reelFactory;

        private SymbolFactory symbolFactory = new SymbolFactory();

        private ReelModel[] reels;

        // 揃う図柄一覧（各リールの中央に揃う）
        private SymbolTypeEnum[] alignSymbols;

        // FIXME: サービスが状態保つのはNG
        private bool isPushedLastButton;

        //このフラグからボーナス当選するかもしれないっていうフラグ
        int CHERRYFLG, STRNGCHERRYFLG, WATERMELONFLG;

        public void Start()
        {
            // フレームレート
            Time.fixedDeltaTime = 1.0f / this.frameRate;

            // リールオブジェクトを取得
            this.reels = new ReelModel[3] {
                reelFactory.create(ReelTypeEnum.LEFT),
                reelFactory.create(ReelTypeEnum.CENTER),
                reelFactory.create(ReelTypeEnum.RIGHT),
            };

            // 初期画面の図柄を表示
            this.publishAllDisplayedSymbols();
        }

        public void FixedUpdate()
        {
            // 1フレーム分回転させる
            foreach (ReelModel reel in this.reels)
            {
                // 回転中なら次の図柄へ移動
                if (reel.GetIsSpinning())
                {
                    reel.SpinNextFrame();
                }
            }
            this.publishAllDisplayedSymbols();
        }

        // リール図柄を画面に配置
        public void publishAllDisplayedSymbols()
        {
            foreach (ReelModel reel in this.reels)
            {
                reel.PublishSymbolSprite(this.symbolFactory.create(reel.GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP)), DisplayedSymbolTypeEnum.TOP);
                reel.PublishSymbolSprite(this.symbolFactory.create(reel.GetCurrentSymbol(DisplayedSymbolTypeEnum.CENTER)), DisplayedSymbolTypeEnum.CENTER);
                reel.PublishSymbolSprite(this.symbolFactory.create(reel.GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER)), DisplayedSymbolTypeEnum.UNDER);
            }
        }

        // 全てのリールを回転させる
        public void startAll()
        {
            // 揃う図柄を決定
            this.FixAlignSymbols();

            this.StartSpinning(ReelTypeEnum.LEFT);
            this.StartSpinning(ReelTypeEnum.CENTER);
            this.StartSpinning(ReelTypeEnum.RIGHT);

            this.isPushedLastButton = false;
        }

        // 特定のリールを回転させる
        private void StartSpinning(ReelTypeEnum reelType)
        {
            this.reels[(int)reelType].StartSpinning();
        }

        // 特定のリールを停止させる
        public void StopSpinning(ReelTypeEnum reelType)
        {
            if (this.IsAllReelStop())
            {
                return;
            }

            // FIXME: フレームレート下げるとワープしてるのがバレバレ
            // 揃う図柄が中央に来るまで待機
            while (this.reels[(int)reelType].GetCurrentSymbol(DisplayedSymbolTypeEnum.CENTER) != this.alignSymbols[(int)reelType])
            {
                this.reels[(int)reelType].SpinNextFrame();
            }

            this.reels[(int)reelType].StopSpinning();
            this.isPushedLastButton = this.IsAllReelStop();
        }

        // リールが全て停止しているか？
        public bool IsAllReelStop()
        {
            bool result = true;
            foreach (ReelModel reel in this.reels)
            {
                result = result && !reel.GetIsSpinning();
            }

            return result;
        }

        // 指定したリールが停止しているか？
        public bool IsReelStop(ReelTypeEnum reelType)
        {
            return !this.reels[(int)reelType].GetIsSpinning();
        }

        // 揃う図柄を決定する
        private void FixAlignSymbols()
        {
            UnityEngine.Random.InitState( System.DateTime.Now.Millisecond );
            int judge = (UnityEngine.Random.Range(0, 65536));
            Debug.Log(judge);

            if (WATERMELONFLG == 1){
                
            }

            else if (0<judge &&  judge < 6553)
                {
                this.alignSymbols = new SymbolTypeEnum[]
                {
                    SymbolTypeEnum.BELL,
                    SymbolTypeEnum.BELL,
                    SymbolTypeEnum.BELL,
                };               
            } 

            else if (judge <= 6553 && judge < 11106){
                this.alignSymbols = new SymbolTypeEnum[]
                {
                    SymbolTypeEnum.REPLAY,
                    SymbolTypeEnum.REPLAY,
                    SymbolTypeEnum.REPLAY,
                };      
            }
            
            else if (judge <= 11106 && judge < 16731){
                this.alignSymbols = new SymbolTypeEnum[]
                {
                    SymbolTypeEnum.BAR,
                    //FIXME: 下のやつは止めた時の図柄とかにしてほしい．これで問題はないけど．
                    SymbolTypeEnum.REPLAY,
                    SymbolTypeEnum.REPLAY,
                };      
            }
            
            else if (judge <= 11106 && judge < 13956){
                this.alignSymbols = new SymbolTypeEnum[]
                {
                    SymbolTypeEnum.WATERMELON,
                    SymbolTypeEnum.WATERMELON,
                    SymbolTypeEnum.WATERMELON,
                };      
            }

            else if (judge <= 13956 && judge < 13981){
                this.alignSymbols = new SymbolTypeEnum[]
                {
                    SymbolTypeEnum.CHERRY,
                    //FIXME: 下のやつは止めた時の図柄とかにしてほしい．これで問題はないけど．
                    SymbolTypeEnum.REPLAY,
                    SymbolTypeEnum.REPLAY,
                };      
            }


            else
                {
                    this.alignSymbols = new SymbolTypeEnum[]
                {
                    SymbolTypeEnum.REPLAY,
                    SymbolTypeEnum.BELL,
                    SymbolTypeEnum.BELL,
                };
            }
            
           
            // FIXME: 揃う図柄を確率から決める
           
        }

        // 揃っている図柄一覧を取得, (ついでにフラグ管理←怒られそう)
        public List<SymbolTypeEnum> GetObtainedSymbols()
        {
            List<SymbolTypeEnum> obtainedSymbols = new List<SymbolTypeEnum>();

            // 最後のボタンが押された時のみ図柄を判定する
            if (this.isPushedLastButton)
            {
                this.isPushedLastButton = false;
            }
            else
            {
                return obtainedSymbols;
            }

            // 上段揃い
            if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP) == //
                this.reels[(int)ReelTypeEnum.CENTER].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP) && //
                this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP) == //
                this.reels[(int)ReelTypeEnum.RIGHT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP))
            {
                obtainedSymbols.Add(this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP));
                if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP) == SymbolTypeEnum.WATERMELON){
                    WATERMELONFLG = 1;
                }
            }

            // 中央段揃い
            if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.CENTER) == //
                this.reels[(int)ReelTypeEnum.CENTER].GetCurrentSymbol(DisplayedSymbolTypeEnum.CENTER) && //
                this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.CENTER) == //
                this.reels[(int)ReelTypeEnum.RIGHT].GetCurrentSymbol(DisplayedSymbolTypeEnum.CENTER))
            {
                obtainedSymbols.Add(this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.CENTER));
                if(this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.CENTER) == SymbolTypeEnum.WATERMELON){
                    WATERMELONFLG = 1;
                }
            }

            // 下段揃い
            if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER) == //
                this.reels[(int)ReelTypeEnum.CENTER].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER) && //
                this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER) == //
                this.reels[(int)ReelTypeEnum.RIGHT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER))
            {
                obtainedSymbols.Add(this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER));
                if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER) == SymbolTypeEnum.WATERMELON){
                    WATERMELONFLG = 1;
                }
            }

            // 左斜め揃い（\）
            if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP) == //
                this.reels[(int)ReelTypeEnum.CENTER].GetCurrentSymbol(DisplayedSymbolTypeEnum.CENTER) && //
                this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP) == //
                this.reels[(int)ReelTypeEnum.RIGHT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER))
            {
                obtainedSymbols.Add(this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP));
                 if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP) == SymbolTypeEnum.WATERMELON){
                    WATERMELONFLG = 1;
                }
            }

            // 右斜め揃い（/）
            if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER) == //
                this.reels[(int)ReelTypeEnum.CENTER].GetCurrentSymbol(DisplayedSymbolTypeEnum.CENTER) && //
                this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER) == //
                this.reels[(int)ReelTypeEnum.RIGHT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP))
            {
                obtainedSymbols.Add(this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER));
                 if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER) == SymbolTypeEnum.WATERMELON){
                    WATERMELONFLG = 1;
                }
            }

            //チェリー
            if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER) == SymbolTypeEnum.CHERRY
            )
            {
                obtainedSymbols.Add(this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER));
                CHERRYFLG = 1;
            }
            else if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.CENTER) == SymbolTypeEnum.CHERRY
            )
            {
                obtainedSymbols.Add(this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.CENTER));
                STRNGCHERRYFLG = 1;
            }
            else if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP) == SymbolTypeEnum.CHERRY
            )
            {
                obtainedSymbols.Add(this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER));
                CHERRYFLG = 1;
            }


            return obtainedSymbols;
        }

    }

}
