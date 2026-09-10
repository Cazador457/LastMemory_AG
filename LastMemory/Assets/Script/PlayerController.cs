using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private RavenInputActions RavenInput;

    [SerializeField] private CharacterController playerController;
    private Animator Animation;
    public float speed = 5f;
    public float sensity = 200;
    public Transform Player;
    public float XRotation=0f;

    void Start()
    {
        Animation=GetComponent<Animator>();
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
        Vector2 movement = RavenInput.move;
        Vector3 FinalDirectoion = (transform.forward * movement.y) + (transform.right * movement.x);
        transform.position += FinalDirectoion * speed * Time.deltaTime;
    }
    private void Loock()
    {
        Vector2 look = RavenInput.look;
        float MouseX = look.x * sensity * Time.deltaTime;
        float MouseY = look.y * sensity * Time.deltaTime;

        XRotation += MouseY;
        XRotation = Mathf.Clamp(XRotation, -75f, 75f);
        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);

        Player.Rotate(Vector3.up * MouseX);
    }
    private void ActionsGame()
    {
        if (RavenInput.SprintHeld)
        {
            Sprint();
        }
        // DEFENDER
        if (RavenInput.DefendPressed)
        {
            Defend(true);
        }

        if (RavenInput.DefendReleased)
        {
            Defend(false);
        }
    }
    private void Jump()
    {
        
        Debug.Log("saltando");
    }
    private void Attack()
    {
        Animation.SetTrigger("Attack");
        Debug.Log("Atacando");
    }
    private void Sprint()
    {
        
        Debug.Log("Sprint");
    }
    private void Interact()
    {
        Debug.Log("Interactuando");
    }
    private void Defend(bool defending)
    {
        Animation.SetBool("Defend", defending);
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
