using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Image[] hearts; 
    public Sprite fullHeart; 

    public PlayerHealth playerHealth;

    void Start()
    {
         if (playerHealth == null)
            Debug.LogError("UI PlayerHealth referansý atanmadý!");
    }

    void Update()
    {
        if (playerHealth == null) return;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth.currentHealth)
            {
                hearts[i].sprite = fullHeart;
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
