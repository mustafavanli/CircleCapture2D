using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    bool PlayerControl_Y;
    [SerializeField] 
    float PlayerSpeed; // Default SPEED : 400;

    public string id;
    [SerializeField]
    GameObject Manager; 
    void Start()
    {
        PlayerControl_Y = true;
        transform.localPosition = new Vector2(0,0);
       
    }
    // #043840 ENGEL KODU renk
    // Update is called once per frame
    // 
 
    void Update()
    {

        ////////////////////////////////////////
        ////////////////////////////////////////
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            Manager.GetComponent<Ses_Kontrol>().TopDokunma();
            PlayerControl_Y = !PlayerControl_Y;
        }
        ////////////////////////////////////////
        ////////////////////////////////////////
        

        ////////////////////////////////////////
        ////////////////////////////////////////
        if (PlayerControl_Y==true)
        {
            transform.localPosition += new Vector3(0, 1*PlayerSpeed*Time.deltaTime);
            if (transform.localPosition.y > 205) 
            { 
                Manager.GetComponent<Ses_Kontrol>().Bar();
                PlayerControl_Y = false;
            }
        }
        else
        {
            transform.localPosition -= new Vector3(0, 1 * PlayerSpeed * Time.deltaTime);
            if (transform.localPosition.y < -205)
            {
                Manager.GetComponent<Ses_Kontrol>().Bar();
                PlayerControl_Y = true;
            }
        }
        
    }
}
