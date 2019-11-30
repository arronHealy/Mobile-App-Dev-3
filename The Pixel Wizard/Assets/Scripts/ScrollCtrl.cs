using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCtrl : MonoBehaviour {

    private float scrollSpeed = 0.1f;

    Material material;

    Vector2 offSet;

    // Use this for initialization
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    public void Stop()
    {
        offSet = new Vector2(0f, 0f);
    }

    public void Move(float pos)
    {
        offSet = new Vector2(scrollSpeed, 0f);

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
