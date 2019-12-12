using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

    TextMeshPro healthText;

    Player gamePlayer;

    /*
     * Health display class associated with text object in canvas
     * displays players health
     */

    // Use this for initialization
    void Start()
    {
        // get text component
        healthText = GetComponent<TextMeshPro>();
        // get player component
        gamePlayer = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        // update screen display depending on health value
        healthText.text = gamePlayer.GetHealth().ToString();
    }
}
