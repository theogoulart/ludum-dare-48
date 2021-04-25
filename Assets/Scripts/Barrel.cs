using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float timeToDestroy = 10f;


    private void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }

    void Update()
    {
        MoveUp();
    }

    private void MoveUp()
    {
        float yPos = transform.position.y + speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x
                                         , yPos
                                         , transform.position.z);
    }
}
