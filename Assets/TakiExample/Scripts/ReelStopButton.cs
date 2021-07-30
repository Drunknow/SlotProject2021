using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotPriject.TakiExample
{
    /// <summary>
    /// リールを止めるためだけに存在するボタン
    /// </summary>
    public class ReelStopButton : MonoBehaviour
    {
        [SerializeField] GameObject reel;


        public void StopReel()
        {
            //インタフェースからリールを止める奴をじっこう。
            reel.GetComponent<IReelStopable>().StopReel();
        }
    }
}