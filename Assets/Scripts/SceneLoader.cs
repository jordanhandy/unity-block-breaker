using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // method to quit game
    public void QuitGame()
    {
        Application.Quit();
    }
    // loading the next Scene
    // get the current scene index, by building an index of all scenes
    // load the next scene
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }
    public void LoadStartScene()
    {
        // load the first scene of the game
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();

    }

}
