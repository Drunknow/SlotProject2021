using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotProject.TakiExample
{
    /// <summary>
    /// スロットが回り始めた瞬間に、どんなやくがそろいうるかを決定する奴
    /// </summary>
    public class SlotRoleDetaminer
    {

        /// <summary>
        /// どんな役が揃いうるかを決定してくれる場所です
        /// ここを確率的に指定したら好きにできる
        /// </summary>
        /// <returns></returns>
        public int[] DetaminAllSymbol()
        {
            return new int[] { Random.Range(0, 7), Random.Range(0, 7), Random.Range(0, 7) };
        }


    }
}