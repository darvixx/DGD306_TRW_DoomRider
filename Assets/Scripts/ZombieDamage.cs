using UnityEngine;
using System.Collections;

public class ZombieDamage : MonoBehaviour
{
    public int damageAmount = 1;
    public float damageInterval = 1f;

    private bool isDamaging = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Player2"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null && !isDamaging)
            {
                StartCoroutine(DamageOverTime(health));
            }
        }
    }

    IEnumerator DamageOverTime(PlayerHealth health)
    {
        isDamaging = true;
        health.TakeDamage(damageAmount);
        yield return new WaitForSeconds(damageInterval);
        isDamaging = false;
    }
}
