using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float moveSpeed = 2f;

    [SerializeField] GameObject leftShredder;

    [SerializeField] float jumpSpeed = 15f;

    [SerializeField] float padding = 1f;

    [SerializeField] int health = 150;

    [SerializeField] GameObject firePrefab;

    [SerializeField] float fireSpeed = 10f;

    [SerializeField] float firePeriod = 0.5f;

    [SerializeField] GameObject deathVfx;

    [SerializeField] AudioClip deathSfx;

    [SerializeField] [Range(0, 1)] float soundVolume = 0.7f;

    [SerializeField] AudioClip shootSound;

    SpriteRenderer spriteRenderer;

    Rigidbody2D rigidbody;

    private bool leftPressed = false, rightPressed = false;

    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.7f;

    Coroutine firingCoroutine;

    bool xFlipped = false;

    float xMin, xMax;

    // Use this for initialization
    void Start () {
        //SetUpMoveBoundaries();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update () {

        float playerSpeed = Input.GetAxisRaw("Horizontal");

        playerSpeed *= 5;

        if (playerSpeed != 0)
        {
            FindObjectOfType<ScrollCtrl>().Move(playerSpeed);

            MoveHorizontal(playerSpeed);
        }
        else
        {
            StopMoving();
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Jump();
        }

        /*
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Move();
        }
        */
        
        if (leftPressed)
        {
            MoveHorizontal(-playerSpeed);
        }

        if (rightPressed)
        {
            MoveHorizontal(playerSpeed);
        }
        
        Fire();       
       
	}

    private void StopMoving()
    {
        rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
    }

    public void stopMoveAmimation()
    {
        FindObjectOfType<ScrollCtrl>().Stop();
    }

    public void MoveHorizontal(float speed)
    {
        rigidbody.velocity = new Vector2(speed, rigidbody.velocity.y);

        if(speed < 0)
        {
            spriteRenderer.flipX = true;
            xFlipped = true;
        }
        else if(speed > 0)
        {
            spriteRenderer.flipX = false;
            xFlipped = false;
        }
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
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVfx, transform.position, transform.rotation);
        Destroy(explosion, 1f);
        AudioSource.PlayClipAtPoint(deathSfx, Camera.main.transform.position, soundVolume);
        FindObjectOfType<SceneLoader>().LoadGameOver();
    }

    public void AddToHealth()
    {
        health += 20;
    }

    public int GetHealth()
    {
        return health;
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }


    // code commented out as bug in game if you fire both from key board and mouse coroutine starts endless firing 
    /*
    private void MouseClickFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopCoroutine(firingCoroutine);
        }
    }
    */

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject fire;

            if (xFlipped)
            {
                fire = Instantiate(firePrefab, new Vector3(transform.position.x - 1, transform.position.y), Quaternion.identity) as GameObject;
                fire.GetComponent<Rigidbody2D>().velocity = new Vector2(-fireSpeed, 0);
            }
            else
            {
                fire = Instantiate(firePrefab, new Vector3(transform.position.x + 1, transform.position.y), Quaternion.identity) as GameObject;
                fire.GetComponent<Rigidbody2D>().velocity = new Vector2(fireSpeed, 0);
            }
            // Quarernion used for rotation that game object has

            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            yield return new WaitForSeconds(firePeriod);
        }
       
    }

    public void MobileMoveLeft()
    {
        leftPressed = true;
    }

    public void MobileMoveRight()
    {
        rightPressed = true;
    }

    public void MobileMoveStop()
    {
        leftPressed = false;
        rightPressed = false;

        StopMoving();
    }

    public void MobileFire()
    {
        Fire();
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x - padding;
    }

    private void Move()
    {

        //var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        //var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        //transform.position = new Vector2(newXPos, transform.position.y);

    }

    private void Jump()
    {
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * jumpSpeed;

        var newYPos = transform.position.y + deltaY;

        transform.position = new Vector2(transform.position.x, newYPos);

    }
}
