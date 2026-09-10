using UnityEngine;
using static UnityEngine.Analytics.IAnalytic;

public class DamageGetter : MonoBehaviour
{
    [SerializeField] private float health = 100f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void TakeHit(HitData hit)
    {
        ApplyDamage(hit.Damage);
        ApplyKnockback(hit);
    }

    private void ApplyDamage(float damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            Die();
        }
    }

    private void ApplyKnockback(HitData hit)
    {
        if (rb == null)
            return;

        rb.AddForce(
            hit.Direction * hit.Knockback,
            ForceMode.Impulse
        );
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} murió.");
    }
}
