using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("references")]
    public EnemyPatrol patrolScript;
    public Sword swordScritp;
    public BoxCollider2D swordCollider;
    public BoxCollider2D attackCollider;
    public CapsuleCollider2D enemyCollider;
    public Rigidbody2D enemyRb;
    public GameDataSO gameDataSO;
    public GameObject enemy;
    public GameObject book;
    public bool isBookNotHidable;

    private bool isDied;
    
    
    

    public Animator animator;

    
    private void Start()
    {
        if(!isBookNotHidable)
        {
            book.SetActive(false);
        }
        
    }

    private void OnEnable()
    {
        gameDataSO.DyingEnemy.AddListener(Die);
    }
    private void OnDisable()
    {
        gameDataSO.DyingEnemy.RemoveListener(Die);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Attack();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(!isDied)
            {
                patrolScript.enabled = true;
                animator.SetTrigger("Walk");
            }
            
        }
    }

    public void Attack()
    {
        patrolScript.enabled = false;
        animator.SetTrigger("Attack");

    }

    public void Die()
    {
        
        Invoke("DisableEnemy", 2);
        isDied = true;
        animator.SetTrigger("Die");
        swordCollider.enabled = false;
        attackCollider.enabled = false;
        patrolScript.enabled=false;
        swordScritp.enabled=false;
        enemyCollider.enabled=false;
        enemyRb.bodyType=RigidbodyType2D.Static;
        
    }

    private void DisableEnemy()
    {
        if (!isBookNotHidable)
        {
            book.SetActive(true);
        }
        enemy.SetActive(false);
    }


}
