using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonController : MonoBehaviour
{
    [SerializeField] string PlayGameName;
    [SerializeField] string VisualizationName;
    [SerializeField] string PathFinderName;

    public void PlayGame()
    {
        SceneManager.LoadScene(PlayGameName);
    }

    public void VisualizeMazeGenerator()
    {
        SceneManager.LoadScene(VisualizationName);
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
