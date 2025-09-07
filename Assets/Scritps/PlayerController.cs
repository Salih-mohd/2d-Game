using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("References")]
    public InputReader inputReader;
    public Rigidbody2D rb;
    public Animator animator;
    public Transform attackPoint;
    public UIManager uiManager;
    public CapsuleCollider2D capsuleCollider;
    public GameDataSO gameDataSO;
    public EnemyAttack enemyAttack;

    [Header("Fields")]

    public float speed;
    public float attackRange;
    public LayerMask enemyLayer;
    public float attackRate;
    public float jumpForce;


    [SerializeField]private bool isGrounded;
    private bool doJump;
    private float nextAttackTime=0;
    //private Vector2 move;
    //private bool _isAttacking;

    

    

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnEnable()
    {
        gameDataSO.onGameLose.AddListener(DisableCollider);
    }
    private void OnDisable()
    {
        gameDataSO.onGameLose.RemoveListener(DisableCollider);
    }

    // Update is called once per frame
    void Update()
    {

        HandleAttack();
        HandleJumpInput();

    }

    private void HandleAttack()
    {
        if (Time.time >= nextAttackTime && inputReader.AttackPressed)
        {
            nextAttackTime = Time.time + 1f / attackRate;
            animator.SetTrigger("attack");
            AudioManager.Instance.AttackFX();

            Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
            foreach (var hit in hits)
            {
                

                uiManager.DecreaseEnemyHealth(2);
            }
        }
    }

    private void HandleJumpInput()
    {
        if (inputReader.JumpPressed && isGrounded)
        {
            AudioManager.Instance.JumpSFX();
            isGrounded = false;
            animator.SetTrigger("jump");
            doJump = true;
        }
    }


    private void FixedUpdate()
    {
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        Vector2 velocity = rb.linearVelocity;
        velocity.x = inputReader.Move.x * speed;



        // runnign audio managing
        bool isMoving = velocity.x != 0;
        AudioManager.Instance.RunFX(isMoving,isGrounded);


        // Flip sprite
        if (velocity.x > 0) transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (velocity.x < 0) transform.rotation = Quaternion.Euler(0, -180, 0);

        // Walk animation
        animator.SetBool("walk", velocity.x != 0);

        rb.linearVelocity = velocity;
    }

    private void HandleJump()
    {
        if (doJump)
        {
            doJump = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
        {
            isGrounded = true;
        }

        if (collision.collider.CompareTag("trap"))
        {

            //animator.SetTrigger("die");
            GameManger.Instance.GameLoseInvoke();

            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            PlayerHealth.instance.DecreaseHealth(20);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("music trigger"))
        {
            gameDataSO.OnSeeingEnemy.Invoke();
        }
    }

    public void DisableCollider()
    {
        capsuleCollider.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
