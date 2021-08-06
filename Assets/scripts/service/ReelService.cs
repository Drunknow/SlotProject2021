using UnityEngine;

namespace SlotProject
{

    public class ReelService
    {

        private ReelModel[] reels;

        public ReelService()
        {
            ReelFactory reelFactory = new ReelFactory();
            this.reels = new ReelModel[3] {
                reelFactory.create(ReelTypeEnum.LEFT),
                reelFactory.create(ReelTypeEnum.CENTER),
                reelFactory.create(ReelTypeEnum.RIGHT),
            };
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
            this.reels[(int)reelType].Start();
        }

        // 特定のリールを回転させる
        public void StopSpinning(ReelTypeEnum reelType)
        {
            Debug.Log($"{reelType}を停止します");
            this.reels[(int)reelType].Stop();
        }

    }

}
