using UnityEngine;

public class AttackState : IState
{
    public Enemy enemy;
    public AttackState(Enemy enemy)
    {
        this.enemy = enemy;
    }
    public void Enter()
    {
        Debug.Log("Attack State ON");
    }
    public void Update()
    {
        float distance = Vector2.Distance(enemy.player.transform.position, enemy.enemy.position);
        if (enemy.player == null) return;
        if (distance > enemy.combatDistance)
        {
            enemy.ChangeState(new CheasingState(enemy));
        }
    }
    public void Exit()
    {
        Debug.Log("Attack State OFF");
    }
}
