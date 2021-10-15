using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scense_01_Manager : MonoBehaviour
{
    public GameObject PadeObj;

    public GameObject StartMap;
    public GameObject Scense01;


    private Animator PadeCtr;

    bool start01 = false;
    bool start02 = false;

    int count01 = 0;
    int count02 = 0;






    void Start()
    {
        PadeCtr = PadeObj.GetComponent<Animator>();

        StartMap.SetActive(true);
        Scense01.SetActive(false);
        
        StartCoroutine("GoGo1");

        
    }

    // Update is called once per frame
    void Update()
    {
        if (start01& count01 < 1)
        {
            count01++;
            StopCoroutine("GoGo1");
            
        }

        if (start02 & count02 <2)
        {
            count02++;
            SceneManager.LoadScene("cave scene 2");

        }
    }

    IEnumerator GoGo1()
    {

        
        Debug.Log("첫코루틴종료");
        yield return new WaitForSeconds(10f);
        PadeCtr.SetTrigger("FadeOut01");
        yield return new WaitForSeconds(1f);
        StartMap.SetActive(false);
        Scense01.SetActive(true);
        PadeCtr.SetTrigger("FadeIn01");

        start01 = true;
    }

    IEnumerator GoGo2()
    {
        yield return new WaitForSeconds(4f);

        start02 = true;
    }
}
