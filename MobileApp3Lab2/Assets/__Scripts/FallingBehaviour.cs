using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingBehaviour : MonoBehaviour
{
    // == private fields ==
    [SerializeField]
    private float speed = 2.0f;

    private Rigidbody2D rb; // rigid body component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.down * speed;
    }
    // Update is called once per frame
    //void Update()
    //{
    //    // don't use this for behaviour you want consistent across 
    //    // frames with physics
    //}
}
