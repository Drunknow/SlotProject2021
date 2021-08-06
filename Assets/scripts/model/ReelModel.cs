using UnityEngine;

namespace SlotProject
{

    public class ReelModel : MonoBehaviour
    {

        private SymbolTypeEnum[] symbols;

        [SerializeField] GameObject[] displayedSymbols;

        private bool isSpinning = false;

        public void SetSymbols(SymbolTypeEnum[] symbols)
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
        public void StartSpinning()
        {
            this.isSpinning = true;
        }

        // 回転停止
        public void StopSpinning()
        {
            this.isSpinning = false;
        }

        // 回転中か
        public bool GetIsSpinning()
        {
            return this.isSpinning;
        }

        // 図柄のspriteを画面上に反映させる
        public void publishSymbolSprite(Sprite sprite, DisplayedSymbolTypeEnum displayedSymbolType)
        {
            GameObject targetGameObject = this.displayedSymbols[(int)displayedSymbolType];
            SpriteRenderer spriteRenderer = targetGameObject.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
        }

    }

}
