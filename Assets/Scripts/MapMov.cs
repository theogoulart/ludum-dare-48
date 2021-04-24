using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMov : MonoBehaviour
{

    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
        
    }
}
