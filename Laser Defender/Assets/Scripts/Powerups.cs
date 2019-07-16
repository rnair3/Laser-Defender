using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    [SerializeField] GameObject life;
    [SerializeField] GameObject shield;
    [SerializeField] float projectileSpeed = 10f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject powerup = null;
        int random = Random.Range(1, 3000);
        switch (random)
        {
            case 99: powerup = life;
                break;
            case 2: powerup = shield;
                break;
        }

        float x = Random.Range(-5.6f, 5.6f);
        if (powerup != null)
        {
            GameObject g = Instantiate(powerup, new Vector2(x, transform.position.y), Quaternion.identity) as GameObject;
            g.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        }
        
    }
}