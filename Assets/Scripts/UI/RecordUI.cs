using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecordUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recordText;
    void Start()
    {
        SetText(ScoreHandler.instance.GetCurrentRecord());   
    }

    private void SetText(int currentRecord)
    {
        recordText.text = currentRecord.ToString();
    }
}
