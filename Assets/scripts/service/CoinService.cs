using UnityEngine;

namespace SlotProject
{

    public class CoinService : MonoBehaviour
    {

        private int creditAmount = 3;

        [SerializeField] CoinFieldModel creditField;

        [SerializeField] CoinFieldModel payoutField;

        public void Start()
        {
            // コインの初期枚数を指定
            this.PublishCredit(250);
            this.PublishPayout(0);
        }

        // クレジットを入れる
        public void InsertCredit()
        {
            this.AddCredit(-this.creditAmount);
            // ペイアウトをリセット
            this.PublishPayout(0);
        }

        // Creditに値を反映
        public void PublishCredit(int coins)
        {
            this.creditField.SetCoins(coins);
        }

        // Payoutに値を反映
        public void PublishPayout(int coins)
        {
            this.payoutField.SetCoins(coins);
            this.AddCredit(coins);
        }

        // Creditに加算
        public void AddCredit(int coins)
        {
            this.creditField.AddCoins(coins);
        }

        // クレジットを入れれるか？
        public bool canInsertCredit()
        {
            return this.creditField.GetCoins() >= this.creditAmount;
        }

        // ペイアウトを獲得
        public void GivePayout(SymbolTypeEnum? symbolType)
        {
            // FIXME: 各図柄のペイアウトを定義
            switch (symbolType)
            {
                case SymbolTypeEnum.SEVEN:
                    this.PublishPayout(350);
                    break;
                case SymbolTypeEnum.FULLHD:
                    this.PublishPayout(450);
                    break;
                case SymbolTypeEnum.WATERMELON:
                    this.PublishPayout(8);
                    break;
                case SymbolTypeEnum.BAR:
                    this.PublishPayout(0);
                    break;
                case SymbolTypeEnum.REPLAY:
                    this.AddCredit(this.creditAmount);
                    break;
                case SymbolTypeEnum.CHERRY:
                    this.PublishPayout(4);
                    break;
                case SymbolTypeEnum.BELL:
                    this.PublishPayout(15);
                    break;
                case SymbolTypeEnum.TRASH:
                    this.PublishPayout(0);
                    break;
                default:
                    break;
            }
        }

    }

}
