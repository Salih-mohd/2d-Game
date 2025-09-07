using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{

    [Header("references")]

    [SerializeField] private InputActionAsset inputActions;

    [Header("Fields")]

    public Vector2 Move { get; private set; }
    public bool AttackPressed { get; private set; }
    public bool JumpPressed { get; private set; }

    public bool isPaused {  get; private set; }

    // Actions

    [HideInInspector] public  InputAction moveAction;
    [HideInInspector] public InputAction attackAction;
    [HideInInspector] public InputAction jumpAction;
    [HideInInspector] public InputAction pauseAction;

    

    private void Awake()
    {
        moveAction = inputActions.FindAction("Player/Move");
        attackAction = inputActions.FindAction("Player/Attack");
        jumpAction = inputActions.FindAction("Player/Jump");
        pauseAction = inputActions.FindAction("Player/Pause");
    }


    private void OnEnable()
    {
        inputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        inputActions.FindActionMap("Player").Disable();
    }



    // Update is called once per frame
    void Update()
    {
        GettingInputs();
        
    }

    private void GettingInputs()
    {
        Move = moveAction.ReadValue<Vector2>();
        AttackPressed = attackAction.WasPerformedThisFrame();
        JumpPressed = jumpAction.WasPerformedThisFrame();
        isPaused = pauseAction.WasPerformedThisFrame();     

         
    }

    

    
}
