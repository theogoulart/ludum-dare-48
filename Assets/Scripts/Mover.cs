using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private bool canMove = false;
    [SerializeField] private Vector2 limits;
    [SerializeField] private float speed = 2f;
    private SpriteRenderer rend;

    private void Awake() => rend = GetComponent<SpriteRenderer>();

    void Update()
    {
        if (canMove)
        {
            Move();
        }
    }

    private void Move()
    {
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            float xPos = transform.position.x + speed * Time.deltaTime;
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
            rend.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            float xPos = transform.position.x - speed * Time.deltaTime;
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
            rend.flipX = true;
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x
                                         , limits.x
                                         , limits.y)
                                        ,transform.position.y
                                        ,transform.position.z);
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }
}
