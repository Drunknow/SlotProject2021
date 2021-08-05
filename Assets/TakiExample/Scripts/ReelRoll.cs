using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelRoll : MonoBehaviour
{

    const float DISTANT = 2f;
    const float ROLL_ONE_FLAME = 0.1f;

    Transform TF;
    public bool isRolling;
    ReelZugara reelZugara;

    [SerializeField] int initialReelIndex;
    [SerializeField] int indicateReelLocation;//これは、リールの図柄の為に利用しているものです。
    [SerializeField]int reelIndexOffset;//何回分ずれたか

    [SerializeField] float bottomY;//スロットの底となるy座標


    [SerializeField] Sprite[] sprites;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        reelZugara = new ReelZugara();
        TF = GetComponent<Transform>();//キャッシュ(GetCOnponentはクソ思い)
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //図柄の場所をずらす
        if (isRolling)
        {
            

            if(TF.position.y - ROLL_ONE_FLAME < bottomY)
            {
                reelIndexOffset = (reelIndexOffset + 3) % reelZugara.reel.Length;

                int nextSymbolIndex = (reelIndexOffset + initialReelIndex) % reelZugara.reel.Length;

                spriteRenderer.sprite = sprites[reelZugara.reel[nextSymbolIndex]];

            }
            //図柄のy座標を移動する
            float nextPositionY = ((TF.position.y - ROLL_ONE_FLAME - 1)+4) % DISTANT - 1;
            TF.position = new Vector3(TF.position.x, nextPositionY, TF.position.z);



        }
        else
        {
            
        }
    }

    /// <summary>
    /// 図形をゲットする関数です
    /// </summary>
    public int GetZugara()
    {
        int symbolIndex = (reelIndexOffset + initialReelIndex) % reelZugara.reel.Length;
        return reelZugara.reel[symbolIndex];
    }

}
