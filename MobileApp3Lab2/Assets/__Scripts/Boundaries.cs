using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    // find the x,y bounds of the Main camera
    // want to use those to contain the player
    // Mathf.Clamp(thisValue, min, max)
    // == public properties ==
    public Camera mainCamera;

    // == private variables
    private Vector2 screenBounds;

    private float objectWidth;

    // Start is called before the first frame update
    void Start()
    {
        // define screen bounds
        screenBounds =
            mainCamera.ScreenToWorldPoint(new Vector3(Screen.width,
                                                      Screen.height,
                                                      mainCamera.transform.position.z));

        // get the object width
        //objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectWidth = gameObject.GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    // after the player moves, check that they are in still in bounds
    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        // add the objectWidth to the min, subtract from the max
        viewPos.x = Mathf.Clamp(viewPos.x, 
                                screenBounds.x * -1 + objectWidth, 
                                screenBounds.x - objectWidth);
        transform.position = viewPos;
    }
}
