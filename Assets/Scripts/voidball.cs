using UnityEngine;

public class voidball : MonoBehaviour
{
    public float speed = 8f;

    void Start()
    {
        // Y�n: scale'dan belirleniyor
        float direction = transform.localScale.x > 0 ? 1f : -1f;

        // Rigidbody2D componentini al
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // �leri do�ru velocity ver
        rb.linearVelocity = new Vector2(speed * direction, 0f);

        // Yok et
        Destroy(gameObject, 1f);
    }
}
