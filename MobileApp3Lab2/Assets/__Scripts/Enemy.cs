using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // use later for collision detection
    // and for adding scores for the player
    // may need a gameController object (next week)

    [SerializeField]
    private int scoreValue = 10;    // later

    // gets kicked off when transform gets hit by something
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // decide what hit me
        var bullet = collision.GetComponent<Bullet>();
        //var player = collision.GetComponent<PlayerMovement>();
        if(bullet)
        {
            // got hit by bullet, manage the objects and die
            // could play sound
            // destroy the bullet that hit me
            // destroy myself
            Destroy(bullet.gameObject);
            Destroy(gameObject);
        }
    }



}
