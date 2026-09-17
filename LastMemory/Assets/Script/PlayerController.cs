using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private RavenInputActions RavenInput;

    [SerializeField] private CharacterController playerController;
    [SerializeField] private Transform Camera;
    public float speed = 5f;
    public float sprint = 7f;
    public float sensity = 200;
    private float XRotation = 0f;

    private Vector3 verticalVelocity;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float fallGravityMultipler = 2f;
    private bool IsGrounded;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpCutMultipler = 2f;

    void Start()
    {
        playerController=GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Movement();
        ActionsGame();
        Loock();
    }
    private void Movement()
    {
        IsGrounded = playerController.isGrounded;
        if (IsGrounded && verticalVelocity.y < 0) 
            verticalVelocity.y = -2f;

        Vector2 movement = RavenInput.move;
        Vector3 FinalDirectoion = (transform.forward * movement.y) + (transform.right * movement.x);
        playerController.Move(FinalDirectoion * speed * Time.deltaTime);

        float currentVelocity = gravity;
        if (verticalVelocity.y < 0) currentVelocity *= fallGravityMultipler;

        verticalVelocity.y += currentVelocity * Time.deltaTime;
        playerController.Move(verticalVelocity*Time.deltaTime);
    }
    private void Loock()
    {
        Vector2 look = RavenInput.look;
        float MouseX = look.x * sensity * Time.deltaTime;
        float MouseY = look.y * sensity * Time.deltaTime;
        //Body Rotate
        transform.Rotate(Vector3.up * MouseX);
        //Camera Rota
        XRotation += MouseY;
        XRotation = Mathf.Clamp(XRotation, -75f, 75f);
        Camera.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
    }
    private void ActionsGame()
    {
        if (RavenInput.SprintHeld) Sprint();
        if (RavenInput.SprintReleased) speed = 5f;

        // DEFENDER
        if (RavenInput.DefendPressed)
            Defend(true);
        if (RavenInput.DefendReleased)
            Defend(false);
        // JUMP CUT
        if (RavenInput.JumpReleased && verticalVelocity.y > 0)
            verticalVelocity.y /= jumpCutMultipler;
    }
    private void Jump()
    {
        if (playerController.isGrounded)
            verticalVelocity.y += Mathf.Sqrt(jumpForce * -2f * gravity);
    }
    private void Attack()
    {
        Debug.Log("Atacando");
    }
    private void Sprint()
    {
        speed = sprint;
    }

    private void Interact()
    {
        Debug.Log("Interactuando");
    }
    private void Defend(bool defending)
    {
        Debug.Log("Defender+" + defending);
    }
    private void OnEnable()
    {
        RavenInput.JumpPerformed += Jump;
        RavenInput.AttackPerformed += Attack;
        RavenInput.InteractPerformed += Interact;
    }
    private void OnDisable()
    {
        RavenInput.JumpPerformed -= Jump;
        RavenInput.AttackPerformed -= Attack;
        RavenInput.InteractPerformed -= Interact;
    }
}
