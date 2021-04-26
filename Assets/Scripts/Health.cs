using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private int currentHealth;
    [SerializeField] private LivesDisplay livesDisplay;

    private void Start()
    {
        currentHealth = maxHealth;
        livesDisplay.UpdateDisplay(currentHealth);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReduceLife();
        }
    }

    private void ReduceLife()
    {
        currentHealth--;
        livesDisplay.UpdateDisplay(currentHealth);
        if(currentHealth <= 0)
        {
            GameManager.instance.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Impact>().PlayImpactSound();
            ReduceLife();
        }
    }

}
