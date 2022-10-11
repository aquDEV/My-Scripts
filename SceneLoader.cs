using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    //Loads a scene
  public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    //Quits the game
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is shutting down");
    }
}

