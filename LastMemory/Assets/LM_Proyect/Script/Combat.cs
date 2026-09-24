using UnityEngine;
using UnityEngine.InputSystem;

public class Combat : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] private float damage = 25f;
    [SerializeField] private float knockback = 10f;

    private Collider hitCollider;
    private GameObject attacker;

    private void Awake()
    {
        hitCollider = GetComponent<Collider>();

        hitCollider.enabled = false;
    }

    public void Initialize(GameObject owner)
    {
        attacker = owner;
    }

    public void EnableHitbox()
    {
        hitCollider.enabled = true;
    }

    public void DisableHitbox()
    {
        hitCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageGetter receiver =
            other.GetComponent<DamageGetter>();

        if (receiver == null)
            return;

        Vector3 direction = attacker.transform.forward;

        HitData hit = new HitData(
            damage,
            knockback,
            direction,
            other.ClosestPoint(transform.position),
            attacker
        );

        receiver.TakeHit(hit);
    }


}
