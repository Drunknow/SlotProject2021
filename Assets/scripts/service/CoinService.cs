using System.Collections.Generic;
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
        public void GivePayout(List<SymbolTypeEnum> symbols)
        {
            int totalPayout = 0;

            foreach (SymbolTypeEnum symbol in symbols)
            {
                switch (symbol)
                {
                    case SymbolTypeEnum.SEVEN:
                        totalPayout += 350;
                        break;
                    case SymbolTypeEnum.FULLHD:
                        totalPayout += 450;
                        break;
                    case SymbolTypeEnum.WATERMELON:
                        totalPayout += 8;
                        break;
                    case SymbolTypeEnum.BAR:
                        totalPayout += 0;
                        break;
                    case SymbolTypeEnum.REPLAY:
                        this.AddCredit(this.creditAmount);
                        break;
                    case SymbolTypeEnum.CHERRY:
                        totalPayout += 4;
                        break;
                    case SymbolTypeEnum.BELL:
                        totalPayout += 15;
                        break;
                    case SymbolTypeEnum.TRASH:
                        totalPayout += 0;
                        break;
                    default:
                        break;
                }
            }

            this.PublishPayout(totalPayout);
        }

    }

}
