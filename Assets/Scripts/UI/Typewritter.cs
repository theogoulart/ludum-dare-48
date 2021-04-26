using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Typewritter : MonoBehaviour
{
    [SerializeField] private float delayBetweenLetters = 0.1f;
    [SerializeField] private List<string> textToShow = new List<string>();
    [SerializeField] private string currentText = "";

    private TextMeshProUGUI textBox;

    private void Awake()
    {
        textBox = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        if (!textBox)
        {
            Debug.LogError("not found textmeshpro component");
        }
        else
        {
            textBox.text = "";
        }
        StartCoroutine(ShowText(textToShow[0]));
    }

    private IEnumerator ShowText(string textReceived)
    {
        for(int i = 0; i < textReceived.Length; i++)
        {
            currentText = textReceived.Substring(0, i);
            textBox.text = currentText;
            yield return new WaitForSecondsRealtime(delayBetweenLetters);
        }
    }
}
