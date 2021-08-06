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
        }

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
                reelRolls[i].stopAllIconRolling = StopAllReelRolling;
            }
        }

        void FixedUpdate()
        {
            bool isEndRolling = false;
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
                StopAllReelRolling();
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
                reelStopEvent();//マネージャーから受け取ったイベントを発火
                reelState = ReelState.Stop;
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
        public void StartReel()
        {
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


        void StopAllReelRolling()
        {
            for (int i = 0; i < reelRolls.Length; i++)
            {
                reelRolls[i].StopAllIconRolling();
            }
        }

    }
}
