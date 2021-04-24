using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private bool isAlive = true;

    private void Awake()
    {
        if (instance == null)
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

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            string currentScene = SceneLoader.instance.GetCurrentScene();
            if (currentScene == "MainMenu")
            {
                SceneLoader.instance.LoadCutScene();
            }
            else if(currentScene == "CutScene")
            {
                SceneLoader.instance.LoadGameScene();
            }
            else if(currentScene == "GameScene")
            {
                if (!isAlive)
                {
                    SceneLoader.instance.LoadMainMenu();
                }
            }
        }
    }
}
