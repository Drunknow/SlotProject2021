using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotPriject.TakiExample
{
    public class ReelsManager : MonoBehaviour
    {



        [SerializeField] GameObject[] Reels;

        public void StartAllReel()
        {            
            for(int i = 0; i < Reels.Length; i++)
            {
                Reels[i].GetComponent<IReelStartable>().StartReel();
            }
        }
    }
}