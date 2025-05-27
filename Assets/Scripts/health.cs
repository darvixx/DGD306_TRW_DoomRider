using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    


    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Can: " + currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;  
            Die();
        }
    }

    void Die()
    {
        Debug.Log("You died.GAME OVER!");


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(1); 
        }
    }


}
