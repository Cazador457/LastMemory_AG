using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private RavenInputActions RavenInput;

    [SerializeField] private CharacterController playerController;
    public float speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        Movement();
        ActionsGame();
    }
    private void Movement()
    {
        Vector2 movement = RavenInput.move;

        Vector3 direction=new Vector3(movement.x,0f,movement.y);
        transform.position += direction * speed * Time.deltaTime;
        Debug.Log(movement);
    }
    private void ActionsGame()
    {
        if (RavenInput.SprintHeld)
        {
            Sprint();
        }
        if (RavenInput.DefendHeld)
        {
            Defend();
        }
    }
    private void Jump()
    {
        Debug.Log("saltando");
    }
    private void Attack()
    {
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
    private void Defend()
    {
        Debug.Log("Defender");
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
