using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

    /*
     * Shredder script associated with shredder game objects
     * Shredder game objects used for memory management of sprites firing projectiles
     * Projectiles destroyed on collision
     */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
