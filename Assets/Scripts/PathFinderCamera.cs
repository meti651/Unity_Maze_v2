using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinderCamera : MonoBehaviour
{
    public int Row;
    public int Column;
    
    void Start()
    {
        Vector3 mazePosition = new Vector3(0f, 0f, 0f);
        mazePosition.y += (Row + Column);
        mazePosition.z += Column / 2;
        mazePosition.x += Row / 2;
        transform.position = mazePosition;
    }

    
}
