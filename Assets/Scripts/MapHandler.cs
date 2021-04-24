using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHandler : MonoBehaviour
{
    
    public GameObject mapHandler;
    public float maxTime;

    private float timer = 0f;
    private int count = 0;

    // Update is called once per frame
    void Update()
    {
        
        if(timer > maxTime && count == 0 || timer > 2*maxTime)
        {
            GameObject newMap = Instantiate(mapHandler);
            newMap.transform.position = transform.position + new Vector3(0, -9.9f, 0);
            Destroy(newMap, 31f);
            timer = 0;
            count = 1;
        }
        timer += Time.deltaTime;
    }
}
