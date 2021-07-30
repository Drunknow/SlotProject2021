using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotPriject.TakiExample
{
    public class ReelsManager : MonoBehaviour
    {


        //神からイベントを受け取るのだ。
        //具体的には、全てのリールが止まった時に発火すべき関数。
        Action allReelStopEvent;

        //一応プロパティ化
        public Action AllReelStopEvent
        {
            get
            {
                return allReelStopEvent;
            }
            set
            {
                allReelStopEvent = value;
            }
        }

        [SerializeField] GameObject[] Reels;


        /// <summary>
        /// 自身が参照している全てのリールを回す関数
        /// </summary>
        public void StartAllReel()
        {            
            for(int i = 0; i < Reels.Length; i++)
            {
                Reels[i].GetComponent<IReelStartable>().StartReel();
            }
        }


        

    }
}