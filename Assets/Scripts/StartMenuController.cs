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
    public GameObject Camera;

    public void SetMazeActive()
    {
        int row = Int32.Parse(rowNum.text);
        int column = Int32.Parse(columnNum.text);

        MazeModel maze = Maze.GetComponent<MazeModel>();
        maze.row = row;
        maze.column = column;

        Vector3 cameraPosition = new Vector3(row / 2, (row + column) * 3 / 4, column / 2);
        Camera.transform.position = cameraPosition;

        StartMenu.SetActive(false);
        Maze.SetActive(true);
    }

}
