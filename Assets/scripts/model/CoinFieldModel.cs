using UnityEngine;
using UnityEngine.UI;

namespace SlotProject
{

    public class CoinFieldModel : MonoBehaviour
    {

        private int coins = 0;

        public void Start()
        {
            this.PublishCoins();
        }

        // 現在のコイン枚数を取得
        public int GetCoins()
        {
            return this.coins;
        }

        // コイン枚数を指定
        public void SetCoins(int coins)
        {
            this.coins = coins;
            if (this.coins < 0)
            {
                this.coins = 0;
            }

            this.PublishCoins();
        }

        // コイン枚数を加算
        public void AddCoins(int coins)
        {
            this.coins += coins;
            if (this.coins < 0)
            {
                this.coins = 0;
            }

            this.PublishCoins();
        }

        // コインが空か？
        public bool IsEmpty()
        {
            return this.coins == 0;
        }

        // 画面にコイン枚数を表示
        private void PublishCoins()
        {
            this.GetComponent<Text>().text = this.coins.ToString();
        }

    }

}
