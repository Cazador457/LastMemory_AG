using UnityEngine;
using UnityEngine.InputSystem;

public class Combat : MonoBehaviour
{
    private RavenInputActions _Input;
    private Vector2 _MoveInput;
    private void Awake()
    {
        _Input = new RavenInputActions();
    }
    private void OnEnable()
    {
        _Input.Rav.Enable();
        _Input.Rav.Jump.performed += Context => Jumping();
    }
    private void OnDisable()
    {
        _Input.Rav.Enable();
        _Input.Rav.Jump.performed -= Context => Jumping();
    }
    private void Update()
    {
        _MoveInput = _Input.Rav.Move.ReadValue<Vector2>();
        Movement(_MoveInput);
    }
    private void Movement(Vector2 direccion)
    {
        transform.Translate(new Vector3(direccion.x, 0, direccion.y) * Time.deltaTime * 5f);
        Debug.Log("Moviendo");
    }
    private void Jumping()
    {
        Debug.Log("Saltando");
    }
}
