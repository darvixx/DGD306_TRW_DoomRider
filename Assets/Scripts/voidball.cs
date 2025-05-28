using UnityEngine;

public class voidball : MonoBehaviour
{
    public float speed = 8f;

    void Start()
    {
        
        float direction = transform.localScale.x > 0 ? 1f : -1f;

        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        
        rb.linearVelocity = new Vector2(speed * direction, 0f);

        
        Destroy(gameObject, 1f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemy = other.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(1); 
            }

            Destroy(gameObject); 
        }
    }

}
