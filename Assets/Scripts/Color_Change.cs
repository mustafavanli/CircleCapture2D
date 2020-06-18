using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Color_Change : MonoBehaviour
{

    Color32[] player = new Color32[16] { new Color32(188, 232, 132, 255), new Color32(188, 232, 132, 255), new Color32(59, 255, 160, 255), new Color32(255, 231, 148, 255), new Color32(245, 162, 97, 255), new Color32(245, 162, 97, 255), new Color32(240, 34, 60, 255), new Color32(255, 112, 73, 255), new Color32(219, 68, 68, 255), new Color32(249, 238, 104, 255), new Color32(0, 173, 181, 255), new Color32(126, 189, 194, 255), new Color32(159, 39, 39, 255), new Color32(125, 125, 254, 255), new Color32(74, 160, 182, 255), new Color32(255, 228, 113, 255) };
    Color32[] arkaplan = new Color32[16] { new Color32(202, 72, 84, 255), new Color32(82, 81, 116, 255), new Color32(115, 58, 162, 255), new Color32(157, 129, 137, 255), new Color32(26, 99, 90, 255), new Color32(37, 70, 82, 255), new Color32(20, 21, 32, 255), new Color32(32, 20, 20, 255), new Color32(70, 116, 108, 255), new Color32(106, 44, 111, 255), new Color32(34, 42, 49, 255), new Color32(35, 31, 32, 255), new Color32(255, 102, 102, 255), new Color32(44, 45, 67, 255), new Color32(23, 105, 123, 255), new Color32(174, 77, 154, 255) };
    Color32[] engel = new Color32[16] { new Color32(137, 47, 55, 255), new Color32(51, 36, 54, 255), new Color32(97, 84, 177, 255), new Color32(56, 45, 48, 255), new Color32(18, 66, 60, 255), new Color32(18, 34, 40, 255), new Color32(43, 45, 65, 255), new Color32(65, 43, 43, 255), new Color32(115, 203, 188, 255), new Color32(184, 59, 94, 255), new Color32(57, 62, 70, 255), new Color32(187, 68, 48, 255), new Color32(255, 158, 158, 255), new Color32(22, 23, 45, 255), new Color32(247, 217, 146, 255), new Color32(129, 106, 236, 255) };
    public Color32 toprengi;
    public Color32 engelrengi;
    public void Start()
    {
        toprengi = new Color32(255, 255, 255, 255);
        engelrengi = new Color32(4, 56, 64, 255); 
    }
    public void renkdegistir()
    {
        int sayi = Random.Range(0,16); 
        toprengi = player[sayi];
        engelrengi = engel[sayi];
        GetComponent<Manager>().Player.GetComponent<Image>().color = player[sayi];
        foreach (Transform item in GetComponent<Manager>().Obstacle.transform)
        {
            if (item.CompareTag("Skor"))
            {
                item.GetComponent<Image>().color = player[sayi];
            }
            else
            {
                item.GetComponent<Image>().color = engel[sayi];
            }
        }
        GetComponent<Manager>().Game_Panel.GetComponent<Image>().color = arkaplan[sayi];
        toprengi = player[sayi];
        engelrengi = engel[sayi];
    }
}
