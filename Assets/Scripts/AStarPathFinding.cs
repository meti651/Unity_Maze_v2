using Datastructures.PriorityQueue;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarPathFinding : MonoBehaviour
{
    public MazeModel m_MazeComponent;
    private GameObject m_StartCell;
    private GameObject m_FinishCell;
    public Material PathMaterial;

    public void AStartPathFinding()
    {
        m_StartCell = m_MazeComponent.StartingCell;
        m_FinishCell = m_MazeComponent.FinishCell;

        PriorityQueue<PathFindingCellModell> cells = new PriorityQueue<PathFindingCellModell>();
        HashSet<PathFindingCellModell> closedCells = new HashSet<PathFindingCellModell>();

        PathFindingCellModell startingCellModel = m_StartCell.GetComponent<PathFindingCellModell>();

        cells.Enqueue(startingCellModel);
        closedCells.Add(startingCellModel);

        PathFindingCellModell currentCell;
        while(cells.Count() > 0)
        {
            currentCell = cells.Dequeue();
            if (currentCell.transform.gameObject.Equals(m_FinishCell))
            {
                Stack<GameObject> path = GetPath(currentCell.transform.gameObject);
                ShowPath(path);
                break;
            }
            foreach(GameObject pathCell in currentCell.Links)
            { 
                
                PathFindingCellModell pathCellModel = pathCell.GetComponent<PathFindingCellModell>();

                if (!closedCells.Contains(pathCellModel))
                {
                    closedCells.Add(pathCellModel);
                    pathCellModel.PreviousCell = currentCell.transform.gameObject;
                    cells.Enqueue(pathCellModel);
                }
            }
            
        }
    }

    private void ShowPath(Stack<GameObject> path)
    {
        foreach(GameObject cell in path)
        {
            int children = cell.transform.childCount;
            GameObject floor = cell.transform.GetChild(children - 1).gameObject;
            floor.GetComponent<MeshRenderer>().material = PathMaterial;
        }
    }

    private Stack<GameObject> GetPath(GameObject currentCell)
    {
        Stack<GameObject> pathCells = new Stack<GameObject>();
        PathFindingCellModell currentCellModel = currentCell.GetComponent<PathFindingCellModell>();
        GameObject nextPathCell = currentCellModel.PreviousCell;
        while(nextPathCell != null)
        {
            pathCells.Push(nextPathCell);
            nextPathCell = nextPathCell.GetComponent<PathFindingCellModell>().PreviousCell;
        }
        pathCells.Pop();
        return pathCells;
    }
}
