using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCtrl : MonoBehaviour {

    private float scrollSpeed = 0.1f;

    Material material;

    Vector2 offSet;

    /*
     * Scroll control class associated with gameplay levels background quad
     * The background is fixed to camera position and scrolls as player moves through level
     */

    // Use this for initialization
    void Start()
    {
        // get game object material
        material = GetComponent<Renderer>().material;
    }

    public void Stop()
    {
        // stop scrolling background
        offSet = new Vector2(0f, 0f);
    }

    public void Move(float pos)
    {
        // set offset value
        offSet = new Vector2(scrollSpeed, 0f);

        // scroll forward/backward depending on player move direction
        if (pos > 0)
        {
            material.mainTextureOffset += offSet * Time.deltaTime;
        }
        else
        {
            material.mainTextureOffset -= offSet * Time.deltaTime;
        }
    }
}
