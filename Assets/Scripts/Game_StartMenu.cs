using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game_StartMenu : MonoBehaviour
{
    [SerializeField]
    GameObject Start_MENU;
    [SerializeField]
    GameObject Game_PANEL;
    [SerializeField]
    GameObject AppName_TEXT;
    [SerializeField]
    Button Play_IMAGE;
    [SerializeField]
    TextMeshProUGUI bilgi_yazi;
    [SerializeField]
    TextMeshProUGUI bilgi_yazi2;
    void Start()
    {
        bilgi_yazi2.gameObject.SetActive(false);
        bilgi_yazi.gameObject.SetActive(false);
        Play_IMAGE.onClick.AddListener(PlayImage_Click);
        AppName_TEXT.transform.DOLocalMoveY(-100,1f);
    
    }
    
    public void PlayImage_Click()
    {
        Start_MENU.transform.DOLocalMoveY(3000,1.2f);
        Game_PANEL.transform.DOLocalMoveY(0,1.5f);
        Game_PANEL.SetActive(true);
        StartCoroutine(Gizle());
    }
    IEnumerator Gizle()
    {
        yield return new WaitForSeconds(1);
        Start_MENU.SetActive(false);
        yield return new WaitForSeconds(0.7f);
        bilgi_yazi.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.2f);
        bilgi_yazi.DOColor(new Color32(255, 255, 255, 0), 1f);
        yield return new WaitForSeconds(1f);
        bilgi_yazi.gameObject.SetActive(false);
        bilgi_yazi2.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        bilgi_yazi2.DOColor(new Color32(255, 255, 255, 0), 1f);
        yield return new WaitForSeconds(1f);
        bilgi_yazi2.gameObject.SetActive(false);
    }
}
