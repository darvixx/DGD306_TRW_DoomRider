using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    public Image[] hearts; // Kalplerin Image dizisi
    public Sprite fullHeart; // Sadece dolu kalp kullan�l�yor

    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth.currentHealth)
            {
                hearts[i].sprite = fullHeart;
                hearts[i].enabled = true; // G�r�n�r yap
            }
            else
            {
                hearts[i].enabled = false; // Kalbi gizle
            }
        }
    }
}
