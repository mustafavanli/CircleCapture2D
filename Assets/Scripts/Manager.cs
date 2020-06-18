using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    [SerializeField]
    public GameObject Player;  

    [SerializeField]
    public GameObject Obstacle;

    [SerializeField]
    public GameObject Game_Panel;

    [SerializeField]
    TextMeshProUGUI skor_ENDMENU;

    [SerializeField]
    TextMeshProUGUI BestSkor_ENDMENU;
    [SerializeField]
    GameObject ENDMENU;


    [SerializeField]
    public Button Restart;

    public bool OyunBitti;
    void Start()
    {
        Restart.onClick.AddListener(Restart_Buttonlistener);
        int skor = Player.GetComponent<ColliderControl>().skor;
        int BestScor = PlayerPrefs.GetInt("skor");
        if (BestScor == null)
        {
            PlayerPrefs.SetInt("skor",skor);
            skor_ENDMENU.text = skor.ToString();
            BestSkor_ENDMENU.text = "NEW BEST";
        }
        else
        {
            BestSkor_ENDMENU.text = "BEST " + skor;
        }
    }
    void Restart_Buttonlistener()
    {
        StartCoroutine(YenidenAl());
    }

    IEnumerator YenidenAl()
    {
        Game_Panel.GetComponent<Image>().color = new Color32(0,175,218,255);
        ENDMENU.transform.DOLocalMoveY(-4500,1f);
        Game_Panel.transform.DOLocalMoveY(0, 1f);
       
        OyunBitti = false;
        Player.GetComponent<Image>().color = new Color32(255,255,255,255);
        Obstacle.GetComponent<Obstacle_Builder>().Start();
        Player.GetComponent<ColliderControl>().bekle = 1;
        Player.GetComponent<ColliderControl>().skor = 0;
        yield return new WaitForSeconds(0.5f);
        Player.SetActive(true);
        Player.GetComponent<ColliderControl>().skor_text.text = "";
        Player.GetComponent<ColliderControl>().skor_text.color = new Color32(255,255,255,255);
        // Obstacle.GetComponent<Obstacle_Builder>().olustur();
        Restart.gameObject.SetActive(false);
        int ses = PlayerPrefs.GetInt("ses");
        if (ses==2)
        {
            foreach (Transform item in GetComponent<Ses_Kontrol>().Sesler.transform)
            {
                item.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform item in GetComponent<Ses_Kontrol>().Sesler.transform)
            {
                item.gameObject.SetActive(false);
            }
        }
        Obstacle.transform.localPosition = new Vector2(1000,0);
    }

    // Player Öldüğü Zaman Burası Çalışıcak .
    public void oyunbitisi(TextMeshProUGUI Skor_TEXT)
    {
        int skor = Player.GetComponent<ColliderControl>().skor;
        StartCoroutine(OyunBitisi_ENUMERATOR());
        Skor_TEXT.DOColor(new Color32(255,255,255,0),0.55f);
        OyunBitti = true;
        int BestScor = PlayerPrefs.GetInt("skor");
        if (BestScor==null)
        {
            PlayerPrefs.SetInt("skor",skor);
            skor_ENDMENU.text = skor.ToString();
            BestSkor_ENDMENU.text = "NEW BEST";
            //
            StartCoroutine(BestSesiGecikmeli());
        }
        else
        {
            if (BestScor < skor)
            {
               PlayerPrefs.SetInt("skor", skor);

                skor_ENDMENU.text = skor.ToString();
                BestSkor_ENDMENU.text = "NEW BEST";
                //
                StartCoroutine(BestSesiGecikmeli());
                StartCoroutine(NewBest_Animation());
            }
            else
            {

                skor_ENDMENU.text = skor.ToString();
                BestSkor_ENDMENU.text = "BEST " + BestScor;
            }
        }
    }
    IEnumerator NewBest_Animation()
    {
        for (int i = 0; i < 8; i++)
        {
            BestSkor_ENDMENU.DOColor(new Color32(255,255,255,0),0.4f);
            yield return new WaitForSeconds(0.35f);
            BestSkor_ENDMENU.DOColor(new Color32(255, 255, 255, 255), 0.4f);
            yield return new WaitForSeconds(0.35f);
        }
    }

    IEnumerator BestSesiGecikmeli()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<Ses_Kontrol>().Best();
    }
    IEnumerator OyunBitisi_ENUMERATOR()
    {
        yield return new WaitForSeconds(0.9f);
        Game_Panel.transform.DOLocalMoveY(1200,0.7f);
        ENDMENU.transform.DOLocalMoveY(0, 0.7f);
        GetComponent<Ses_Kontrol>().SesleriKapat();
        yield return new WaitForSeconds(0.4f);
        Obstacle.transform.localPosition = new Vector2(900,0);
        ///
        foreach (Transform item in Obstacle.transform)
        {
            Obstacle.GetComponent<Obstacle_Builder>().Obstacks_LIST.Remove(item.gameObject);
            Destroy(item.gameObject);
        }
    }
}
