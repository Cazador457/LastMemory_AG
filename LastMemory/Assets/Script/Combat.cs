using UnityEngine;
using UnityEngine.InputSystem;

public class Combat : MonoBehaviour
{
    //
    private RavenInputActions inputActions;

    //
    public float damage = 5;
    public float speed = 5;
    public float defence = 9;
    public int nockBack = 2;

    private void Awake()
    {
        inputActions = new RavenInputActions();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnEnable()
    {
        inputActions.Enable();
        //inputActions.Player.Jump.performed += OnJump;
    }
    private void OnDisable()
    {
        inputActions.Disable();
        //inputActions.Player.Jump.performed -= OnJump;
    }
    //public void Jump()

}
