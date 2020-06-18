using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class İnVisibleDestroy : MonoBehaviour
{

    public Obstacle_Builder ObstacksBuilder;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ObstacksBuilder.Obstacks_LIST.Remove(collision.gameObject);
     
        Destroy(collision.gameObject);
    }

}
