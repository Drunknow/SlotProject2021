using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SlotProject.TakiExample
{
    /// <summary>
    /// スロットの状態を何でも管理しちゃう神クラス。
    /// 様々なクラスのインスタンスを実際に持ち、外部インスタンスからのメッセージと自身の状態に応じて、
    /// 様々な動作をする命令をする。
    /// なお、約束された神クラス。
    /// </summary>
    public class GameState : MonoBehaviour
    {

        int coin;//所持コインの数

        /// <summary>
        /// スロットの当たる確率の状態
        /// </summary>
        enum ProbabilityState
        {
            Normal,//通常状態
            Fluctuation,//いわゆる確率変動状態
        }

        /// <summary>
        /// スロットの動作状態
        /// </summary>
        enum SlotActivityState
        {
            WaitForStart,//現在動いておらず、レバーからのスタート入力待ち
            Roll,//いずれかのリールが回っている状態
            Performance,//お金を払うなどの演出中
        }

        SlotRoleDetaminer slotRoleDeteminer;
        SlotRoleJudgement slotRoleJudgement;
        [SerializeField]SlotStartLever startLever;
        [SerializeField] ReelsManager reelsManager;//全てのリールを管理する者

        [SerializeField] Text coinText;


        ProbabilityState probabilityState;//今の確率状況
        SlotActivityState activityState;//今何の状態か


        private void Awake()
        {
            startLever.SlotStartEvent = SlotStartLever;//レバーが引かれた際のイベントを指定
            reelsManager.AllReelStopEvent = CheckReelWhenAllReelStoped;//全てのリールが止まった際のイベントを指定
        }



        /// <summary>
        /// レバーを引いてすろっとがスタートするときの関数。
        /// </summary>
        void SlotStartLever()
        {
            if (activityState == SlotActivityState.WaitForStart)
            {
                Debug.Log("スロットが回り始めました");
                reelsManager.StartAllReel();//全てのリールを回す
                activityState = SlotActivityState.Roll;//回り始めた状態に変更する
            }
            else
            {
                Debug.Log("今の状態が" + activityState.ToString() +"のため、回せません。");
            }
        }


        /// <summary>
        /// 全てのリールが止まった時に、発火されるべき関数
        /// </summary>
        void CheckReelWhenAllReelStoped(int coin)
        {
            activityState = SlotActivityState.WaitForStart;//とりあえず止まったことにする。
            ShowCoinCount(coin);
            Debug.Log("全てのリールが止まり、もう一回レバーを引けます");
        }


        /// <summary>
        /// コインの枚数をテキストに出力する
        /// </summary>
        /// <param name="coin"></param>
        void ShowCoinCount(int coin)
        {
            coinText.text = "Coin" + coin;
        }

    }
}