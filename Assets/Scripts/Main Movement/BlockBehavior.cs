using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    public Block block;
    private int currentHealth;

    private void Start()
    {
        currentHealth = block.health;
    }

    public void TakeDamage(int amount) //amount will provided by the collision, blockbehavior 
    {
        currentHealth -= amount;
        Debug.Log(gameObject.name + " took damage. Health left: " + currentHealth);
        if (currentHealth <= 0)
        {
            GameManager.Instance.AddScore(block.scoreValue);
            Destroy(gameObject);
        }
    }
}
