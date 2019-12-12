using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour {

    [SerializeField] float scrollSpeed = 0.1f;

    Material material;

    Vector2 offSet;

    /*
     * Background scroller script associated with Quad game object
     * This script implements scroll functionality for Game over and Win Scenes in game
     */

	// Use this for initialization
	void Start () {
        // get the game object renderers material
        material = GetComponent<Renderer>().material;
        // set new vector 2 value
        offSet = new Vector2(scrollSpeed, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        // offset and begin scroll of background image on the x axis
        material.mainTextureOffset += offSet * Time.deltaTime;
		
	}
}
