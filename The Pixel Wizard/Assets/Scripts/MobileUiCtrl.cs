using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileUiCtrl : MonoBehaviour {

    [SerializeField] GameObject player;

    Player playerCtrl;

	// Use this for initialization
	void Start () {
        playerCtrl = player.GetComponent<Player>();
	}
	
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
