using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour {

    [FMODUnity.EventRef]
    public string selectsound;
    public FMOD.Studio.EventInstance soundevent;

    void Start () 
    {
        soundevent = FMODUnity.RuntimeManager.CreateInstance (selectsound);
    }

    public void PlayImpactSound ()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(soundevent, GetComponent<Transform>(), GetComponent<Rigidbody>());
        FMOD.Studio.PLAYBACK_STATE fmodPbState;
        soundevent.getPlaybackState(out fmodPbState);
        if (fmodPbState != FMOD.Studio.PLAYBACK_STATE.PLAYING) 
        {
            soundevent.start ();
        }
    }
}