using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Main_Launcher : MonoBehaviour
{
    [SerializeField]
    GameObject sesler;
    [SerializeField]
    GameObject SoundON, SoundOFF, share;
    int ses;
    void Start()
    {

        Debug.Log("MAİN LAUNCHER");
        // 1 OFF , 2 ON [SOUNDS]
        ses = PlayerPrefs.GetInt("ses");
        if (ses==null || ses==0)
        {
            PlayerPrefs.SetInt("ses",2);
            ses = 2;
            SoundON.gameObject.SetActive(true);
            SoundOFF.gameObject.SetActive(false);
        }
        else if (ses==1)
        {
            foreach (Transform item in sesler.transform)
            {
                item.gameObject.SetActive(false);
            }
            SoundON_button();
        }
        else if (ses==2)
        {
            Debug.Log("AÇILDI SES .");
            foreach (Transform item in sesler.transform)
            {
                item.gameObject.SetActive(true);
            }
            SoundOFF_button();
        }

    }
   
    public void AppLink_star()
    {
        Application.OpenURL("market://details?id=" + Application.productName);
    }
    public void SoundON_button()
    {
        PlayerPrefs.SetInt("ses", 1);
        //
        SoundON.gameObject.SetActive(false);
        SoundOFF.gameObject.SetActive(true);
        Debug.Log("SOUNDON");
        //
    }
    public void SoundOFF_button()
    {
        PlayerPrefs.SetInt("ses", 2);
        //
        SoundON.gameObject.SetActive(true);
        SoundOFF.gameObject.SetActive(false);
        //
        Debug.Log("SOUNDOFF");
    }
   
    public void gecis_SHARE()
    {
        StartCoroutine(Share_button());
    }
    IEnumerator Share_button()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);

        new NativeShare().AddFile(filePath).SetSubject("Subject goes here").SetText("").Share();

        // Share on WhatsApp only, if installed (Android only)
        //if( NativeShare.TargetExists( "com.whatsapp" ) )
        //	new NativeShare().AddFile( filePath ).SetText( "Hello world!" ).SetTarget( "com.whatsapp" ).Share();

    }
}
