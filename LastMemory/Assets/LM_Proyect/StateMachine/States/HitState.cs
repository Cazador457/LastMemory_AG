using UnityEngine;

public class HitState : IState
{
    public Enemy enemy;
    public HitState(Enemy enemy)
    {
        this.enemy = enemy;
    }
    public void Enter()
    {
        Debug.Log("Hit State ON");
    }
    public void Update()
    {
        if (enemy.health <= 0f)
        {
            enemy.ChangeState(new DeathState(enemy));
        }
    }
    public void Exit()
    {
        Debug.Log("Hit State OFF");
    }
}
