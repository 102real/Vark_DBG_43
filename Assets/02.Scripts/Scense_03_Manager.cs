using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scense_03_Manager : MonoBehaviour
{
    bool start01 = true;

    void Start()
    {
        StartCoroutine("SoundC3_1");

        


    }

    void Update()
    {
        
        
    }

    


    IEnumerator SoundC3_1()
    {
        yield return new WaitForSeconds(4f);
        
        Debug.Log("코루틴시작");
    }


   
}
