using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public static ScoreHandler instance;
    public const string RECORD_KEY = "RECORD";
    private bool inGame = false;
    [SerializeField] private int currentPoints = 0;
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
            currentPoints = (int)(Time.realtimeSinceStartup - startTime);
        }
    }

    public void SaveRecord(int newRecord)
    {
        PlayerPrefs.SetInt(RECORD_KEY, newRecord);
    }

    public int GetCurrentRecord()
    {
        return PlayerPrefs.GetInt("RECORD");
    }

    public void StartCount()
    {
        startTime = Time.realtimeSinceStartup;
        inGame = true;
    }

    public void ResetCurrentPoints()
    {
        currentPoints = 0;
        inGame = false;
    }

    public int GetCurrentScore()
    {
        return currentPoints;
    }

    public void StopCount()
    {
        inGame = false;
        if(GetCurrentRecord() < GetCurrentScore())
        {
            SaveRecord(GetCurrentScore());
        }
    }
}
