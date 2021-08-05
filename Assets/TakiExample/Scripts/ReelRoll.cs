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

    [SerializeField] int initialRealIndex;
    [SerializeField] float pos;

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
        if (isRolling)
        {
            pos = (pos + ROLL_ONE_FLAME) % (reelZugara.real.Length * 2);
            float temp = TF.position.y;
            temp = ((temp - ROLL_ONE_FLAME - 1)+4) % 2f-1;//クソコード部分
            TF.position = new Vector3(TF.position.x, temp, TF.position.z);

            int tempIndex = (Mathf.FloorToInt(pos/2) + initialRealIndex) % reelZugara.real.Length;
            spriteRenderer.sprite = sprites[reelZugara.real[tempIndex]];

        }
        else
        {

        }
    }
}
