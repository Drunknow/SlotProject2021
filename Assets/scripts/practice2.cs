using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class practice2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject RELEOBJECT;
    List<fuckandgo> RELES;

    void Start()
    {
        RELES = new List<fuckandgo>();
        for(int i = 0; i<21 ;i++){
            GameObject obj = Instantiate(RELEOBJECT);
            obj.transform.position = new Vector3(0,i,0);
            RELES.Add(obj.GetComponent<fuckandgo>());
            obj.GetComponent<fuckandgo>().releNumber = Random.Range(0,7);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
