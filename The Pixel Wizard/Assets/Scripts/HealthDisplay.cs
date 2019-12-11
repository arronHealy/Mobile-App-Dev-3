using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

    TextMeshPro healthText;

    Player gamePlayer;

    // Use this for initialization
    void Start()
    {
        healthText = GetComponent<TextMeshPro>();
        gamePlayer = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = gamePlayer.GetHealth().ToString();
    }
}
