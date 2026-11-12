using UnityEngine;

public class Predator : Entity{
    
    [SerializeField]
    [Tooltip("How much hunger (%, 0-1) is decreased per minute.")]
    private float hungerDeterioration = 0.2f;
    
    private float _hunger;
    public float hunger {get {return _hunger; }}


    protected override void Update()
    {
        base.Update();
        _hunger -= hungerDeterioration * Time.deltaTime / 60;
    }
}