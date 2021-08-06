namespace SlotProject
{

    public class ReelModel
    {

        private SymbolTypeEnum[] symbols;

        private bool isSpinning = false;

        public ReelModel(SymbolTypeEnum[] symbols)
        {
            this.symbols = symbols;
        }

        // 図柄一覧を取得
        public SymbolTypeEnum[] GetSymbols()
        {
            return this.symbols;
        }

        // 図柄の数を取得
        public int GetLength()
        {
            return this.symbols.Length;
        }

        // 回転開始
        public void Start()
        {
            this.isSpinning = true;
        }

        // 回転停止
        public void Stop()
        {
            this.isSpinning = false;
        }

        // 回転中か
        public bool GetIsSpinning()
        {
            return this.isSpinning;
        }

    }

}
