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
    MonoBehaviour movementScript;
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
        animator.SetTrigger("Die1");


        StartCoroutine(DeathSequence());

        SceneManager.LoadScene("GameOver");
    }

    IEnumerator DeathSequence()
    {
        
        yield return new WaitForSeconds(1.5f);

        
        if (GetComponent<Deneme>() != null)
            GetComponent<Deneme>().enabled = false;

        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

        if (GetComponent<Player2Movement>() != null)
            GetComponent<Player2Movement>().enabled = false;

        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;



        Destroy(gameObject);
    }
    void Update()
    {
        
    }
}
