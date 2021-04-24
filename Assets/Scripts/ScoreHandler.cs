using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler instance;
    private bool inGame = false;
    private int currentPoints = 0;
    [SerializeField] private float startTime = 0;

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

    void Update()
    {
        if (inGame)
        {
            currentPoints = (int)(Time.deltaTime - startTime);
        }
    }

    public void SaveRecord(int newRecord)
    {
        PlayerPrefs.SetInt("RECORD", newRecord);
    }

    public int GetCurrentRecord()
    {
        return PlayerPrefs.GetInt("RECORD");
    }

    public void StartCount()
    {
        startTime = Time.deltaTime;
        inGame = true;
    }

    public void ResetCurrentPoints()
    {
        currentPoints = 0;
        inGame = false;
    }
}
