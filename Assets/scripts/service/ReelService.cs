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
            this.reels = new ReelModel[3] {
                reelFactory.create(ReelTypeEnum.LEFT),
                reelFactory.create(ReelTypeEnum.CENTER),
                reelFactory.create(ReelTypeEnum.RIGHT),
            };

            // 初期画面の図柄を表示
            foreach (ReelModel reel in this.reels)
            {
                SymbolTypeEnum[] displayedSymbols = reel.GetSymbols();
                reel.publishSymbolSprite(this.symbolFactory.create(displayedSymbols[0]), DisplayedSymbolTypeEnum.TOP);
                reel.publishSymbolSprite(this.symbolFactory.create(displayedSymbols[1]), DisplayedSymbolTypeEnum.CENTER);
                reel.publishSymbolSprite(this.symbolFactory.create(displayedSymbols[2]), DisplayedSymbolTypeEnum.UNDER);
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
