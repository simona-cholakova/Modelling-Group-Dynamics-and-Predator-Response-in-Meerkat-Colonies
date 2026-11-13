using UnityEngine;

public class Predator : Entity{
    
    [SerializeField]
    [Tooltip("How much hunger (%, 0-1) is decreased per minute.")]
    private float hungerDeterioration = 0.2f;

    private float _hunger;
    public float hunger {get {return _hunger; }}


    private bool _preySpotted;
    public bool preySpotted {get {return _preySpotted; }}

    private Vector3 _preyPos;
    public Vector3 preyPos {get {return _preyPos; }}

    // Vision methods
    public override void RecalculateView()
    {
        base.RecalculateView();
        // ? above currently does nothing, but don't know if I might change in the future
        // so leaving it for now
        int prey = SetVisibleEntities(meerkatsInfo.meerkats);
        if(prey > 0)
        {
            _preySpotted = true;
            // choose a random prey to chase
            _preyPos = visibleEntities[Random.Range(0, visibleEntities.Count)].transform.position;
        }
    }
    // Vision methods


    private void OnEnable() {
        if(predatorInfo != null)
        {
            predatorInfo.predator = this;
        }
    }

    void OnDisable()
    {
        if(predatorInfo != null)
        {
            predatorInfo.predator = null;
        }
    }


    void Start()
    {
        
    }
    protected override void Update()
    {
        base.Update();
        _hunger -= hungerDeterioration * Time.deltaTime / 60;
    }
}