using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowRowValue : MonoBehaviour
{
    TextMeshProUGUI rowNum;

    private void Start()
    {
        rowNum = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeText(float value)
    {
        rowNum.text = Mathf.RoundToInt(value).ToString();
    }
}
