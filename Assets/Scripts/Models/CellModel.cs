using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class CellModel : MonoBehaviour
{
    public string Name;
    public GameObject NorthWall;
    public GameObject EastWall;
    public GameObject SouthWall;
    public GameObject WestWall;
    public bool IsFinish;
    public float X_Position;
    public float Y_Position;
    public List<GameObject> Siblings;
    public List<GameObject> Links;


    public GameObject GetRandomUnvisitedSibling(HashSet<GameObject> visitedCells)
    {
        List<GameObject> unvisitedCells = new List<GameObject>();
        foreach (GameObject sibling in Siblings)
        {
            if (!visitedCells.Contains(sibling))
            {
                unvisitedCells.Add(sibling);
            }
        }
        if (unvisitedCells.Count < 1)
        {
            return null;
        }
        int num = Utils.GetRandomNumber(0, unvisitedCells.Count);

        return unvisitedCells.ElementAt(num);
    }


    public void MakeLink(GameObject cellGameObject)
    {
        CellModel cell = cellGameObject.GetComponent<CellModel>();
        if (this.X_Position == cell.X_Position && this.Y_Position < cell.Y_Position)
        {
            Destroy(EastWall);
            Destroy(cell.WestWall);

        }
        else if (this.X_Position == cell.X_Position && this.Y_Position > cell.Y_Position)
        {
            Destroy(WestWall);
            Destroy(cell.EastWall);

        }
        else if (this.X_Position < cell.X_Position && this.Y_Position == cell.Y_Position)
        {
            Destroy(SouthWall);
            Destroy(cell.NorthWall);

        }
        else if (this.X_Position > cell.X_Position && this.Y_Position == cell.Y_Position)
        {
            Destroy(NorthWall);
            Destroy(cell.SouthWall);
        }
        else if (this.X_Position == cell.X_Position && this.Y_Position == cell.Y_Position)
        {
            throw new ArgumentException("You can't add link to the same Cell");
        }
        Links.Add(cellGameObject);
        cellGameObject.GetComponent<CellModel>().Links.Add(this.transform.gameObject);
        
    }

    public void AddSibling(GameObject cellGameObject)
    {
        if (cellGameObject != null)
        {
            CellModel cell = cellGameObject.GetComponent<CellModel>();
            this.transform.gameObject.GetComponent<CellModel>().Siblings.Add(cellGameObject);
            cell.Siblings.Add(this.transform.gameObject);
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        Siblings = new List<GameObject>();
        Links = new List<GameObject>();

    }

}
