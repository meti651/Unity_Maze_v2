using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeModel : MonoBehaviour
{
    public GameObject cell;
    public int row;
    public int column;
    public GameObject[,] m_cells;
    public List<GameObject> Cells;
    public GameObject StartingCell;
    public GameObject FinishCell;
    public float wallLenght;

    public Material StartingCellFloor;
    public Material FinishCellFloor;


    // Start is called before the first frame update
    void Start()
    {
        CreateCells();
        InitializeSiblings();
        StartingCell = m_cells[0, 0];
        FinishCell = m_cells[row - 1, column - 1];
        FinishCell.GetComponent<CellModel>().IsFinish = true;
        ChangeFloorMaterial();
        //StartCoroutine("DepthFirstGenerator");
        DepthFirstGenerator();
    }

    private void ChangeFloorMaterial()
    {
        int startChildrenNum = StartingCell.transform.childCount;
        int finishChildrenNum = FinishCell.transform.childCount;

        GameObject startFloor = StartingCell.transform.GetChild(startChildrenNum - 1).gameObject;
        GameObject finishFloor = FinishCell.transform.GetChild(finishChildrenNum - 1).gameObject;

        startFloor.GetComponent<MeshRenderer>().material = StartingCellFloor;
        finishFloor.GetComponent<MeshRenderer>().material = FinishCellFloor;
    }

    void DepthFirstGenerator()
    {

        Stack<GameObject> cellsStack = new Stack<GameObject>();
        HashSet<GameObject> visitedCells = new HashSet<GameObject>();

        GameObject startingCell = this.GetRandomCell();
        cellsStack.Push(startingCell);
        visitedCells.Add(startingCell);

        while (cellsStack.Count > 0)
        {
            //Debug.Log("Generation");
            //Debug.Log(cellsStack.Count);
            GameObject currentCell = cellsStack.Peek();
            CellModel currentCellModel = currentCell.GetComponent<CellModel>();
            GameObject linkCell = currentCellModel.GetRandomUnvisitedSibling(visitedCells);

            if (linkCell == null)
            {
                cellsStack.Pop();
                continue;
            }

            visitedCells.Add(linkCell);
            cellsStack.Push(linkCell);
            currentCellModel.MakeLink(linkCell);
            //yield return new WaitForSeconds(1f);
        }
        //StopCoroutine("DepthFirstGenerator");
    }

    private void InitializeSiblings()
    {
        for (int xPos = 0; xPos < m_cells.GetLength(0); xPos++)
        {
            for (int yPos = 0; yPos < m_cells.GetLength(1); yPos++)
            {
                GameObject currentCell = m_cells[xPos, yPos];
                CellModel currentCellModel = currentCell.GetComponent<CellModel>();
                if (xPos == 0 && yPos > 0)
                {
                    GameObject westCell = m_cells[xPos, yPos - 1];
                    currentCellModel.AddSibling(westCell);
                }
                else if (xPos > 0 && yPos > 0)
                {
                    GameObject westCell = m_cells[xPos, yPos - 1];
                    GameObject northCell = m_cells[xPos - 1, yPos];
                    currentCellModel.AddSibling(westCell);
                    currentCellModel.AddSibling(northCell);
                }
                else if (xPos > 0 && yPos == 0)
                {
                    GameObject northCell = m_cells[xPos - 1, yPos];
                    currentCellModel.AddSibling(northCell);
                }
                
            }
        }

    }

    private void CreateCells()
    {
        m_cells = new GameObject[row, column];

        GameObject newCell;

        for (int x_pos = 0; x_pos < row; x_pos++)
        {
            for (int y_pos = 0; y_pos < column; y_pos++)
            {
                Vector3 cellPosition = new Vector3(x_pos * wallLenght, 0.0f, y_pos * wallLenght);

                cell.GetComponent<CellConstruct>().wallLenght = wallLenght;
                newCell = Instantiate(cell, cellPosition, Quaternion.identity);

                InitializeNewCell(newCell, x_pos, y_pos);
                m_cells[x_pos, y_pos] = newCell;
            }
        }
    }

    private void InitializeNewCell(GameObject newCell, int x_pos, int y_pos)
    {
        CellModel cell = newCell.GetComponent<CellModel>();
        cell.Name = "Cell x: " + x_pos + " y: " + y_pos;
        cell.X_Position = x_pos;
        cell.Y_Position = y_pos;
        newCell.transform.parent = this.transform;
    }

    public GameObject GetRandomCell()
    {
        int xPos = Utils.GetRandomNumber(0, row);
        int yPos = Utils.GetRandomNumber(0, column);

        return m_cells[xPos, yPos];
    }

}
