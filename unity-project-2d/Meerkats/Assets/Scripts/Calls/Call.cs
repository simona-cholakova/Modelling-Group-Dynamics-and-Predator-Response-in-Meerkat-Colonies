using UnityEngine;

public class Call
{
    readonly public static int numberOfCalls = 6;
    readonly public CT type;
    readonly public Vector3 pos;
    readonly public Vector3 direction;

    public Call(CT type, Vector3 pos, Vector3 direction)
    {
        this.type = type;
        this.pos = pos;
        this.direction = direction;
    }
}

public enum CT
{
    closeCall,
    movingCall,
    foragingCall,
    runCall,
    recruitCall,
    recruitMobCall,

}