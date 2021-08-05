namespace SlotProject
{

    public class ReelService
    {

        private ReelModel[] reels;

        public ReelService()
        {
            this.reels = new ReelModel[3] {
                new ReelModel(),
                new ReelModel(),
                new ReelModel(),
            };
        }

        // リールを回転させる
        public void StartSpinning(ReelType reelType)
        {
            this.reels[(int)reelType].Start();
        }

        // リールを回転させる
        public void StopSpinning(ReelType reelType)
        {
            this.reels[(int)reelType].Stop();
        }

    }

}
