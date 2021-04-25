using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] private float timeToDestroy = 1f;
    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }
}
