using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public RavenInputActions RavenInput;

    public CharacterController playerController;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void Moviment()
    {
        Vector2 moviment = RavenInput.move;
        Debug.Log(moviment);
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }
}
