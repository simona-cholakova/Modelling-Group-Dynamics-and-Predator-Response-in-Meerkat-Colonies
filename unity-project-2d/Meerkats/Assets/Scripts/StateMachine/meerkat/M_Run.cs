using UnityEngine;

class M_Run : MState
{
    private readonly float speed;

    public M_Run(float speed)
    {
        name = "Run";
        this.speed = speed;
    }

    protected override void onEnter(Entity entity) { }

    protected override void onUpdate(Entity entity)
    {
        Meerkat meerkat = entity as Meerkat;
        if (meerkat == null) return;

        // direction pointing from the threat to the meerkat = "away"
        Vector3 away = entity.transform.position - meerkat.threatPosition;
        away.z = 0;
        entity.velocityVector = away.normalized * speed;
    }

    protected override void onExit(Entity entity)
    {
        entity.velocityVector = Vector3.zero;
    }
}