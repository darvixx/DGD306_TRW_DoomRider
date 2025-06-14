using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player2Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayers;
    public int attackDamage = 1;

    public AudioClip footstepClip;
    public AudioClip shootClip;

    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource audioSource;

    private Player2InputActions inputActions;
    private Vector2 moveInput;
    private bool isGrounded;

    private float footstepTimer = 0f;
    public float footstepInterval = 0.4f;

    private void Awake()
    {
        inputActions = new Player2InputActions();
    }

    private void OnEnable()
    {
        inputActions.Player2.Enable();
        inputActions.Player2.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player2.Move.canceled += ctx => moveInput = Vector2.zero;
        inputActions.Player2.Jump.performed += ctx => Jump();
        inputActions.Player2.Attack.performed += ctx => Attack();
    }

    private void OnDisable()
    {
        inputActions.Player2.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Flip
        if (moveInput.x > 0)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        else if (moveInput.x < 0)
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        // Animasyonlar
        animator.SetFloat("speed", Mathf.Abs(moveInput.x));
        animator.SetBool("isJumping", !isGrounded);

        // Footstep sesi
        if (isGrounded && Mathf.Abs(moveInput.x) > 0.1f)
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
            footstepTimer = 0f;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");

        if (shootClip != null)
            audioSource.PlayOneShot(shootClip);

        DealDamage();
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

        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}
