using UnityEngine;

namespace SlotProject
{

    public class CoinService : MonoBehaviour
    {

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
            this.creditField.AddCoins(-1);
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

        // クレジットが空か？
        public bool IsCreditEmpty()
        {
            return this.creditField.IsEmpty();
        }

    }

}
