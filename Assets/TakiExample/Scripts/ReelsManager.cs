using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotPriject.TakiExample
{
    public class ReelsManager : MonoBehaviour
    {



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