//====================Copyright statement:AppsTools===================//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MagicVFXPackage1Demo : MonoBehaviour
{
    string ss = "VFX_Black hole&VFX_Blue knife light 02&VFX_Cold knife light&VFX_tornado&VFX_3_smoke&VFX_Falling ice&VFX_Angle_glow&VFX_Knife Light Fire _001&VFX_Knife Light Fire _002&VFX_Knife Light Fire _003&VFX_Knife Light Fire _004&VFX_Arrow 001" +
        "&VFX_Arrow 002 Fire&VFX_Arrow 003 Fire" +
        "&VFX_Buff_Continue_Fire_001" +
        "&VFX_Continue_Magic_001&VFX_Divine shine" +
        "&VFX_Fire Magic Array 001&VFX_Fire Magic Array 002" +
        "&VFX_Fire Magic Array 003&VFX_Fire Magic Array 004&VFX_Fire hit 01" +
        "&VFX_Fire knife light Hit 001&VFX_Fire_0001&VFX_Fire_0002&VFX_Fire_ATK_001" +
        "&VFX_Fire_Hit_001&VFX_Fire_Hit_002&VFX_Fireball Crow&VFX_Flame&VFX_Footstep smoke" +
        "&VFX_Frost gushes&VFX_Gray layer&VFX_Hit_blood_001" +
        "" +
        "&VFX_Knife Light Fire _005&VFX_Knife light purple 007&VFX_Magic Array 002" +
        "&VFX_Magic Blue Hit 01&VFX_Magic Blue Hit 02&VFX_Magic Hit 002&VFX_Magic Lightning Hit" +
        "&VFX_Magic Purple Hit 07&VFX_Magic Red cast&VFX_Magic Red cast2&VFX_Magic ball&VFX_Magic blue cast" +
        "&VFX_Magic blue continuous casting&VFX_Magic blue lightning casting&VFX_Magic blue pillar" +
        "&VFX_Magic casting ball&VFX_Magic continuous lightning&VFX_Magic fire hits the ground" +
        "&VFX_Magic green continuous casting&VFX_Magic hit 005&VFX_Magic inhalation&VFX_Magic lightning 1" +
        "&VFX_Magic start&VFX_MagicFire&VFX_MagicSurge&VFX_Magical large-scale ice burst&VFX_Purple Double Knife" +
        "&VFX_Purple Double Knife2&VFX_Purple knife light 06&VFX_Purple knife light 1&VFX_Purple knife light 2" +
        "&VFX_Purple knife light 3&VFX_Purple knife light 4&VFX_Purple knife light 5&VFX_Purple knife light 6" +
        "&VFX_Purple knife light 7&VFX_Purple knife light 8&VFX_Purple knife light Hit 4&VFX_Purple knife light Hit 5" +
        "&VFX_Purple knife light hit 1&VFX_Purple knife light hit 2&VFX_Purple knife light hit 3&VFX_Resurrection" +
        "&VFX_Rotary knife&VFX_ShockWave&VFX_Spitfire&VFX_SurgingUnderground&VFX_The magic lasts _002&VFX_Whirlwind legs" +
        "&VFX__Magic fire hit&VFX__arrow&VFX__smoke 1&VFX_beam&VFX_disappear&VFX_dizziness 02&VFX_dizziness01" +
        "&VFX_hit_ gravel&VFX_hit_magic_001&VFX_hit_magic_002";
    private bool r = false;
    string[] allArray = null;

    public int i = 0;
    public UnityEngine.UI.Text tex;
    public Transform ts;
    private GameObject currObj;
    public Transform hideParent;

    public void Awake()
    {

        /*string st2322r = "";
        var allFiles = Directory.GetFiles(Application.dataPath + "/Magic VFX Package 1/Prefabs", "*.prefab", SearchOption.AllDirectories);
        for (int i = 0; i < allFiles.Length; i++)
        {
            var str = Application.dataPath + "/Magic VFX Package 1/Prefabs/";
            allFiles[i] = allFiles[i].Replace(@"\", "/").Replace(str.Replace(@"\", "/"), "").Replace(".prefab", "");
            st2322r += allFiles[i] + "&";

        }
        Debug.LogError(st2322r);
        return;*/


        allArray = ss.Split('&');
        currObj = GameObject.Instantiate(hideParent.transform.Find(allArray[i]).gameObject);
        currObj.transform.SetParent(ts);
        //currObj.transform.localPosition = Vector3.zero;
        tex.text = "Name: "+ i +" 【" + allArray[i] + "】";
    }

    public void Update()
    {
        if (ts != null && r)
        {
            ts.transform.Rotate(Vector3.up * Time.deltaTime * 90f);
        }
    }

    public void R()
    {
        r = true;
    }

    public void NotR()
    {
        r = false;
    }

    public void RePlay() 
    {
        if (currObj != null)
        {
            currObj.SetActive(false);
            currObj.SetActive(true);
        }
    }

    public void CopyName() 
    {
        var s = allArray[i].ToLower().Replace(".prefab", "");
        s = s.Substring(s.IndexOf("/")+1);
        UnityEngine.GUIUtility.systemCopyBuffer = s;
    }

    public void OnLeftBtClick() 
    {
        i--;
        if (i <= 0)
        {
            i = allArray.Length - 1;
        }
        if (currObj != null)
        {
            GameObject.DestroyImmediate(currObj);
        }
        currObj = GameObject.Instantiate(hideParent.transform.Find(allArray[i]).gameObject);
        currObj.transform.SetParent(ts);
        //currObj.transform.localPosition = Vector3.zero;
        tex.text = "Name: " + i + " 【" + allArray[i] + "】";
    }

    public void OnRightBtClick()
    {
        i++;
        if (i >= allArray.Length)
        {
            i = 0;
        }
        if (currObj != null)
        {
            GameObject.DestroyImmediate(currObj);
        }
        currObj = GameObject.Instantiate(hideParent.transform.Find(allArray[i]).gameObject);
        currObj.transform.SetParent(ts);
        //currObj.transform.localPosition = Vector3.zero;
        tex.text = "Name: " + i + " 【" + allArray[i] + "】";
    }
}
