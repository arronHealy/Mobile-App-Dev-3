using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    /*
     * Music player uses singleton pattern so music plays across all levels 
     */

	// Use this for initialization
	void Awake () {
        // call class method
        SetUpSingleton();
	}

    private void SetUpSingleton()
    {
        // check if singleton instance already created
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
	
}
