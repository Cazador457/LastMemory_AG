using UnityEngine;

public class CheasingState : IState
{
    public Enemy enemy;
    public CheasingState(Enemy enemy)
    {
        this.enemy = enemy;
    }
    public void Enter()
    {
        Debug.Log("Cheasing State ON");
    }
    public void Update()
    {
        float distance = Vector2.Distance(enemy.player.transform.position, enemy.enemy.position);
        if (enemy.player == null) return;
        if (distance < enemy.combatDistance)
        {
            enemy.ChangeState(new AttackState(enemy));
        }

        if (enemy.health <= 0f)
        {
            enemy.ChangeState(new DeathState(enemy));
        }
    }
    public void Exit()
    {
        Debug.Log("Cheasing State OFF");
    }
}
