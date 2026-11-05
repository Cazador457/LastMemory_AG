using UnityEngine;

public class IdleState : IState
{
    private Enemy enemy;
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
        if (enemy.player == null) return;
        
        if (enemy.health <= 0f)
            enemy.ChangeState(new DeathState(enemy));

        float distance = Vector3.Distance(enemy.player.position, enemy.transform.position);

        if (distance<enemy.cheasingDistance)
            enemy.ChangeState(new CheasingState(enemy));
    }
    public void Exit()
    {
        Debug.Log("Idle State OFF");
    }
}
