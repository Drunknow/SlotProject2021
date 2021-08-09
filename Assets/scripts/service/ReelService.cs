using System;
using System.Collections.Generic;
using UnityEngine;

namespace SlotProject
{

    public class ReelService : MonoBehaviour
    {
        [SerializeField] RCCrump turnlight;


        [SerializeField] int frameRate;

        [SerializeField] ReelFactory reelFactory;

        private SymbolFactory symbolFactory = new SymbolFactory();

        private ReelModel[] reels;

        // 揃う図柄一覧（各リールの中央に揃う）
        private SymbolTypeEnum[] alignSymbols;

        // FIXME: サービスが状態保つのはNG
        private bool isPushedLastButton;

        //このフラグからボーナス当選するかもしれないっていうフラグ
        bool BONUSCHERRYFLG, BONUSSTRNGCHERRYFLG, RENAMEWATERMELONFLG;
        bool CHERRYFLG, STRNGCHERRYFLG, SEVENFLG;

        SlotLineCollection slotLineCollection = new SlotLineCollection();

        int slotLineIdentfier;

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

            // 揃う場所を決定
            UnityEngine.Random.InitState(System.DateTime.Now.Millisecond);
            slotLineIdentfier = (UnityEngine.Random.Range(0, 5));


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


            DisplayedSymbolTypeEnum displayedSymbol = slotLineCollection.slotLineCollection[slotLineIdentfier][(int)reelType];



            // FIXME: フレームレート下げるとワープしてるのがバレバレ
            // 揃う図柄が中央に来るまで待機
            while (this.reels[(int)reelType].GetCurrentSymbol(displayedSymbol) != this.alignSymbols[(int)reelType] )
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
            int bonus = 81;
            int bonusAfterWatermelon = 50;
            int bonusAfterCherry = 100;

            int regular = 56;
            int regularAfterWatermelon = 100;
            int regularAfterCherry = 100;

            int middleCharry = 25;

            int bell = 6553;
            int replay = 4553;
            int cherry = 5625;
            int watermeron = 2850;

            UnityEngine.Random.InitState( System.DateTime.Now.Millisecond );
            int judge = (UnityEngine.Random.Range(0, 65536));


            Debug.Log(judge);


            while (true)
            {
                turnlight.TurnOnRCCrump();
                
                if (BONUSSTRNGCHERRYFLG){
                    if(judge%2 == 0){
                        this.alignSymbols = new SymbolTypeEnum[]
                        {
                        SymbolTypeEnum.SEVEN,
                        SymbolTypeEnum.SEVEN,
                        SymbolTypeEnum.SEVEN,
                        };
                        SEVENFLG = true;
                    }
                    else {
                        this.alignSymbols = new SymbolTypeEnum[]
                        {
                        SymbolTypeEnum.FULLHD,
                        SymbolTypeEnum.FULLHD,
                        SymbolTypeEnum.FULLHD,
                        };
                    }
                    break;
                }
                if (judge < bonus)
                {
                    this.alignSymbols = new SymbolTypeEnum[]
                    {
                    SymbolTypeEnum.SEVEN,
                    SymbolTypeEnum.SEVEN,
                    SymbolTypeEnum.SEVEN,
                    };
                    SEVENFLG = true;
                    break;
                }

                judge -= bonus;

                if (judge < bonusAfterWatermelon && RENAMEWATERMELONFLG)
                {
                    this.alignSymbols = new SymbolTypeEnum[]
                    {
                    SymbolTypeEnum.SEVEN,
                    SymbolTypeEnum.SEVEN,
                    SymbolTypeEnum.SEVEN,
                    };
                    SEVENFLG = true;
                    break;
                }

                judge -= bonusAfterWatermelon;

                if (judge < bonusAfterCherry && BONUSCHERRYFLG)
                {
                    this.alignSymbols = new SymbolTypeEnum[]
                    {
                    SymbolTypeEnum.SEVEN,
                    SymbolTypeEnum.SEVEN,
                    SymbolTypeEnum.SEVEN,
                    };
                    SEVENFLG = true;
                    break;
                }
                judge -= bonusAfterCherry;

                if (judge < regular)
                {
                    this.alignSymbols = new SymbolTypeEnum[]
                    {
                    SymbolTypeEnum.SEVEN,
                    SymbolTypeEnum.SEVEN,
                    SymbolTypeEnum.BAR,
                    };
                    break;
                }
                judge -= regular;

                if (judge < regularAfterWatermelon && RENAMEWATERMELONFLG)
                {
                    this.alignSymbols = new SymbolTypeEnum[]
                    {
                    SymbolTypeEnum.SEVEN,
                    SymbolTypeEnum.SEVEN,
                    SymbolTypeEnum.BAR,
                    };
                    break;
                }

                judge -= regularAfterWatermelon;

                if (judge < regularAfterCherry && BONUSCHERRYFLG)
                {
                    this.alignSymbols = new SymbolTypeEnum[]
                    {
                    SymbolTypeEnum.SEVEN,
                    SymbolTypeEnum.SEVEN,
                    SymbolTypeEnum.BAR,
                    };
                    break;
                }

                judge -= regularAfterCherry;
                turnlight.TurnOffRCCrump();

                if (judge < middleCharry)
                {
                    this.alignSymbols = new SymbolTypeEnum[]
                    {
                    SymbolTypeEnum.REPLAY,
                    SymbolTypeEnum.CHERRY,
                    SymbolTypeEnum.REPLAY,
                    };
                    STRNGCHERRYFLG = true;
                    break;
                }

                judge -= middleCharry;



                if (judge < bell)
                {
                    this.alignSymbols = new SymbolTypeEnum[]
                    {
                    SymbolTypeEnum.BELL,
                    SymbolTypeEnum.BELL,
                    SymbolTypeEnum.BELL,
                    };
                    break;
                }

                judge -= bell;


                if (judge < replay)
                {
                    this.alignSymbols = new SymbolTypeEnum[]
                    {
                    SymbolTypeEnum.REPLAY,
                    SymbolTypeEnum.REPLAY,
                    SymbolTypeEnum.REPLAY,
                    };
                    break;
                }

                judge -= replay;



                if (judge < cherry)
                {
                    this.alignSymbols = new SymbolTypeEnum[]
                    {
                    SymbolTypeEnum.CHERRY,
                    //FIXME: 下のやつは止めた時の図柄とかにしてほしい．これで問題はないけど．
                    SymbolTypeEnum.CHERRY,
                    SymbolTypeEnum.CHERRY,
                    };
                    CHERRYFLG = true;
                    break;
                }

                judge -= cherry;


                if (judge < watermeron)
                {
                    this.alignSymbols = new SymbolTypeEnum[]
                    {
                    SymbolTypeEnum.WATERMELON,
                    SymbolTypeEnum.WATERMELON,
                    SymbolTypeEnum.WATERMELON,
                    };
                    break;
                }
                judge -= watermeron;




                //何物にもなれなかった者の末路
                this.alignSymbols = new SymbolTypeEnum[]
                {
                    SymbolTypeEnum.WATERMELON,
                    SymbolTypeEnum.REPLAY,
                    SymbolTypeEnum.REPLAY,
                };
                break;

            }

            RENAMEWATERMELONFLG = false;
            BONUSCHERRYFLG = false;
            BONUSSTRNGCHERRYFLG = false;

            Debug.Log(judge);

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

            //中段チェリーの出現を増やすために重複を許す．
            if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.CENTER) == SymbolTypeEnum.CHERRY
            )
            {
                obtainedSymbols.Add(this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.CENTER));
                BONUSSTRNGCHERRYFLG = true;
            }

            // 上段揃い
            if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP) == //
                this.reels[(int)ReelTypeEnum.CENTER].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP) && //
                this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP) == //
                this.reels[(int)ReelTypeEnum.RIGHT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP))
            {
                obtainedSymbols.Add(this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP));
                if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP) == SymbolTypeEnum.WATERMELON){
                    RENAMEWATERMELONFLG = true;
                }
                else if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER) == SymbolTypeEnum.CHERRY)
                    {
                       BONUSCHERRYFLG = true;
                    }
                 else if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP) == SymbolTypeEnum.CHERRY)
                    {
                      BONUSCHERRYFLG = true;
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
                    RENAMEWATERMELONFLG = true;
                }
                else if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER) == SymbolTypeEnum.CHERRY)
                    {
                        BONUSCHERRYFLG = true;
                    }
                 else if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP) == SymbolTypeEnum.CHERRY)
                    {
                       BONUSCHERRYFLG = true;
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
                    RENAMEWATERMELONFLG = true;
                }
                 else if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER) == SymbolTypeEnum.CHERRY)
                    {
                      BONUSCHERRYFLG = true;
                    }
                 else if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP) == SymbolTypeEnum.CHERRY)
                    {
                      BONUSCHERRYFLG = true;
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
                    RENAMEWATERMELONFLG = true;
                 }
                 else if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER) == SymbolTypeEnum.CHERRY)
                    {
                      BONUSCHERRYFLG = true;
                    }
                 else if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP) == SymbolTypeEnum.CHERRY)
                    {
                     BONUSCHERRYFLG = true;
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
                    RENAMEWATERMELONFLG = true;
                 }
                 else if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER) == SymbolTypeEnum.CHERRY)
                    {
                    BONUSCHERRYFLG = true;
                    }
                 else if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP) == SymbolTypeEnum.CHERRY)
                    {
                     BONUSCHERRYFLG = true;
                    }
                 
            }

            if (obtainedSymbols.Count >= 1){
                return obtainedSymbols;
            }

            //チェリーほんとはこの仕様が正しいけど重複が多すぎる
            /*if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER) == SymbolTypeEnum.CHERRY
            )
            {
                obtainedSymbols.Add(this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER));
                BONUSCHERRYFLG = true;
            }
            else if (this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP) == SymbolTypeEnum.CHERRY
            )
            {
                obtainedSymbols.Add(this.reels[(int)ReelTypeEnum.LEFT].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER));
                BONUSCHERRYFLG = true;
            }*/


            return obtainedSymbols;
        }


        //チェリーがチェリーもしくはボーナス図柄の時だけ揃うようにしたかった．
        /*bool CansetCherryAtLeftReel(ReelTypeEnum reelType){
            bool cansetCherryAtLeftReel;
            cansetCherryAtLeftReel = 
                this.reels[(int)reelType].GetCurrentSymbol(DisplayedSymbolTypeEnum.TOP) == SymbolTypeEnum.CHERRY ||
                this.reels[(int)reelType].GetCurrentSymbol(DisplayedSymbolTypeEnum.CENTER) == SymbolTypeEnum.CHERRY ||
                this.reels[(int)reelType].GetCurrentSymbol(DisplayedSymbolTypeEnum.UNDER) == SymbolTypeEnum.CHERRY || 
                !CHERRYFLG && !STRNGCHERRYFLG && !SEVENFLG;
                Debug.Log(cansetCherryAtLeftReel);
                return cansetCherryAtLeftReel;
            }*/

            
            

    }

}
