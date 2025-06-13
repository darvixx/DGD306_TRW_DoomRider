using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player2Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    

    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;
    private Animator animator;

    public Transform attackPoint; 
    public float attackRange = 1f;
    public LayerMask enemyLayers;
    public int attackDamage = 1;

    public AudioClip footstepClip;
    public AudioClip shootClip;

    private AudioSource audioSource;

    private float footstepTimer = 0f;
    public float footstepInterval = 0.4f; 


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            moveInput = -1f;
        else if (Input.GetKey(KeyCode.RightArrow))
            moveInput = 1f;
        else
            moveInput = 0f;


        
        if (Input.GetKeyDown(KeyCode.RightShift) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        
        if (moveInput > 0)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);


        animator.SetFloat("speed", Mathf.Abs(moveInput));
        animator.SetBool("isJumping", !isGrounded);


        if (Input.GetKeyDown(KeyCode.L))
        {
            animator.SetTrigger("Attack");
            if (shootClip != null)
                audioSource.PlayOneShot(shootClip);
        }

        if (isGrounded && Mathf.Abs(moveInput) > 0.1f)
        {
            footstepTimer -= Time.deltaTime;
            if (footstepTimer <= 0f)
            {
                if (footstepClip != null)
                    audioSource.PlayOneShot(footstepClip);

                footstepTimer = footstepInterval;
            }
        }
        else
        {
            footstepTimer = 0f; // durunca timer sýfýrlansýn
        }


    }

    void FixedUpdate()
    {
        
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    public void DealDamage()
    {

        

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>()?.TakeDamage(attackDamage);
        }
    }
    
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);

        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }

    


}
