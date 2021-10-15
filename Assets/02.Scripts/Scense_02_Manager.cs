using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scense_02_Manager : MonoBehaviour
{
    // 오디오소스(재생파일)
    public AudioSource Play2_1;
    public AudioSource Play2_2;
    public AudioSource Play2_3;
    public AudioSource Play2_4;
    public AudioSource Play2_5;
    public AudioSource Play2_6;
    public AudioSource Play2_7;
    public AudioSource Play2_8;
    public AudioSource Play2_9;
    public AudioSource Play2_10;
    public AudioSource Play2_11;

    // 그랩 트리거 오브젝트
    public GameObject point01;
    public GameObject point02;
    public GameObject point03;
    public GameObject point04;
    public GameObject point05;
    public GameObject point06;
    public GameObject point07;
    public GameObject point08;

    // 콜라이더 놓을 포지션
    public GameObject collider02_1;
    public GameObject collider02_2;
    public GameObject collider02_3;
    public GameObject collider02_4;
    public GameObject collider02_5;
    public GameObject collider02_6;
    public GameObject collider02_7;
    public GameObject collider02_8;

    //각 콜라이더 트리거 에이블값
    bool colt01;
    bool colt02;
    bool colt03;
    bool colt04;
    bool colt05;
    bool colt06;
    bool colt07;
    bool colt08;
    bool colt09;

    //버튼 꾸러미
    public GameObject btSet;
    public GameObject btSetbt;

    //버튼 실행
    bool btGo = false;

    private int coroutioneCount01 = 0;
    private int coroutioneCountE01 = 0;

    private bool coroutioneEnd01 = false;
    private bool coroutioneStart02 = false;
    private int coroutioneCount02 = 0;
    private int coroutioneCountE02 = 0;

    private bool coroutioneEnd02 = false;
    private bool coroutioneStart03 = false;
    private int coroutioneCount03 = 0;
    private int coroutioneCountE03 = 0;

    private bool coroutioneEnd03 = false;
    private bool coroutioneStart04 = false;
    private int coroutioneCount04 = 0;
    private int coroutioneCountE04 = 0;

    private bool coroutioneEnd04 = false;
    private bool coroutioneStart05 = false;
    private int coroutioneCount05 = 0;
    private int coroutioneCountE05 = 0;

    private bool coroutioneEnd05 = false;
    private bool coroutioneStart06 = false;
    private int coroutioneCount06 = 0;
    private int coroutioneCountE06 = 0;

    private bool coroutioneEnd06 = false;
    private bool coroutioneStart07 = false;
    private int coroutioneCount07 = 0;
    private int coroutioneCountE07 = 0;

    private bool coroutioneEnd07 = false;
    private bool coroutioneStart08 = false;
    private int coroutioneCount08 = 0;
    private int coroutioneCountE08 = 0;

    private bool coroutioneEnd08 = false;
    private bool coroutioneStart09 = false;
    private int coroutioneCount09 = 0;
    private int coroutioneCountE09 = 0;

    private bool coroutioneEnd09 = false;
    private bool coroutioneStart10 = false;
    private int coroutioneCount10 = 0;

    private bool coroutioneEnd10 = false;
    private bool coroutioneStart11 = false;
    private int coroutioneCount11 = 0;



    private void Start()
    {
        StartCoroutine("SoundC1");

        


    }

    void Update()
    {
        // 트리거 에이블값 최신화
        colt01 = collider02_1.GetComponent<Collider02_1>().collider021;
        colt02 = collider02_2.GetComponent<Collider02_2>().collider022;
        colt03 = collider02_3.GetComponent<Collider02_3>().collider023;
        colt04 = collider02_4.GetComponent<Collider02_4>().collider024;
        colt05 = collider02_5.GetComponent<Collider02_5>().collider025;
        colt06 = collider02_6.GetComponent<Collider02_6>().collider026;
        colt07 = collider02_7.GetComponent<Collider02_7>().collider027;

        

        //사운드1 코루틴 중지(콜라이터, 트리거 생성)
        if (coroutioneEnd01 && coroutioneCountE01<1)
        {
            StopCoroutine("SoundC1");
            coroutioneStart02 = true;
            coroutioneCountE01++;
            collider02_1.SetActive(true);
            point01.SetActive(true);
        }

        //사운드2 코루틴 스타트
        if (coroutioneStart02  && colt01 && coroutioneCount02<1)
        {
            collider02_1.SetActive(false);
            point01.SetActive(false);
            StartCoroutine("SoundC2");
            coroutioneCount02++;
        }

        //사운드2 코루틴 중지(콜라이터, 트리거 생성)
        if (coroutioneEnd02 && coroutioneCountE02<1)
        {
            StopCoroutine("SoundC2");
            coroutioneStart03 = true;
            coroutioneCountE02++;
            collider02_2.SetActive(true);
            point02.SetActive(true);

        }

        //사운드3 코루틴 스타트
        if (coroutioneStart03 && colt02 && coroutioneCount03 < 1)
        {
            collider02_2.SetActive(false);
            point02.SetActive(false);
            StartCoroutine("SoundC3");
            coroutioneCount03++;
            
        }

        //사운드3 코루틴 중지(콜라이터, 트리거 생성)
        if (coroutioneEnd03 && coroutioneCountE03 < 1)
        {
            
            StopCoroutine("SoundC3");
            coroutioneStart04 = true;
            coroutioneCountE03++;
            collider02_3.SetActive(true);
            point03.SetActive(true);

        }


        //사운드4 코루틴 스타트
        if (coroutioneStart04 && colt03 && coroutioneCount04 < 1)
        {
            collider02_3.SetActive(false);
            point03.SetActive(false);
            StartCoroutine("SoundC4");
            coroutioneCount04++;
        }

        //사운드4 코루틴 중지(콜라이터, 트리거 생성)
        if (btGo && coroutioneCountE04 < 1)
        {
            btSetbt.SetActive(false);
            StopCoroutine("SoundC4");
            coroutioneStart05 = true;


        }


        //사운드6 코루틴 스타트
        if (coroutioneStart05 && coroutioneCount06 < 1)
        {
            
            StartCoroutine("SoundC6");
            coroutioneCount06++;
        }

        //사운드6 코루틴 중지(콜라이터, 트리거 생성)
        if (coroutioneEnd06 && coroutioneCountE06 < 1)
        {
            coroutioneCountE06++;
            StopCoroutine("SoundC6");
            coroutioneStart09 = true;
            collider02_5.SetActive(true);
            point05.SetActive(true);

        }



        //사운드9 코루틴 스타트
        if (coroutioneStart09 && colt05 && coroutioneCount05 < 1)
        {
            collider02_5.SetActive(false);
            point05.SetActive(false);
            StartCoroutine("SoundC9");
            coroutioneCount05++;

        }

        //사운드9 코루틴 중지(콜라이터, 트리거 생성)
        if (coroutioneEnd09 && coroutioneCountE09 < 1)
        {
            coroutioneCountE09++;
            StopCoroutine("SoundC9");
            coroutioneStart11 = true;
            collider02_6.SetActive(true);
            point06.SetActive(true);

        }

        //사운드11 코루틴 스타트
        if (coroutioneStart11 && colt06 && coroutioneCount06 < 1)
        {
            coroutioneCount06++;
            collider02_6.SetActive(false);
            point06.SetActive(false);
            StartCoroutine("SoundC11");
        }
    }

    public void ButtonGo()
    {
        Debug.Log("버튼 눌렸다");
        btGo = true;
    }

    

    IEnumerator SoundC1()
    {
        yield return new WaitForSeconds(4f);
        Debug.Log("SoundC1 시작");
        Play2_1.Play();
        yield return new WaitForSeconds(15f);
        Debug.Log("SoundC1 끝남");
        coroutioneEnd01 = true;
    }

    IEnumerator SoundC2()
    {
        //자이제 삼촌도 편하게 공부할 수 있을거야
        Debug.Log("SoundC2 시작");
        Play2_2.Play();
        yield return new WaitForSeconds(13f);
        Debug.Log("SoundC2 끝남");
        coroutioneEnd02 = true;
    }

    IEnumerator SoundC3()
    {
        Debug.Log("SoundC3 시작");
        Play2_3.Play();
        yield return new WaitForSeconds(8f);
        Debug.Log("SoundC3 끝남");
        coroutioneEnd03 = true;
    }

    IEnumerator SoundC4()
    {
        Debug.Log("SoundC4 시작");
        Play2_4.Play();
        yield return new WaitForSeconds(13f);
        Debug.Log("SoundC4 끝남");
        coroutioneEnd04 = true;

        Debug.Log("SoundC5 시작");
        Play2_5.Play();
        yield return new WaitForSeconds(10f);
        Debug.Log("SoundC5 끝남");

        btSet.SetActive(true);
        btSetbt.SetActive(false);
        yield return new WaitForSeconds(10f);
        btSetbt.SetActive(true);
    }
    IEnumerator Btcount()
    {
        
        yield return new WaitForSeconds(10f);
        btSetbt.SetActive(false);
        coroutioneEnd05 = true;
    }

    IEnumerator SoundC6()
    {
        Debug.Log("SoundC6 시작");
        Play2_6.Play();
        yield return new WaitForSeconds(3f);
        Debug.Log("SoundC6 끝남");
        

        Debug.Log("SoundC7 시작");
        Play2_7.Play();
        yield return new WaitForSeconds(11f);
        Debug.Log("SoundC7 끝남");

        Debug.Log("SoundC8 시작");
        Play2_8.Play();
        yield return new WaitForSeconds(2f);
        Debug.Log("SoundC8 끝남");
        coroutioneEnd06 = true;
    }
    IEnumerator SoundC9()
    {
        Debug.Log("SoundC9 시작");
        Play2_9.Play();
        yield return new WaitForSeconds(12f);
        Debug.Log("SoundC9 끝남");

        Debug.Log("SoundC10 시작");
        Play2_10.Play();
        yield return new WaitForSeconds(9f);
        Debug.Log("SoundC10 끝남");
        coroutioneEnd09 = true;
    }

    
    IEnumerator SoundC11()
    {
        Debug.Log("SoundC11 시작");
        Play2_11.Play();
        yield return new WaitForSeconds(4f);
        Debug.Log("SoundC11 끝남");
    }

   
}
