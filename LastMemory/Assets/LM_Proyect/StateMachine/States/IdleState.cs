using UnityEngine;

public class IdleState : IState
{
    public Enemy enemy;
    public IdleState(Enemy enemy)
    {
        this.enemy = enemy;
    }
    public void Enter()
    {
        Debug.Log("Idle State ON");
    }
    public void Update()
    {
        float distance = Vector2.Distance(enemy.player.transform.position, enemy.enemy.position);
        if (enemy.player == null) return;
        if (distance<enemy.cheasingDistance)
        {
            enemy.ChangeState(new CheasingState(enemy));
        }
        if (enemy.health <= 0f)
        {
            enemy.ChangeState(new DeathState(enemy));
        }
        else
        {

        }
    }
    public void Exit()
    {
        Debug.Log("Idle State OFF");
    }
}
