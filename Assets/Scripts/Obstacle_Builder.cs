using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle_Builder : MonoBehaviour
{
    // Start is called before the first frame update
    public Color32 SkorTopRengi, EngelRengi;
    [SerializeField]
    GameObject Obstacks;

    [SerializeField]
    GameObject SkorAlma_TOPU;

    [SerializeField]
    GameObject Game_MANAGER;

    public float EngelAraligi;
    float aralik = 0;
    int toplam_alan = 450;
    public int SpeedObstacks;
    bool RandomObstacks;
    float height;
    public int Obstacks_STACK;
    Transform oyuncu;
    Color32 toprengi;
    Color32 EngelRengii;
    int onceki = 0;
    int teksefer = 0;
   
    public void Start()
    {
        height = 100;
        onceki = 0;
        random();
        Game_MANAGER.GetComponent<Color_Change>().Start();
        oyuncu = Game_MANAGER.GetComponent<Manager>().Player.transform;
        aralik = 0;
    }
    void random()
    {
        int rant = Random.Range(0,2);
        if (rant==0)
        {
            RandomObstacks = true;
        }
        else if (rant==1)
        {

            RandomObstacks = false;
        }
        Debug.Log(rant);

    }
    
    public List<GameObject> Obstacks_LIST = new List<GameObject>();
  
    // Update is called once per frame
    void Update()
    {
        if (Game_MANAGER.GetComponent<Manager>().OyunBitti==false)
        {
            transform.localPosition -= new Vector3(SpeedObstacks*Time.deltaTime,0,0);
        
        }
        if (Obstacks_LIST.Count < 20 && Game_MANAGER.GetComponent<Manager>().OyunBitti == false) 
        {

            RandomObstacks = !RandomObstacks;

            if (RandomObstacks == true)
            {
                aralik += EngelAraligi;
                height = Random.Range(70, 280);
                float position = (((height - 100) / 10) * 5);
                // Debug.Log("Height :" + height + " Ekleme_Y : " + position);
                GameObject engel = Instantiate(Obstacks, transform);
                GameObject skoralmatop = Instantiate(SkorAlma_TOPU, transform);
                Obstacks_LIST.Add(engel);
                Obstacks_LIST.Add(skoralmatop);
                skoralmatop.GetComponent<RectTransform>().localPosition = new Vector3(aralik, (height / 2) - 50, 0);

                engel.transform.localPosition = new Vector3(aralik, -175 + position);
                skoralmatop.GetComponent<Image>().color = Game_MANAGER.GetComponent<Color_Change>().toprengi;
                engel.GetComponent<Image>().color = Game_MANAGER.GetComponent<Color_Change>().engelrengi;
                engel.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(50, height);
                engel.GetComponent<BoxCollider2D>().size = new Vector2(49, height);

            }
            else if (RandomObstacks == false)
            {
                aralik += EngelAraligi;
                teksefer++;
                float height2 = Random.Range(100, 400-height);
                float position = (((height2 - 100) / 10) * 5);
                // Debug.Log("Height :" + height2 + " Ekleme_Y : " + position);
                GameObject engel = Instantiate(Obstacks, transform);
                GameObject skoralmatop = Instantiate(SkorAlma_TOPU, transform);
                Obstacks_LIST.Add(engel);
                Obstacks_LIST.Add(skoralmatop);
                skoralmatop.GetComponent<Image>().color = Game_MANAGER.GetComponent<Color_Change>().toprengi;
                skoralmatop.GetComponent<RectTransform>().localPosition = new Vector3(aralik, (-height2 / 2) + 30, 0);
                engel.transform.localPosition = new Vector3(aralik, 175 - position);
                engel.GetComponent<Image>().color = Game_MANAGER.GetComponent<Color_Change>().engelrengi;
                engel.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(50, height2);
                engel.GetComponent<BoxCollider2D>().size = new Vector2(49, height2);
            }
        }
    }
}
