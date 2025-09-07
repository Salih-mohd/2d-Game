using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private GameDataSO gameDataSO;

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        gameDataSO.onGameLose.AddListener(DieAnimation);
    }

    private void OnDisable()
    {
        gameDataSO.onGameLose.RemoveListener(DieAnimation);
    }


    public void DieAnimation()
    {
        animator.SetTrigger("die");
    }
}
