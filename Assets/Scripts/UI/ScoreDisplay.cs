using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI score;

    private void Awake() => score = GetComponent<TextMeshProUGUI>();
    
    void Update()
    {
        score.text = (ScoreHandler.instance.GetCurrentScore()).ToString();
    }
}
