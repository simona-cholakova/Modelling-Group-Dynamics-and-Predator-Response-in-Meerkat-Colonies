using UnityEngine;


public class M_Foraging : MState
{

    // below are for keeping spacing between itself and other meerkats
    // so that it's neither too close nor too far
    private float repulse_f, attract_f, close_limit, far_limit;


    // below is so that it does some random movement exploring
    private float maxTurn;  // maximum angle in which a meerkat changes direction
    private float explore_f;    // force for heading in the direction decided by current + above angle

    private float dig_cooldown;     // how much time to pass until it tries to dig again
    // todo - use some tricks so that it doesn't try to dig in the same spot
    // todo - with above may also need to change how exploration is implemented
    public M_Foraging(float explore_f, float maxTurn, float repulse_f, float attract_f, float close_limit, float far_limit, float dig_cooldown)
    {
        this.explore_f = explore_f;
        this.maxTurn = maxTurn;

        this.repulse_f = repulse_f;
        this.attract_f = attract_f;
        this.close_limit = close_limit;
        this.far_limit = far_limit;

        this.dig_cooldown = dig_cooldown;
    }

    protected override void onEnter(Entity entity)
    {
        if(entity is not Meerkat m) return; 
        m.failedDigs = 0;
        // reset failed dig counter for foraging patience
        // related to how long to try until giving up
        // and moving to another location
    }

    protected override void onExit(Entity entity)
    {
        entity.velocityVector = Vector3.zero;
    }

    protected override void onUpdate(Entity entity)
    {
        if(entity is not Meerkat m)return;

        Vector3 current = m.transform.position;

        Vector3 output_force = Vector3.zero;
        foreach (Call call in m.processedCloseCalls)
        {
            Vector3 diff = current - call.pos;
            float distance = new Vector2(diff.x, diff.y).magnitude;

            if(distance < close_limit)
            {
                // * - repulsive force from too close meerkats
                output_force += repulse_f * diff.normalized;
                
            } else if (distance > far_limit)
            {
                // * - attractive force towards too far meerkats
                output_force -= attract_f * diff.normalized;
            }
            // ? anything else ignore
        }

        // * - force for some random exploration
        float randomAngle = Random.Range(-maxTurn, maxTurn);
        Vector3 explore_direction = new Vector3(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle), 0);
        output_force += explore_f * explore_direction;
        output_force.z = 0; // since in 2d
        // all meerkats should have same z, but just in case
        m.velocityVector = output_force;

        // todo - digging
        // todo - some random probability that a meerkat will start digging
        // todo - should grow with the time spent since last digging or start of foraging
        if(m.timeSinceLastDig >= dig_cooldown && Random.Range(0f, 1f) < 0.8f)
        {
            // the random is so that it doesn't automatically dig whenever possible
            // though 80% is so that it doesn't wait too much
            m.Dig();
            // todo - make the meerkat stationary for a few secs while it digs
        }

        if (m.tryMoveCall)
        {
                m.MakeCall(new Call(CT.movingCall, Vector3.zero, Vector3.zero));
            // 0 vectors since this call is used just for transitioning to another state
        }
    }
}