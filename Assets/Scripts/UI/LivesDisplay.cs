using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    public void UpdateDisplay(int value)
    {
        GetComponent<TextMeshProUGUI>().text = value.ToString();
    }
}
