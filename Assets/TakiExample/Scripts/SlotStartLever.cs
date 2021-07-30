using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotPriject.TakiExample
{
    public class SlotStartLever : MonoBehaviour
    {
        Action slotStartEvent;//神からイベントを受け取るのだ。

        //一応プロパティ化
        public Action SlotStartEvent
        {
            get
            {
                return slotStartEvent;
            }
            set
            {
                slotStartEvent = value;
            }
        }

        /// <summary>
        /// Unityのボタンなどのイベントから呼び出すとき用
        /// </summary>
        public void UseLever()
        {
            slotStartEvent();//イベントを実行する。
        }

    }
}