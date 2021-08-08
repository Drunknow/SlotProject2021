using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class RCCrump : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    

    [SerializeField]Sprite OffRump;
    [SerializeField]Sprite OnRump;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TurnOnRCCrump()
    {
        spriteRenderer.sprite = OnRump;
    } 

    public void TurnOffRCCrump()
    {
        spriteRenderer.sprite = OffRump;

    }
}
