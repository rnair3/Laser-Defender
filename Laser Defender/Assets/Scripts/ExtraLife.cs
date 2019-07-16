using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "LaserShedder 2")
        {
            Destroy(gameObject);
        }
        else
        {
            int lives = collision.gameObject.GetComponent<Player>().GetLives();
            collision.gameObject.GetComponent<Player>().SetLives(lives + 1);
            Destroy(gameObject);
        }
        
    }

}
