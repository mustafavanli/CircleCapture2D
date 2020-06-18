using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColliderControl : MonoBehaviour
{
    [SerializeField]
    GameObject Patlama_Efekti;

    public Obstacle_Builder ObstacksBuilder;
    [SerializeField]
    GameObject Game_Manager;

    
    public int skor=0;
    public int bekle = 1;

    GameObject colorchange;
    [SerializeField]
    public TextMeshProUGUI skor_text;
    private void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Image>().color == GetComponent<Image>().color)
        {
            ObstacksBuilder.Obstacks_LIST.Remove(collision.gameObject);
            skor++;
            if (skor==10*bekle)
            {
                Game_Manager.GetComponent<Color_Change>().renkdegistir();
                bekle++;
            }
            skor_text.GetComponent<Animator>().SetTrigger("SkorAl");
            skor_text.text = skor.ToString() ;
            Destroy(collision.gameObject);
            Game_Manager.GetComponent<Ses_Kontrol>().Skoralma();
        }
        else
        {
            Game_Manager.GetComponent<Ses_Kontrol>().Patlama();
            Game_Manager.GetComponent<Manager>().Restart.gameObject.SetActive(true);
            GameObject efekt = Instantiate(Patlama_Efekti,transform.position,new Quaternion(0,0,0,0), transform.parent);
            efekt.GetComponent<ParticleSystem>().startColor = GetComponent<Image>().color;
            gameObject.SetActive(false);
            Destroy(efekt,1f);
            Game_Manager.GetComponent<Manager>().oyunbitisi(skor_text);
            Game_Manager.GetComponent<Manager>().OyunBitti = true;
            Game_Manager.GetComponent<Ses_Kontrol>().Patlama();
        }
    }
}
