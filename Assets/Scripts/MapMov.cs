using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMov : MonoBehaviour
{
    public float speed;
    public bool canMove;
    void Update()
    {
        if (!canMove) { return; }
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
