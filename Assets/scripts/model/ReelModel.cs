namespace SlotProject
{

    public class ReelModel
    {

        private SymbolEnum[] symbols;

        private bool isSpinning = false;

        public ReelModel()
        {
            // 図柄リストを定義
            this.symbols = new SymbolEnum[] {
                SymbolEnum.SEVEN,
                SymbolEnum.FULLHD,
                SymbolEnum.WATERMELON,
                SymbolEnum.BAR,
                SymbolEnum.REPLAY,
                SymbolEnum.CHERRY,
                SymbolEnum.SEVEN,
                SymbolEnum.FULLHD,
                SymbolEnum.WATERMELON,
                SymbolEnum.BAR,
                SymbolEnum.REPLAY,
                SymbolEnum.CHERRY,
           };
        }

        // 図柄一覧を取得
        public SymbolEnum[] getSymbols()
        {
            return this.symbols;
        }

        // 図柄の数を取得
        public int getLength()
        {
            return this.symbols.Length;
        }

        // 回転開始
        public void start() {
            this.isSpinning = true;
        }

        // 回転停止
        public void stop() {
            this.isSpinning = false;
        }

    }

}
