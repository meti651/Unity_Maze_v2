using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellConstruct : MonoBehaviour
{
    public GameObject wall;
    public GameObject floor;
    public float wallLenght;
    private float initialXPosition;
    private float initialZPosition;
    private float initialYPosition;

    // Start is called before the first frame update
    void Awake()
    {
        initialXPosition = this.transform.position.x;
        initialZPosition = this.transform.position.z;
        initialYPosition = this.transform.position.y;
        CreateWalls();
        CreateFloor();
    }


    private void CreateFloor()
    {
        Vector3 floorPosition = new Vector3(initialXPosition, initialYPosition - wallLenght / 2, initialZPosition);
        floor.transform.localScale = new Vector3(wallLenght, floor.transform.localScale.y, wallLenght);
        GameObject tempFloor = Instantiate(floor, floorPosition, Quaternion.identity);
        tempFloor.transform.parent = this.transform;
    }

    private void CreateWalls()
    {


        GameObject verticalWall, horizontalWall;
        for (int i = 0; i < 2; i++)
        {
            Vector3 verticalWallPosition = new Vector3(initialXPosition + (i * wallLenght) - wallLenght / 2, initialYPosition, initialZPosition);
            wall.transform.localScale = new Vector3(wallLenght / 10, wallLenght, wallLenght);
            verticalWall = Instantiate(wall, verticalWallPosition, Quaternion.identity);
            verticalWall.transform.parent = this.transform;
        }

        for (int i = 0; i < 2; i++)
        {
            Vector3 horizontalWallPosition = new Vector3(initialXPosition, 0.0f, initialZPosition + (i * wallLenght) - wallLenght / 2);
            horizontalWall = Instantiate(wall, horizontalWallPosition, Quaternion.Euler(0.0f, 90.0f, 0.0f));
            horizontalWall.transform.parent = this.transform;
        }
        AddWallsToCell();
    }

    private void AddWallsToCell()
    {
        GameObject cell = this.transform.gameObject;
        GameObject[] walls = new GameObject[4];

        int childrenCount = this.transform.childCount;

        for (int i = 0; i < childrenCount; i++)
        {
            walls[i] = this.transform.GetChild(i).gameObject;
        }

        CellModel cellModel = cell.GetComponent<CellModel>();

        cellModel.WestWall = walls[2];
        cellModel.EastWall = walls[3];
        cellModel.NorthWall = walls[0];
        cellModel.SouthWall = walls[1];

    }

}
