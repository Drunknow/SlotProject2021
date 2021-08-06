using System;
using System.Linq;
using UnityEngine;

namespace SlotProject.TakiExample
{
    /// <summary>
    /// 回転するリールを処理します。
    /// </summary>
    public class Reel : MonoBehaviour, IReelStopable, IReelStartable
    {
        enum ReelState
        {
            Stop,
            Roll,
            Slip,
        }

        int targetSymbol;//どのシンボルで止まることを定められているかを格納。-1でフリー

        ReelState reelState;
        ReelRoll[] reelRolls;//3つの表示されるやつら

        [SerializeField] float topY;//リールの一番上となる座標
        [SerializeField] float bottomY;//リールの底となる座標

        //リールマネージャーからイベントを受け取るのだ。
        //具体的には、リールを止めることに成功した際に発火すべき関数。
        Action reelStopEvent;





        void Start()
        {

            reelRolls = new ReelRoll[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                reelRolls[i] = transform.GetChild(i).GetComponent<ReelRoll>();
                reelRolls[i].topY = topY;
                reelRolls[i].bottomY = bottomY;
                reelRolls[i].symbolCount = reelRolls.Length;
            }
        }

        void FixedUpdate()
        {

            bool isEndRolling = false;

            if (reelState == ReelState.Roll || reelState == ReelState.Slip)
            {
                foreach (ReelRoll reelRoll in reelRolls)
                {
                    //図柄の場所をずらす
                    if (reelRoll.isRolling)
                    {
                        reelRoll.ScrollReel();
                    }
                    else if (reelRoll.isStopping)
                    {
                        isEndRolling = reelRoll.ScrollReel() || isEndRolling;
                    }
                }
                if (isEndRolling)
                {
                    //ここを書き換えたら、いい感じに指定の条件になるまで統べる……はず

                    if (GetAllReel()[2] == targetSymbol || targetSymbol == -1)
                    {
                        StopAllReelRolling();

                    }

                }
            }

        }




        /// <summary>
        /// 自身が参照しているリールを止める関数
        /// </summary>
        public void StopReel()
        {
            if (reelState == ReelState.Roll)
            {
                Debug.Log("リールを止めました。");
                reelState = ReelState.Slip;
                for (int i = 0; i < reelRolls.Length; i++)
                {
                    reelRolls[i].StopMainRolling();
                }
            }
            else
            {
                Debug.Log("リールは止まっているはずです");

            }
        }
        /// <summary>
        /// 自身が参照しているリールを回す関数
        /// </summary>
        public void StartReel(int target)
        {
            targetSymbol = target;
            if (reelState == ReelState.Roll)
            {
                Debug.Log("リールは既に回っています");
            }
            else
            {
                Debug.Log("リールは回り始めた");
                reelState = ReelState.Roll;
                for (int i = 0; i < reelRolls.Length; i++)
                {
                    reelRolls[i].isRolling = true;
                }
            }
        }


        public void SetStopEvent(Action action)
        {
            reelStopEvent = action;
        }



        /// <summary>
        /// リールの順番を高さの順に取る
        /// </summary>
        /// <returns></returns>
        public int[] GetAllReel()
        {

            int[] returnArray = new int[reelRolls.Length];
            reelRolls = reelRolls.OrderByDescending(a => a.transform.position.y).ToArray();
            for (int i = 0; i < reelRolls.Length; i++)
            {
                returnArray[i] = reelRolls[i].GetZugara();
                //Debug.Log(reelRolls[i].GetZugara());
            }
            return returnArray;
        }

        /// <summary>
        /// 完全にリールを止める
        /// </summary>
        void StopAllReelRolling()
        {
            reelStopEvent();//マネージャーから受け取ったイベントを発火
            reelState = ReelState.Stop;
            Debug.Log("リールは完全に止まった");
        }

    }
}
