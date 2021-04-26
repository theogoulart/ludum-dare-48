using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    // FMOD sfx
    [FMODUnity.EventRef]
    public string loadSceneSound;
    public FMOD.Studio.EventInstance soundEvent;

    void Start () 
    {
        soundEvent = FMODUnity.RuntimeManager.CreateInstance(loadSceneSound);
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameScene()
    {
        PlayLoadSceneSound();
        SceneManager.LoadScene("GameScene");
    }

    public void LoadCutScene()
    {
        PlayLoadSceneSound();
        SceneManager.LoadScene("CutScene");
    }

    public string GetCurrentScene()
    {
        return SceneManager.GetActiveScene().name;
    }

    private void PlayLoadSceneSound()
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
