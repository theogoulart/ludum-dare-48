using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private bool isAlive = true;
    private bool inGame = false;

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
        CheckInputs();

        if(inGame && Input.GetKeyDown(KeyCode.Escape))
        {
            GameOver();
        }
    }

    private void CheckInputs()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            string currentScene = SceneLoader.instance.GetCurrentScene();
            if (currentScene == "MainMenu")
            {
                SceneLoader.instance.LoadCutScene();
            }
            else if (currentScene == "CutScene")
            {
                SceneLoader.instance.LoadGameScene();
                StartCoroutine(SetupGameScene());
            }
            else if (currentScene == "GameScene")
            {
                if (!isAlive)
                {
                    SceneLoader.instance.LoadMainMenu();
                    SetupMainMenu();
                }
            }
        }
    }

    private IEnumerator SetupGameScene()
    {
        yield return new WaitForSecondsRealtime(2f);

        MapHandler mapHandler = FindObjectOfType<MapHandler>();
        Mover mover = FindObjectOfType<Mover>();
        if (mapHandler)
        {
            mapHandler.SetCanSpawn(true); 
        }
        if (mover)
        {
            mover.SetCanMove(true);
        }
        FindObjectOfType<EnemySpawner>()?.SetCanSpawn(true);
        ScoreHandler.instance.StartCount();
        inGame = true;
    }

    private void SetupMainMenu()
    {

    }

    public void GameOver()
    {
        isAlive = false;
        inGame = false;
        ScoreHandler.instance.StopCount();


        SceneLoader.instance.LoadMainMenu();
    }
}
