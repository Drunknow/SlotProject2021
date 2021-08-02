using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelRoll : MonoBehaviour
{

    Transform TF;
    public bool isRolling;

    // Start is called before the first frame update
    void Start()
    {
        TF = GetComponent<Transform>();//キャッシュ(GetCOnponentはクソ思い)
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRolling)
        {
            float temp = TF.position.y;
            temp = ((temp - 0.1f-1)+4) % 2f-1;//クソコード部分
            TF.position = new Vector3(TF.position.x, temp, TF.position.z);
        }
        else
        {

        }
    }
}
