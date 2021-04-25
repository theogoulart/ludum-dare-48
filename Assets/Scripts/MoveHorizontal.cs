using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHorizontal : MonoBehaviour
{
    [SerializeField] private float range = 2f;
    [SerializeField] private float xSpeed = 2f;
    [SerializeField] private float ySpeed = 2f;
    [SerializeField] private float finalXPos;
    [SerializeField] private float initialXPos;
    [SerializeField] private float timeToDestroy = 15f;
    [SerializeField] private bool facingRight = true;
    private SpriteRenderer rend;
    private void Awake()
    {
        initialXPos = transform.position.x - range;
        finalXPos = transform.position.x + range;
        rend = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float xPos;
        if (facingRight)
        {
            if (transform.position.x >= finalXPos)
            {
                facingRight = false;
                return;
            }
            rend.flipX = false;
            xPos = transform.position.x + xSpeed * Time.deltaTime;
        }
        else
        {
            if (transform.position.x <= initialXPos)
            {
                facingRight = true;
                return;
            }
            rend.flipX = true;
            xPos = transform.position.x - xSpeed * Time.deltaTime;
        }
        
        float yPos = transform.position.y + ySpeed * Time.deltaTime;
        transform.position = new Vector3(xPos
                                         , yPos
                                         , transform.position.z);
    }
}
