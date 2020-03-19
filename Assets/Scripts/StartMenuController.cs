using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartMenuController : MonoBehaviour
{
    public GameObject Maze;
    public TextMeshProUGUI rowNum;
    public TextMeshProUGUI columnNum;
    public GameObject StartMenu;

    public void SetMazeActive()
    {
        int row = Int32.Parse(rowNum.text);
        int column = Int32.Parse(columnNum.text);

        MazeModel maze = Maze.GetComponent<MazeModel>();
        maze.row = row;
        maze.column = column;

        StartMenu.SetActive(false);
        Maze.SetActive(true);
    }

}
