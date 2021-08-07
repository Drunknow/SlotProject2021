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
            this.PublishCredit(7);
            this.PublishPayout(0);
        }

        // クレジットを入れる
        public void InsertCredit()
        {
            this.creditField.AddCoins(-this.creditAmount);
        }

        // Creditフィールドに値を反映
        public void PublishCredit(int credit)
        {
            this.creditField.SetCoins(credit);
        }

        // Payoutフィールドに値を反映
        public void PublishPayout(int payout)
        {
            this.payoutField.SetCoins(payout);
        }

        // クレジットを入れれるか？
        public bool canInsertCredit()
        {
            return this.creditField.GetCoins() >= this.creditAmount;
        }

    }

}
