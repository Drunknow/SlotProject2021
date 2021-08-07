using UnityEngine;

namespace SlotProject
{

    public class ReelModel : MonoBehaviour
    {

        private SymbolTypeEnum[] symbols;

        [SerializeField] GameObject[] displayedSymbols;

        private bool isSpinning = false;

        private int currentSymbolIndex = 0;

        public void SetSymbols(SymbolTypeEnum[] symbols)
        {
            this.symbols = symbols;

            // 初期位置を乱数で決める
            this.currentSymbolIndex = Random.Range(0, this.symbols.Length);
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
        public void StartSpinning()
        {
            this.isSpinning = true;
        }

        // 回転停止
        public void StopSpinning()
        {
            this.isSpinning = false;
        }

        // 回転中？
        public bool GetIsSpinning()
        {
            return this.isSpinning;
        }

        // 現在表示されている図柄を取得
        public SymbolTypeEnum GetCurrentSymbol(DisplayedSymbolTypeEnum displayedSymbolType)
        {
            int targetIndex = this.currentSymbolIndex + (int)displayedSymbolType - 1;
            return this.symbols[(targetIndex + this.GetLength()) % this.GetLength()];
        }

        // 1フレーム分回転させる
        public void SpinNextFrame()
        {
            this.currentSymbolIndex = ((this.currentSymbolIndex + this.GetLength()) - 1) % this.GetLength();
        }

        // 図柄のspriteを画面上に反映させる
        public void PublishSymbolSprite(Sprite sprite, DisplayedSymbolTypeEnum displayedSymbolType)
        {
            GameObject targetGameObject = this.displayedSymbols[(int)displayedSymbolType];
            SpriteRenderer spriteRenderer = targetGameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
        }

    }

}
