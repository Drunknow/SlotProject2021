using System;
using UnityEngine;

namespace SlotProject
{

    public class ReelService : MonoBehaviour
    {

        [SerializeField] ReelFactory reelFactory;

        private SymbolFactory symbolFactory = new SymbolFactory();

        private ReelModel[] reels;

        public void Start()
        {
            // フレームレートを指定
            int frameRate = 3;
            Time.fixedDeltaTime = 1.0f / frameRate;

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
            this.StartSpinning(ReelTypeEnum.LEFT);
            this.StartSpinning(ReelTypeEnum.CENTER);
            this.StartSpinning(ReelTypeEnum.RIGHT);
        }

        // 特定のリールを回転させる
        private void StartSpinning(ReelTypeEnum reelType)
        {
            this.reels[(int)reelType].StartSpinning();
        }

        // 特定のリールを停止させる
        public void StopSpinning(ReelTypeEnum reelType)
        {
            Debug.Log($"{reelType}を停止します");
            this.reels[(int)reelType].StopSpinning();
        }

    }

}
