using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ses_Kontrol : MonoBehaviour
{

    [SerializeField]
    public GameObject Sesler;
    [SerializeField]
    GameObject TopaDokunma_Sesi;
    [SerializeField]
    GameObject SkorAlma_Sesi;
    [SerializeField]
    GameObject Patlama_Sesi;
    [SerializeField]
    GameObject Bar_Sesi;
    [SerializeField]
    GameObject Best_Sesi;


    //////////////

    AudioSource TopaDokunma_SES, Skoralma_SES, Patlama_SES, Bar_SES, Best_SES;

    /////////////

    void Start()
    {
        TopaDokunma_SES = TopaDokunma_Sesi.GetComponent<AudioSource>();
        Skoralma_SES = SkorAlma_Sesi.GetComponent<AudioSource>();
        Patlama_SES = Patlama_Sesi.GetComponent<AudioSource>();
        Bar_SES = Bar_Sesi.GetComponent<AudioSource>();
        Best_SES = Best_Sesi.GetComponent<AudioSource>();
    }

    // SESLER
    #region
    public void SesleriKapat()
    {
        TopaDokunma_SES.gameObject.SetActive(false);
    }
    public void SesleriAc()
    {
        foreach (Transform item in Sesler.transform)
        {
            item.gameObject.SetActive(true);
        }
    }
    public void TopDokunma()
    {
       
        TopaDokunma_SES.Play();
    }
    public void Skoralma()
    {
        Skoralma_SES.Play();
    }
    public void Patlama()
    {
        Patlama_SES.Play();
    }
    public void Best()
    {
        Best_SES.Play();
    }
    public void Bar()
    {
        Bar_SES.Play();
    }
    #endregion // SESLER . // SESLER // SESLER
}
