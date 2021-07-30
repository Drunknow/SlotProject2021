using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotPriject.TakiExample
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


        public void StopReel()
        {
            if(reelState == ReelState.Roll)
            {
                Debug.Log("リールを止めました。");
                reelState = ReelState.Stop;
            }
            else
            {
                Debug.Log("リールは止まっているはずです");

            }
        }

        public void StartReel()
        {
            if (reelState == ReelState.Roll)
            {
                Debug.Log("リールは既に回っています");
                reelState = ReelState.Stop;
            }
            else
            {
                Debug.Log("リールは回り始めた");

            }
        }
    }
}