using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileUiCtrl : MonoBehaviour {

    [SerializeField] GameObject player;

    Player playerCtrl;

    /*
     * Mobile ui control class uses adapter pattern to invoke player object move methods
     * associated with mobile controller object
     * not working in game, couldn't fix before submission
     */

	// Use this for initialization
	void Start () {
        // get the player game object
        playerCtrl = player.GetComponent<Player>();
	}
	
    // call move & shoot methods of player
	public void MobileMoveLeft()
    {
        playerCtrl.MobileMoveLeft();
    }

    public void MobileMoveRight()
    {
        playerCtrl.MobileMoveRight();
    }

    public void MobileMoveStop()
    {
        playerCtrl.MobileMoveStop();
    }

    public void MobileFire()
    {
        playerCtrl.MobileFire();
    }
}
