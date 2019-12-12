using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {

    [SerializeField] Transform player;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        // camera position fixed to player position
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);	
	}
}
