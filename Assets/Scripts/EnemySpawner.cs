using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] private List<GameObject> enemyList = new List<GameObject>();
    [SerializeField] private bool canSpawn = false;
    [SerializeField] private Vector2 timeRangeToSpawn = new Vector2(2f, 4f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            canSpawn = false;
            Spawn();

        }
    }

    private void Spawn()
    {
        GameObject enemyToSpawn = enemyList[Random.Range(0, enemyList.Count)];
        Transform pos = spawnPoints[Random.Range(0, spawnPoints.Count)];

        Instantiate(enemyToSpawn, pos);

        StartCoroutine(CoolDown());
    }

    private IEnumerator CoolDown()
    {
        yield return new WaitForSecondsRealtime(Random.Range(timeRangeToSpawn.x, timeRangeToSpawn.y));
        canSpawn = true;
    }
}
