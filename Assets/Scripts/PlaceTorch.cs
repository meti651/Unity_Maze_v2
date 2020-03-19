using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTorch : MonoBehaviour
{
    public GameObject Torch;

    Transform m_TorchLight;
    Animator m_Animator;

    private void Start()
    {
        m_TorchLight = Torch.transform.Find("Torch_light");
        m_Animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            m_Animator.SetBool("IsPlaceTorch", false);
            return;
        }
        m_Animator.SetBool("IsPlaceTorch", true);

        m_TorchLight.GetComponent<Light>().range = 15;

        Vector3 position = this.transform.position;

        Instantiate(Torch, position, Quaternion.identity);
    }
}
