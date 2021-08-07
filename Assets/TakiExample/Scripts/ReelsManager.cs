using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlotProject.TakiExample
{
    public class ReelsManager : MonoBehaviour
    {


        //神からイベントを受け取るのだ。
        //具体的には、全てのリールが止まった時に発火すべき関数。
        Action<int> allReelStopEvent;
        //一応プロパティ化
        public Action<int> AllReelStopEvent
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

        [SerializeField] GameObject[] Reels;//リールへの参照
        int stopedReelCount;//止まっているリールのカウント。


        /// <summary>
        /// 自身が参照している全てのリールを回す関数
        /// </summary>
        public void StartAllReel()
        {
            SlotRoleDetaminer slotRoleDetaminer = new SlotRoleDetaminer();
            int[] hitReelSymbols = slotRoleDetaminer.DetaminAllSymbol();
            for(int i = 0; i < Reels.Length; i++)
            {
                Reels[i].GetComponent<IReelStartable>().StartReel(hitReelSymbols[i]);
                Reels[i].GetComponent<IReelStartable>().SetStopEvent(StopOneReel);
            }
            stopedReelCount = 0;//全てのリールは回り始める
        }

        void StopOneReel()
        {
            //止まっている数を+1する
            stopedReelCount = stopedReelCount + 1;

            //もし、止まっているリールの数が参照の数といっしょなら、神から受け取ったイベントを発火する。
            if(stopedReelCount == Reels.Length)
            {

                //値段を判断する。
                SlotRoleJudgement slotRoleJudgement = new SlotRoleJudgement();//←これ最高のネーミングではないですか？
                //すべてのリールの情報を引数として、たなべ君(役を判定してくれる人)に渡す
                int getCoin = slotRoleJudgement.CheckSlotReel(GetCurrentZugara());

                /*デバッグ用
                int[][] debugindex= GetCurrentZugara();
                for(int i = 0; i < debugindex.Length; i++)
                {
                    for(int j = 0; j < debugindex[i].Length; j++)
                    {
                        Debug.Log(i + "番目のリールの" + j + "番目は" + debugindex[i][j]);
                    }
                }
                */

                //最後に受け取った関数を発火する。
                allReelStopEvent(getCoin);
            }
        }


        /// <summary>
        /// すべての図柄を取得して返す。
        /// 各リールごとに配列とし、
        /// 二次元配列で返す。
        /// </summary>
        /// <returns></returns>
        public int[][] GetCurrentZugara()
        {
            int[][] reals = new int[3][];
            reals[0] = new int[3];
            reals[1] = new int[3];
            reals[2] = new int[3];

            for(int i = 0; i < 3; i++)
            {
                reals[i] = Reels[i].GetComponent<Reel>().GetAllReel();           
            }

            return reals;
        }
        

    }
}