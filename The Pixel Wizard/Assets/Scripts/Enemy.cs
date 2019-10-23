using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float health = 100f;

    [SerializeField] float shotCounter;

    [SerializeField] float minTimeBetweenShots = 0.5f;

    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] float projectileSpeed = 10f;

    [SerializeField] GameObject projectile;

	// Use this for initialization
	void Start () {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
	}
	
	// Update is called once per frame
	void Update () {
        CountDownAndShoot();
	}

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject fire = Instantiate(
            projectile, 
            new Vector3(transform.position.x - 1, transform.position.y), 
            Quaternion.identity) as GameObject;

        fire.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed, 0);
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

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
