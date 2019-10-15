using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] float moveSpeed = 2f;

    [SerializeField] float jumpSpeed = 10f;

    [SerializeField] float padding = 1f;

    float xMin, xMax;

    // Use this for initialization
    void Start () {
        SetUpMoveBoundaries();
	}

    // Update is called once per frame
    void Update () {
        Move();
        Jump();
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
        if (Input.GetKey("down"))
        {
            return;
        }
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * jumpSpeed;

        var newYPos = transform.position.y + deltaY;

        transform.position = new Vector2(transform.position.x, newYPos);

    }
}
