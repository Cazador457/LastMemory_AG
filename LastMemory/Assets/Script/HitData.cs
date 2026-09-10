using UnityEngine;

public class HitData : MonoBehaviour
{
    public float Damage;
    public float Knockback;
    public Vector3 Direction;
    public Vector3 HitPoint;
    public GameObject Attacker;
    public HitData(float damage, float knockback, Vector3 direction, Vector3 hitPoint, GameObject attacker)
    {
        Damage = damage;
        Knockback = knockback;
        Direction = direction;
        HitPoint = hitPoint;
        Attacker = attacker;
    }
}
