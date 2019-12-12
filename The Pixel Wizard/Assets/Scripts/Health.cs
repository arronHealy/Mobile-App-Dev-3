using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    /*
     Health class associated with a health game object in levels.
     If player and this game object collide player method is called to increase players health
         */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Find and call player game objects method
        FindObjectOfType<Player>().AddToHealth();
        // destroy object
        Destroy(gameObject);
    }
}
