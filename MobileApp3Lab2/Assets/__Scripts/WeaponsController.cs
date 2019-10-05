using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

// spawn the bullets at the current position, 
// give them a velocity, point them up (Vector.Up)
// script is added to the player or anything else that
// fires red diamonds

public class WeaponsController : MonoBehaviour
{
    // == fields ==
    [SerializeField]
    private Bullet bulletPrefab;

    [SerializeField]
    private float bulletSpeed = 5f;

    [SerializeField]
    private float firingRate = 0.4f;

    private GameObject bulletParent;

        
    // Start is called before the first frame update
    void Start()
    {
        // get the bullet parent
        //bulletParent = GameObject.Find("BulletParent");
        //if (!bulletParent)
        //{
        //    bulletParent = new GameObject("BulletParent");
        //}
        //bulletParent = ParentUtils.GetParent(ParentUtils.BULLET_PARENT);
        bulletParent = ParentUtils.GetBulletParent();

    }

    // Update is called once per frame
    void Update()
    {
        // did the player hit the fire button
        if( Input.GetKeyDown(KeyCode.Space))
        {
            // start shooting using the InvokeRepeating again
            InvokeRepeating("Shoot", 0f, firingRate);
        }

        // check when they stop shooting
        if( Input.GetKeyUp(KeyCode.Space))
        {
            // stop shooting by using the CancelInvoke method
            CancelInvoke("Shoot");
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletParent.transform);
        //set position to player position (this transform)
        bullet.transform.position = transform.position;
        // to give it movement, need to add a RigidBody2D to the bullet prefab
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * bulletSpeed;
        // could play sound too
    }

}
