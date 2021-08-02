using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotProject.TakiExample
{
    /// <summary>
    /// リールを止めるためだけに存在するボタン
    /// </summary>
    public class ReelStopButton : MonoBehaviour
    {
        [SerializeField] GameObject reel;


        /// <summary>
        /// 自身が参照するリールの、ストップ関数を呼び出し。
        /// </summary>
        public void StopReel()
        {
            //インタフェースからリールを止める奴をじっこう。
            reel.GetComponent<IReelStopable>().StopReel();
        }
    }
}