using UnityEngine;


public class M_Foraging : MState
{

    // below are for keeping spacing between itself and other meerkats
    // so that it's neither too close nor too far
    private float repulse_f, attract_f, close_limit, far_limit;


    // below is so that it does some random movement exploring
    private float maxTurn;  // maximum angle in which a meerkat changes direction
    private float explore_f;    // force for heading in the direction decided by current + above angle

    public M_Foraging(float explore_f, float maxTurn, float repulse_f, float attract_f, float close_limit, float far_limit)
    {
        this.explore_f = explore_f;
        this.maxTurn = maxTurn;

        this.repulse_f = repulse_f;
        this.attract_f = attract_f;
        this.close_limit = close_limit;
        this.far_limit = far_limit;
    }

    protected override void onEnter(Entity entity)
    {
        
    }

    protected override void onExit(Entity entity)
    {
        
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
    }
}