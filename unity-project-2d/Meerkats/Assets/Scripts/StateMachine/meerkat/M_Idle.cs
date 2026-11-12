using UnityEngine;

class M_Idle : MState
{
    public M_Idle()
    {
        name = "Idle";
    }

    protected override void onEnter(Entity entity)
    {
        entity.velocityVector = Vector3.zero;
    }

    protected override void onUpdate(Entity entity) { }

    protected override void onExit(Entity entity) { }
}