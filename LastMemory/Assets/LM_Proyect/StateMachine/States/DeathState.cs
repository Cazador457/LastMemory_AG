using UnityEngine;

public class DeathState : IState
{
    public Enemy enemy;
    public DeathState(Enemy enemy)
    {
        this.enemy = enemy;
    }
    public void Enter()
    {
        Debug.Log("Death State ON");
    }
    public void Update()
    {

    }
    public void Exit()
    {
        Debug.Log("Death State OFF");
    }
}
