using UnityEngine;

public class ZombieFollow : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float followRange = 10f;

    private Transform player1;
    private Transform player2;
    private Transform target;

    private Vector3 originalScale;
    private Rigidbody2D rb;

    void Start()
    {
        GameObject p1 = GameObject.FindGameObjectWithTag("Player");
        GameObject p2 = GameObject.FindGameObjectWithTag("Player2");

        if (p1 != null) player1 = p1.transform;
        if (p2 != null) player2 = p2.transform;

        originalScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player1 == null && player2 == null) return;

        float dist1 = player1 != null ? Vector2.Distance(transform.position, player1.position) : Mathf.Infinity;
        float dist2 = player2 != null ? Vector2.Distance(transform.position, player2.position) : Mathf.Infinity;

        if (dist1 < dist2 && dist1 <= followRange)
            target = player1;
        else if (dist2 <= followRange)
            target = player2;
        else
            target = null;
    }

    void FixedUpdate()
    {
        if (target == null) return;

        // Sadece yatay hareket
        float directionX = Mathf.Sign(target.position.x - transform.position.x);
        rb.linearVelocity = new Vector2(directionX * moveSpeed, rb.linearVelocity.y);

        // Flip işlemi
        if (directionX > 0)
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        else if (directionX < 0)
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
    }
}
