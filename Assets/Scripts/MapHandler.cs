using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHandler : MonoBehaviour
{
    
    public GameObject mapHandler;
    public float maxTime;

    [SerializeField] private float timeToDestroy = 31f;
    [SerializeField] private float timer = 0f;
    [SerializeField] private int count = 0;
    [SerializeField] private int mapCount = 0;

    [SerializeField] private bool canSpawn = false;

    void Update()
    {
        if(!canSpawn) { return; }

        if ((timer > maxTime && count == 0 ) || (timer > maxTime))
        {
            GameObject newMap = Instantiate(mapHandler, transform);
            newMap.transform.position = transform.position + new Vector3(0, -9.9f, 0);
            Destroy(newMap, timeToDestroy);
            timer = 0;
            count = 1;
            mapCount++;
        }
        timer += Time.deltaTime;
    }

    public void SetCanSpawn(bool value)
    {
        mapCount = 0;
        canSpawn = value;
        foreach(Transform child in transform)
        {
            MapMov map = child.GetComponent<MapMov>();

            if (map)
            {
                map.canMove = value;
            }
        }
    }
}
