using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuckandgo : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Sprite[] DESIGN_IMAGES;
    public int releNumber;

    void Start()
    {

        SpriteRenderer fuckAverak = GetComponent<SpriteRenderer>();
        fuckAverak.sprite = DESIGN_IMAGES[releNumber];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
