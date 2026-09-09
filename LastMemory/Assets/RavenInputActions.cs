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

    // ============================
    // EVENTS
    // ============================
    public event System.Action SprintPerformed;
    public event System.Action JumpPerformed;
    public event System.Action AttackPerformed;
    public event System.Action DefendPerformed;
    public event System.Action InteractPerformed;
    // ============================
    // VALUE
    // ============================
    public Vector2 move => _Move.ReadValue<Vector2>();
    public Vector2 look => _Look.ReadValue<Vector2>();

    // ============================
    // SPRINT
    // ============================
    public bool SprintPressed => _Sprint.WasPressedThisFrame();
    public bool SprintHeld => _Sprint.IsPressed();
    public bool SprintReleased => _Sprint.WasReleasedThisFrame();
    // ============================
    // JUMP
    // ============================
    public bool JumpPressed => _Jump.WasPressedThisFrame();
    public bool JumpHeld => _Jump.IsPressed();
    public bool JumpReleased => _Jump.WasReleasedThisFrame();
    // ============================
    // ATTACK
    // ============================
    public bool AttackPressed => _Attack.WasPressedThisFrame();
    public bool AttacktHeld => _Attack.IsPressed();
    public bool AttackReleased => _Attack.WasReleasedThisFrame();
    // ============================
    // DEFEND
    // ============================
    public bool DefendPressed => _Defend.WasPressedThisFrame();
    public bool DefendHeld => _Defend.IsPressed();
    public bool DefendReleased => _Defend.WasReleasedThisFrame();
    // ============================
    // INTERACT
    // ============================
    public bool InteractPressed => _Interact.WasPressedThisFrame();
    public bool InteractHeld => _Interact.IsPressed();
    public bool InteractReleased => _Interact.WasReleasedThisFrame();

    private void Awake()
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
