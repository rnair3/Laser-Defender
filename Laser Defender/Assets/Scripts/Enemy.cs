using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stat")]
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 50;

    [Header("Enemy Audio")]
    float shootCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject laser;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] GameObject explosion;
    [SerializeField] float durationVFX = 1f;
    [SerializeField] AudioClip shoot;
    [SerializeField] AudioClip deathClip;


    private void Start()
    {
        ResetShootCounter();

    }

    private void ResetShootCounter()
    {
        shootCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
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
        AudioSource.PlayClipAtPoint(shoot, Camera.main.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        
        Destroy(gameObject);
        GameObject vfx = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(vfx, durationVFX);
        AudioSource.PlayClipAtPoint(deathClip, Camera.main.transform.position);
        FindObjectOfType<GameSession>().AddScore(scoreValue);
    }
}
