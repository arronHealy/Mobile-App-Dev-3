using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    float delayInSeconds = 2f;

    public void LoadNextScene()
    {
        // get scene index val from build settings and load next scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        // load start scene
        SceneManager.LoadScene(0);
    }

    public void LoadSettingsScene()
    {
        //load settings scene
        SceneManager.LoadScene("Settings");
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void LoadNextLevel()
    {
        StartCoroutine(WaitAndLoadLevel());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);

        SceneManager.LoadScene("Game Over");
    }

    IEnumerator WaitAndLoadLevel()
    {
        yield return new WaitForSeconds(delayInSeconds);

        LoadNextScene();
    }

    public void QuitGame()
    {
        // exit application
        Application.Quit();
    }

}
