using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotProject.TakiExample
{
    public class SlotStartLever : MonoBehaviour
    {

        //神からイベントを受け取るのだ。
        //具体的には、レバーが引かれたときに実行するかんすうが入る。
        Action slotStartEvent;

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