using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public GameObject Player;

    [Range(0.1f, 1.0f)]
    public float SmoothFactor = 0.5f;

    private Vector3 m_cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 startingPosition = this.transform.parent.position;
        this.transform.position = startingPosition;

        m_cameraOffset = this.transform.position - Player.transform.position;
        m_cameraOffset.z += 0.01f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = Player.transform.position + m_cameraOffset;

        this.transform.position = Vector3.Slerp(this.transform.position, newPosition, SmoothFactor);

    }
}
