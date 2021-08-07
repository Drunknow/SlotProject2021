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
            int frameRate = 50;
            Time.fixedDeltaTime = 1.0f / frameRate;

            this.reels = new ReelModel[3] {
                reelFactory.create(ReelTypeEnum.LEFT),
                reelFactory.create(ReelTypeEnum.CENTER),
                reelFactory.create(ReelTypeEnum.RIGHT),
            };

            // 初期画面の図柄を表示
            foreach (ReelModel reel in this.reels)
            {
                foreach (DisplayedSymbolTypeEnum displayedSymbolType in Enum.GetValues(typeof(DisplayedSymbolTypeEnum)))
                {
                    reel.publishSymbolSprite(this.symbolFactory.create(reel.GetCurrentSymbol(displayedSymbolType)), displayedSymbolType);
                }
            }
        }

        public void FixedUpdate()
        {
            // 左リール
            // 中央リール
            // 右リール
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
