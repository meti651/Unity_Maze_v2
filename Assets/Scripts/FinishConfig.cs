using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishConfig : MonoBehaviour
{
    public GameObject cell;
    public GameObject maze;

    void Start()
    {
        float wallLenght = cell.GetComponent<CellConstruct>().wallLenght;
        BoxCollider finishTrigger = this.GetComponent<BoxCollider>();
        finishTrigger.enabled = true;
        finishTrigger.isTrigger = true;
        finishTrigger.size = new Vector3(wallLenght, wallLenght, wallLenght);


        MazeModel mazeComponent = maze.GetComponent<MazeModel>();

        this.transform.position = new Vector3((mazeComponent.row - 1) * wallLenght, 0f, (mazeComponent.column - 1) * wallLenght);
    }
}
