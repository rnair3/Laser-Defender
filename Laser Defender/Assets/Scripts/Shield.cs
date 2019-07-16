using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "LaserShedder 2")
        {
            Destroy(gameObject);
        }
        else
        {
            
            collision.gameObject.GetComponent<Player>().SetHealth(200);
            Destroy(gameObject);
        }
    }
}
