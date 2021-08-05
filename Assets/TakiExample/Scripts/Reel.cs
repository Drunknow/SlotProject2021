using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
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
        [SerializeField] ReelRoll[] reelRolls;//3つの表示されるやつら
        float realPos;//リールがどの程度回ったかを表す。

        //リールマネージャーからイベントを受け取るのだ。
        //具体的には、リールを止めることに成功した際に発火すべき関数。
        Action reelStopEvent;

        /// <summary>
        /// 自身が参照しているリールを止める関数
        /// </summary>
        public void StopReel()
        {
            if(reelState == ReelState.Roll)
            {
                Debug.Log("リールを止めました。");
                reelStopEvent();//マネージャーから受け取ったイベントを発火
                reelState = ReelState.Stop;
                for(int i = 0; i < reelRolls.Length; i++)
                {
                    reelRolls[i].isRolling = false;
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
            for(int i = 0; i < reelRolls.Length; i++)
            {
                returnArray[i] = reelRolls[i].GetZugara();
                //Debug.Log(reelRolls[i].GetZugara());
            }
            return returnArray;
        }


    }
}
