using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] float shootCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTImeBetweenShots = 3f;
    [SerializeField] GameObject laser;
    [SerializeField] float projectileSpeed = 10f;


    private void Start()
    {
        ResetShootCounter();

    }

    private void ResetShootCounter()
    {
        shootCounter = Random.Range(minTimeBetweenShots, maxTImeBetweenShots);
    }

    private void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shootCounter -= Time.deltaTime;

        if(shootCounter <= 0f)
        {
            Fire();
            ResetShootCounter();
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(laser, new Vector2(transform.position.x, transform.position.y -0.5f), laser.transform.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
