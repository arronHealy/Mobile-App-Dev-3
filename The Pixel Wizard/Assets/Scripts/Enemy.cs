using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float health = 100f;

    [SerializeField] int scoreValue = 20;

    [SerializeField] float shotCounter;

    [SerializeField] float minTimeBetweenShots = 0.5f;

    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] float projectileSpeed = 10f;

    [SerializeField] GameObject projectile;

    [SerializeField] GameObject deathVfx;

    [SerializeField] AudioClip deathSfx;

    [SerializeField] AudioClip shootSound;

    [SerializeField] [Range(0,1)] float soundVolume = 0.7f;

    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.7f;

    [SerializeField] float speed;

    private Rigidbody2D rb;

    private SpriteRenderer sr;

    // Use this for initialization
    void Start () {
        // time enemy shooting
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        //get enemy components
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        // enemy move and shoot per frame
        Move();
        CountDownAndShoot();
	}

    private void CountDownAndShoot()
    {
        // count between firing times
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0)
        {
            Fire();
            // reset counter
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    // enemy firing method
    private void Fire()
    {
        GameObject fire = Instantiate(
            projectile, 
            new Vector3(transform.position.x - 1, transform.position.y), 
            Quaternion.identity) as GameObject;

        fire.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();

        if (!damageDealer)
        {
            return;
        }

        ProcessHit(damageDealer);
    }

    // process enemy health
    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        // FindObjectOfType<GameSession>().AddToScore(scoreValue);

        if (health <= 0)
        {
            Die();
        }
    }

    // destroy enemy game object
    private void Die()
    {
        //FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVfx, transform.position, transform.rotation);
        Destroy(explosion, 1f);
        AudioSource.PlayClipAtPoint(deathSfx, Camera.main.transform.position, soundVolume);
    }

    // move enemy
    private void Move()
    {
        Vector2 temp = rb.velocity;
        temp.x = speed;
        rb.velocity = temp;
    }

}
