using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingCellModell : CellModel, IComparable
{
    public GameObject PreviousCell;
    private float DistanceFromStart;
    private float DistanceFromFinish;
    public float DistanceValue;
    private CellModel m_FinishCell;
    

    private void Start()
    {
        GameObject maze = transform.parent.gameObject;
        m_FinishCell = maze.GetComponent<MazeModel>().FinishCell.GetComponent<CellModel>();

        DistanceFromStart = X_Position + Y_Position;
        DistanceFromFinish = m_FinishCell.X_Position - X_Position + m_FinishCell.Y_Position - Y_Position;
        DistanceValue = DistanceFromStart + DistanceFromFinish;
    }


    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        PathFindingCellModell otherCell = obj as PathFindingCellModell;
        if(otherCell != null)
        {
            return DistanceValue.CompareTo(otherCell.DistanceValue);
        }else
        {
            throw new ArgumentException("Object is not a PathFindingCell");
        }

    }
}
