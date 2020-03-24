using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MonoBehaviour
{
    [SerializeField] string PlayGameName;
    [SerializeField] string PathFinderName;

    public void PlayGame()
    {
        SceneManager.LoadScene(PlayGameName);
    }

    public void PathFinder()
    {
        SceneManager.LoadScene(PathFinderName);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
