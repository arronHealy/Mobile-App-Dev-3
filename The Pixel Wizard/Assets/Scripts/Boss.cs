using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    [SerializeField] float health = 100f;

    [SerializeField] int jumpDelay;

    [SerializeField] float shotCounter;

    [SerializeField] float minTimeBetweenShots = 0.5f;

    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] float projectileSpeed = 10f;

    [SerializeField] GameObject projectile;

    [SerializeField] GameObject deathVfx;

    [SerializeField] AudioClip deathSfx;

    [SerializeField] AudioClip shootSound;

    [SerializeField] [Range(0, 1)] float soundVolume = 0.7f;

    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.7f;


    // Use this for initialization
    void Start()
    {
        // set shot counter
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    // shoot counter called once per frame
    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0)
        {
            Fire();

            // reset shot counter
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    // boss firing method
    private void Fire()
    {
        GameObject fire = Instantiate(
            projectile,
            new Vector3(transform.position.x - 2, transform.position.y),
            Quaternion.identity) as GameObject;

        GameObject fire2 = Instantiate(
            projectile,
            new Vector3(transform.position.x - 2, transform.position.y - 1),
            Quaternion.identity) as GameObject;

        GameObject fire3 = Instantiate(
            projectile,
            new Vector3(transform.position.x - 2, transform.position.y + 1),
            Quaternion.identity) as GameObject;

        // move projectiles across screen
        fire.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0);
        fire2.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0);
        fire3.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0);

        // play shoot audio
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }

    // process projectile hit for boss
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();

        if (!damageDealer)
        {
            return;
        }

        ProcessHit(damageDealer);
    }

    // decrease health and check for death
    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();

        if (health <= 0)
        {
            Die();
        }
    }

    // Destroy boss game object
    private void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVfx, transform.position, transform.rotation);
        GameObject explosion2 = Instantiate(deathVfx, new Vector3(transform.position.x - 1, transform.position.y), transform.rotation);
        GameObject explosion3 = Instantiate(deathVfx, new Vector3(transform.position.x + 1, transform.position.y), transform.rotation);

        Destroy(explosion, 1f);
        Destroy(explosion2, 1f);
        Destroy(explosion3, 1f);

        // play death sound
        AudioSource.PlayClipAtPoint(deathSfx, Camera.main.transform.position, soundVolume);

        // load next scene method call
        FindObjectOfType<SceneLoader>().LoadNextLevel();
    }

}
