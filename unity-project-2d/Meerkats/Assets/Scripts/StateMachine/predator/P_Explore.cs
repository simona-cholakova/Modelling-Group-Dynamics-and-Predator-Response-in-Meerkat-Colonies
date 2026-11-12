using UnityEngine;


public class P_Explore : MState
{

    private float speed;
    private float lastTurnTime;
    private float maxTurn;

    private Vector3 currentDirection;

    private float turnCooldown; // how long to wait before doing a random turn (not too drastic)

    public P_Explore(float speed, float maxTurn, float turnCooldown)
    {
        this.speed = speed;
        this.maxTurn = maxTurn;
        this.turnCooldown = turnCooldown;
    }
    protected override void onEnter(Entity entity)
    {
        lastTurnTime = 0f;
    }

    protected override void onExit(Entity entity)
    {
        entity.velocityVector = Vector3.zero;
    }

    protected override void onUpdate(Entity entity)
    {
        if(entity is not Predator p) return;

        float now = Time.time;
        if(now - lastTurnTime > turnCooldown)
        {
            float randomAngle = Random.Range(-maxTurn, maxTurn);
            currentDirection = new Vector3(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle), 0f);
            p.velocityVector = speed * currentDirection;
        }
        // setting velocity vector in the if block
        // since if it doesn't change direction why re-set it again


    }
}