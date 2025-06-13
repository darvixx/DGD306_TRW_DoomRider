using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Deneme : MonoBehaviour
   
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public GameObject voidballPrefab;
    public Transform FirePoint;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;
    private Animator anim;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    private void Update()
    {
        // Input
        if (Input.GetKey(KeyCode.A))
            moveInput = -1f;
        else if (Input.GetKey(KeyCode.D))
            moveInput = 1f;
        else
            moveInput = 0f;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Flip character direction
        if (moveInput > 0)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        if (isGrounded)
            anim.SetFloat("speed", Mathf.Abs(moveInput));
        else
            anim.SetFloat("speed", 0);

        anim.SetBool("isJumping", !isGrounded);

        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger("attack");
            
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject voidball = Instantiate(voidballPrefab,FirePoint.position, Quaternion.identity);

            
            Vector3 scale = voidball.transform.localScale;
            scale.x = transform.localScale.x > 0 ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
            voidball.transform.localScale = scale;
        }



    }

    private void FixedUpdate()
    {
        // Movement
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    
}
