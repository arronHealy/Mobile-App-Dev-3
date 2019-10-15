using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float moveSpeed = 2f;

    [SerializeField] float jumpSpeed = 10f;

    [SerializeField] float padding = 1f;

    [SerializeField] GameObject firePrefab;

    [SerializeField] float fireSpeed = 5f;

    [SerializeField] float firePeriod = 0.5f;

    Coroutine firingCoroutine;

    float xMin, xMax;

    // Use this for initialization
    void Start () {
        SetUpMoveBoundaries();
	}

    // Update is called once per frame
    void Update () {

        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Jump();
        }

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Move();
        }
        
        Fire();
        
       
	}

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }

        if (Input.GetKeyUp(KeyCode.R))
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
            // Quarernion used for rotation that game object has
            GameObject fire = Instantiate(firePrefab, new Vector3(transform.position.x + 1, transform.position.y), Quaternion.identity) as GameObject;

            fire.GetComponent<Rigidbody2D>().velocity = new Vector2(fireSpeed, 0);

            yield return new WaitForSeconds(firePeriod);
        }
       
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x - padding;
    }

    private void Move()
    {
      
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        transform.position = new Vector2(newXPos, transform.position.y);

    }

    private void Jump()
    {
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * jumpSpeed;

        var newYPos = transform.position.y + deltaY;

        transform.position = new Vector2(transform.position.x, newYPos);

    }
}
