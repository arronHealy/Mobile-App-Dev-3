using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool gamePaused = false;

    [SerializeField] GameObject pauseMenu;

    [SerializeField] GameObject mobileUi;
	
	// Update is called once per frame
	void Update () {

        // check for pause button pressed
		if (Input.GetKeyDown(KeyCode.Space))
        {
            if(gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
	}

    public void Resume()
    {
        pauseMenu.SetActive(false);
        mobileUi.SetActive(true);
        // start game time
        Time.timeScale = 1f;
        gamePaused = false;
    }

    private void Pause()
    {
        mobileUi.SetActive(false);
        pauseMenu.SetActive(true);
        // stop game time
        Time.timeScale = 0f;
        gamePaused = true;
    }
}
