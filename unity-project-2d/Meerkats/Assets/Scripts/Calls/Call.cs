using UnityEngine;

class Call
{
    
    readonly public CallType type;
    readonly public Vector3 pos;
    readonly public Vector3 direction;

    public Call(CallType type, Vector3 pos, Vector3 direction)
    {
        this.type = type;
        this.pos = pos;
        this.direction = direction;
    }
}

enum CallType
{
    closeCall,
    movingCall,
    foragingCall,
    runCall,
    recruitCall,
    recruitMobCall,

}