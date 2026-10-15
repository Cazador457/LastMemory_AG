using UnityEngine;
using System;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "EnemyStats")]
public class EnemyData : ScriptableObject
{
    [Header("Enemy Information")]
    [SerializeField] private string _id;
    [SerializeField] private string _description;

    [Header("Enemy Stats")]
    [SerializeField] private int _damage;
    [SerializeField] private float _health;
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private int _chasingRate;
    [SerializeField] private int _attackRate;
    [SerializeField] private int _cooldownAttack;

    public string ID => _id;
    public string Description => _description;
    public int Damage => _damage;
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public float Speed => _speed;
    public float MaxSpeed => _maxSpeed;
    public int ChasingRate => _chasingRate;
    public int AttackRate => _attackRate;
    public int CooldownAttack => _cooldownAttack;
}
