using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("State Machine")]
    private StateMachine stateMachine;

    public GameObject player;
    public Transform enemy;
    public float maxVelocity = 5f;
    public float cooldownAttack;
    public float cheasingDistance;
    public float combatDistance;
    public string _currentStateName = "";

    public Material baseMaterial;
    public Material HitMaterial;

    public float health;
    public float damage;
    public float speed;

    
    void Start()
    {
        stateMachine = new StateMachine();
        ChangeState(new IdleState(this));
        var target = FindAnyObjectByType<PlayerController>(FindObjectsInactive.Include);
        player = target.gameObject;
        enemy = GetComponent<Transform>();
    }

    void Update()
    {
        stateMachine.Update();
        _currentStateName = stateMachine.CurrentState != null ? stateMachine.CurrentState.GetType().Name : "Sin Estado";
    }

    public void ChangeState(IState newState)
    {
        stateMachine.ChangeState(newState);
    }
    public virtual void OnEnable()
    {

    }
}
