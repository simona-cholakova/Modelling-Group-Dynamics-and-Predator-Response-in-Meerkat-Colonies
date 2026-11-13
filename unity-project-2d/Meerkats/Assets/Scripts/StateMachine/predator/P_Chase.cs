using UnityEngine;


public class P_Chase : MState
{
    // todo - transition to explore state if hunger >= 0.5, ie >= 50%
    // todo - or any other value, can set that in the transition SO

    // todo - if no meerkat is visible, transition to explore state

    private float speed;

    public P_Chase(float speed)
    {
        this.speed = speed;
    }

    protected override void onEnter(Entity entity)
    {
        
    }

    protected override void onExit(Entity entity)
    {
        
    }

    protected override void onUpdate(Entity entity)
    {
        if(entity is not Predator p) return;
        if(!p.preySpotted) return;  // should transition out of this state if this is false
        // returning on above, since preypos is not valid
        // could possibly be zero vector which doesn't make sense
        // better to just explore
        // maybe save last pos of prey and once reached, explore randomly

        // go toward last spotted pos of prey
        Vector2 dir = p.preyPos - p.transform.position;
        p.velocityVector = speed * dir;
    }
}