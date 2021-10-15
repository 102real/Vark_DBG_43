using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider02_2 : MonoBehaviour
{

    public bool collider022 = false;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Ontrig")
        {
            Debug.Log($"Trigger !");
            collider022 = true;
        }
        
    }

}
