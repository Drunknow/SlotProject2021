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
        public void startSpinning(int id)
        {
            this.reels[id].start();
        }

        // リールを回転させる回転させる
        public void stopSpinning(int id)
        {
            this.reels[id].stop();
        }

    }

}
