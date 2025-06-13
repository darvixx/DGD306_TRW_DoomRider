using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    private bool isTakingDamage = false;
    private SpriteRenderer spriteRenderer;

    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        if (isTakingDamage) return;

        currentHealth -= amount;
        Debug.Log("Can: " + currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
        else
        {
            StartCoroutine(HitFlash());
        }
    }

    IEnumerator HitFlash()
    {
        isTakingDamage = true;
        spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(1f); 

        spriteRenderer.color = Color.white;
        isTakingDamage = false;
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;
        Debug.Log("GAME OVER");


        animator.SetTrigger("Die");

        StartCoroutine(DeathSequence());
    }

    IEnumerator DeathSequence()
    {
        // Animasyon s�resine g�re bekleme s�resi ayarla (�rne�in 1.5 saniye)
        yield return new WaitForSeconds(1.5f);

        // Hareket, sald�r� gibi scriptleri devre d��� b�rak
        if (GetComponent<Deneme>() != null)
            GetComponent<Deneme>().enabled = false;

        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

        


        // Karakteri yok et
        Destroy(gameObject);
    }
    void Update()
    {
        
    }
}
