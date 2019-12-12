using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private float delayInSeconds = 2f;

    /*
     Scene Manager Class loads different game play scenes methods fairly descriptive not much commenting needed
         */

    public void LoadNextScene()
    {
        // get scene index val from build settings and load next scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        // Find game session object and reset the Singleton on new game
        FindObjectOfType<GameSession>().ResetGame();
        // load start scene
        SceneManager.LoadScene(0);
    }



    public void LoadLevelOne()
    {
        // Find amd load scene named Level 1
        SceneManager.LoadScene("Level 1");
    }


    // Load Game Over Scene
    public void LoadGameOver()
    {
        // starts coroutine to delay load speed
        StartCoroutine(WaitAndLoad());
    }


    // Load Next level method
    public void LoadNextLevel()
    {
        // delays load of next level
        StartCoroutine(WaitAndLoadLevel());
    }


    // Coroutine method
    IEnumerator WaitAndLoad()
    {
        // wait for seconds
        yield return new WaitForSeconds(delayInSeconds);

        // load game over scene
        SceneManager.LoadScene("Game Over");
    }

    // Coroutine method
    IEnumerator WaitAndLoadLevel()
    {
        // wait for seconds
        yield return new WaitForSeconds(delayInSeconds);

        // load next scene class method 
        LoadNextScene();
    }

    public void QuitGame()
    {
        // exit application
        Application.Quit();
    }

}
