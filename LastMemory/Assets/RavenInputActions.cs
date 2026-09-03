using UnityEngine;
using UnityEngine.InputSystem;

public class RavenInputActions : MonoBehaviour
{
    [SerializeField] private InputActionAsset _InputActions;

    private InputActionMap _Raven;

    private InputAction _Move;
    private InputAction _Look;
    private InputAction _Sprint;
    private InputAction _Jump;
    private InputAction _Attack;
    private InputAction _Defend;
    private InputAction _Interact;

    //[Header("Events")]
    public event System.Action SprintPerformed;
    public event System.Action JumpPerformed;
    public event System.Action AttackPerformed;
    public event System.Action DefendPerformed;
    public event System.Action InteractPerformed;

    public Vector2 move => _Move.ReadValue<Vector2>();
    public Vector2 look => _Look.ReadValue<Vector2>();

    [Header("Sprint Boton Action")]
    public bool sprintPressed => _Sprint.WasPressedThisFrame();
    public bool sprintHold => _Sprint.IsPressed();
    public bool sprintReleased => _Sprint.WasReleasedThisFrame();

    public bool jumpPressed => _Jump.WasPressedThisFrame();
    public bool jumpHold => _Jump.IsPressed();
    public bool jumpReleased => _Jump.WasReleasedThisFrame();

    public bool attackPressed => _Attack.WasPressedThisFrame();
    public bool attacktHold => _Attack.IsPressed();
    public bool attackReleased => _Attack.WasReleasedThisFrame();

    public bool defendPressed => _Defend.WasPressedThisFrame();
    public bool defendtHold => _Defend.IsPressed();
    public bool defendReleased => _Defend.WasReleasedThisFrame();

    public bool interactPressed => _Interact.WasPressedThisFrame();
    public bool interactHold => _Interact.IsPressed();
    public bool interactReleased => _Interact.WasReleasedThisFrame();

    public void Awake()
    {
        _Raven = _InputActions.FindActionMap("Raven");

        _Move = _Raven.FindAction("Move");
        _Look = _Raven.FindAction("Look");
        _Sprint = _Raven.FindAction("Sprint");
        _Jump = _Raven.FindAction("Jump");
        _Attack = _Raven.FindAction("Attack");
        _Defend = _Raven.FindAction("Defend");
        _Interact = _Raven.FindAction("Interact");
    }
    private void OnEnable()
    {
        _Raven.Enable();

        _Sprint.performed += OnSprintPerformed;
        _Jump.performed += OnJumpPerformed;
        _Attack.performed += OnAttackPerformed;
        _Defend.performed += OnDefendPerformed;
        _Interact.performed += OnInteractPerformed;
    }

    private void OnDisable()
    {
        _Sprint.performed -= OnSprintPerformed;
        _Jump.performed -= OnJumpPerformed;
        _Attack.performed -= OnAttackPerformed;
        _Defend.performed -= OnDefendPerformed;
        _Interact.performed -= OnInteractPerformed;

        _Raven.Disable();
    }
    private void OnSprintPerformed(InputAction.CallbackContext context)
    {
        SprintPerformed?.Invoke();
    }
    private void OnJumpPerformed(InputAction.CallbackContext context)
    {
        JumpPerformed?.Invoke();
    }
    private void OnAttackPerformed(InputAction.CallbackContext context)
    {
        AttackPerformed?.Invoke();
    }
    private void OnDefendPerformed(InputAction.CallbackContext context)
    {
        DefendPerformed?.Invoke();
    }
    private void OnInteractPerformed(InputAction.CallbackContext context)
    {
        InteractPerformed?.Invoke();
    }
}
