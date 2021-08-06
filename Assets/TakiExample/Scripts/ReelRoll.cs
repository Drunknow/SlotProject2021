using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelRoll : MonoBehaviour
{

    const float ROLL_ONE_FLAME = 0.1f;

    Transform TF;
    public bool isRolling;
    public bool isStopping;
    ReelZugara reelZugara;

    [SerializeField] int initialReelIndex;
    int reelIndexOffset;//何回分ずれたか

    [NonSerialized]public float topY;//スロットの天井となるy座標
    [NonSerialized] public float bottomY;//スロットの底となるy座標
    [NonSerialized] public int symbolCount;//いくつのシンボルをまとめて扱っているか


    [SerializeField] Sprite[] sprites;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        reelZugara = new ReelZugara();
        TF = GetComponent<Transform>();//キャッシュ(GetCOnponentはクソ思い)
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    /// <summary>
    /// 画像の位置を変えます。
    /// </summary>
    /// <returns>座標の繰り上がりが発生したかどうか</returns>
    public bool ScrollReel()
    {
        bool isIconReturn = false;
        //図柄のy座標を移動する
        float nextPositionY = TF.position.y - ROLL_ONE_FLAME;
        TF.position = new Vector3(TF.position.x, nextPositionY, TF.position.z);

        //思ったよりも下に行くようなら画像を変えて、一番上にもってく
        if (TF.position.y < bottomY)
        {
            reelIndexOffset = (reelIndexOffset + symbolCount) % reelZugara.reel.Length;
            int nextSymbolIndex = (reelIndexOffset + initialReelIndex) % reelZugara.reel.Length;
            spriteRenderer.sprite = sprites[reelZugara.reel[nextSymbolIndex]];

            TF.position = new Vector3(TF.position.x, topY, TF.position.z);

            isIconReturn = true;
        }

        return isIconReturn;
    }

    /// <summary>
    /// 図形をゲットする関数です
    /// </summary>
    public int GetZugara()
    {
        int symbolIndex = (reelIndexOffset + initialReelIndex) % reelZugara.reel.Length;
        return reelZugara.reel[symbolIndex];
    }


    public void StopMainRolling()
    {
        isStopping = true;
        isRolling = false;
    }

    public void StopAllIconRolling()
    {
        isStopping = false;
        isRolling = false;
    }

}
