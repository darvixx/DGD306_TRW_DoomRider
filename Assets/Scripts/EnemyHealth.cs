using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;



public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 2;
    private int currentHealth;
    private Animator animator;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");
        animator.SetTrigger("boss_death");
        Destroy(gameObject, 1f);
    }

    IEnumerator LoadFinishScene()
    {
        yield return new WaitForSeconds(1.5f); // Ölüm animasyonu süresi kadar bekle
        SceneManager.LoadScene("FinishScene");
    }
}
