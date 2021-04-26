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
    
    // FMOD sfx
    [FMODUnity.EventRef]
    public string typingSound;
    public FMOD.Studio.EventInstance soundEvent;

    private void Awake()
    {
        textBox = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        soundEvent = FMODUnity.RuntimeManager.CreateInstance(typingSound);
        if (!textBox)
        {
            Debug.LogError("not found textmeshpro component");
        }
        else
        {
            textBox.text = "";
        }
        StartCoroutine(ShowText(textToShow[0]));
        PlayTypingSound();
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

    private void PlayTypingSound()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(soundEvent, GetComponent<Transform>(), GetComponent<Rigidbody>());
        FMOD.Studio.PLAYBACK_STATE fmodPbState;
        soundEvent.getPlaybackState(out fmodPbState);
        if (fmodPbState != FMOD.Studio.PLAYBACK_STATE.PLAYING) 
        {
            soundEvent.start();
        }
    }
}
