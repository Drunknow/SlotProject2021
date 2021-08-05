using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotProject.TakiExample
{
    /// <summary>
    /// 実際に値を見てどんな役がそろっているか確認する役目を持つ。
    /// ただ、具体的な役を返すとアレなので、何番目の数値が何でそろったかのみを返すと良さそう？
    /// </summary>
    public class SlotRoleJudgement
    {

        //手に入るこいん(デバッグ用)
        int[] coin = { 1, 10, 100, 1000, 10000, 100000, 1000000 };


        public int CheckSlotReel(int[][] reals)
        {
            
            int totalCoin =0;

            //連想配列的な発想で、めんどくさい処理をfor分に落とし込む。
            //実際はすべてのリールを管理するクラスを作って、あヴぇくんの言うようにforeachを用いると良さそうです。
            int[] reel1Index = {2};
            int[] reel2Index = {2};
            int[] reel3Index = {2};

            for(int i = 0; i < reel1Index.Length; i++)
            {
                if(reals[0][reel1Index[i]] == reals[1][reel2Index[i]] && reals[0][reel1Index[i]] == reals[2][reel3Index[i]])
                {
                    totalCoin += coin[reals[0][reel1Index[i]]];
                }
            }

            return totalCoin ;

        }

    }
}