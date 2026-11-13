using System.Collections.Generic;
using UnityEngine;


public class Meerkat : Entity
{

    // CALL variables
    [SerializeField]
    private CallManager callManager;
    private Queue<Call> callQueue;
    private Queue<Call> _processedCloseCalls;
    public Queue<Call> processedCloseCalls {get {return _processedCloseCalls; }}
    private int[] callsHeard;
    private float[] callLastTime;
    [SerializeField]
    [Tooltip("For how long (seconds) to memorize certain calls")]
    private float callMemory = 20;      // for how long (seconds) to memorize certain calls
    // todo - can make above a different length for every call



    [SerializeField]
    [Tooltip("For how long (seconds) to wait until giving a call")]
    private float callCooldown = 10;      // for how long (seconds) to memorize certain calls
    // todo - above is def not a fixed value
    

    private float _lastCallTime = 0f;

    // END CALL variables


    // Food variables
    [SerializeField]
    [Tooltip("When digging for food, how big is the area that is checked for food")]
    private float digRadius = 1f;
    [SerializeField]
    [Tooltip("Patience when foraging, how many unsuccessfull attempts until it gives a move call, to get the group to move to another spot. Should be at least 1.")]
    private int _foragingPatience;
    // todo - maybe model above with a float and some function?

    private float _failedDigs;
    public float failedDigs {get {return _failedDigs;} set {_failedDigs = value; }}
    // * public version should be used by foraging state


    private float _lastDigTime;
    public float timeSinceLastDig {get {return Time.time - _lastDigTime; }}

    public bool tryMoveCall {get {return _failedDigs >= _foragingPatience; }}
    // END Food variables
    
    // Predator variables
    private Vector3 _threatPosition;
    public Vector3 threatPosition {get {return _threatPosition; }}   // where the predator is
    
    // below is set to true when predator is seen
    private bool _inDanger;
    public bool inDanger {get {return _inDanger;}}

    // todo - set like a stress variable, like for how long to run from predator's last seen position, even after predator is not visible
    // END Predator variables


    private readonly int foodLayer = 8;

    public void receiveCall(Call call)
    {
        callQueue.Enqueue(call);
    }

    private void Awake() {
        
    }
    private void Start() {
        callManager.addMeerkat(this);
        callQueue = new Queue<Call>(callManager.MaxQueueSize);
        _processedCloseCalls = new Queue<Call>(callManager.MaxQueueSize);
        callsHeard = new int[Call.numberOfCalls];
        callLastTime = new float[Call.numberOfCalls];
    }

    public int getNumberOfCallsHeard(CT type)
    {
        // ! NOTE - CURRENTLY THE NUMBER OF CLOSE CALLS HEARD IS NOT STORED
        // ? SINCE IT'S CURRENLTY USED TO CALCULATE AN AVG POSITION
        // get number of calls a meerkat has heard recently of a specific call type 
        return callsHeard[(int) type];
    }


    // CALL PROCESSING METHODS

    private void processCalls()
    {
        // * - process call queue
        // * at most 10 calls
        // todo - think of above

        Call call;
        int cnt = 0;
        while(callQueue.Count > 0 && cnt < 10)
        {
            call = callQueue.Dequeue();
            processCall(call);
            cnt++;
        }
        
    }
    private void processCall(Call call)
    {

        int i = (int) call.type;

        if(call.type != CT.closeCall) {
            // for non close calls just remember how many and when the last was heard
            callsHeard[i]++;
            callLastTime[i] = Time.time;
            return;
        }

        int n = Mathf.Max(_processedCloseCalls.Count, callManager.MaxQueueSize);
        if(n == callManager.MaxQueueSize)
        {
            _processedCloseCalls.Dequeue();
        }
        _processedCloseCalls.Enqueue(call);
    }

    private void ForgetCalls()
    {
        float now = Time.time;
        for(int i=0; i<callsHeard.Length; i++)
        {
            if(now - callLastTime[i] > callMemory)
            {
                callsHeard[i] = 0;
            }
        }
    }

    public bool MakeCall(Call call)
    {
        // ? this method is so that the states can make a call
        float now = Time.time;
        if(now - _lastCallTime < callCooldown) return false;

        callManager.sendCall(call);
        _lastCallTime = now;

        return true;
    }
    // END CALL PROCESSING METHODS

     // Food methods
    public void Dig()
    {
        // * - cast a collider at current spot
        Collider2D hit = Physics2D.OverlapCircle(transform.position, digRadius, foodLayer);

        // * - if any food is hit, consume it
        if(hit != null)
        {
            // ? not checking if below is null, since above collision is cast on foodLayer only
            Food food = hit.GetComponent<Food>();
            food.Consume();
            _failedDigs = 0;

            // todo - energy gained and stuff - 2nd progress report
        }else _failedDigs++;

        _lastDigTime = Time.time;

    }
    // END Food methods
    public override void RecalculateView()
    {
        base.RecalculateView();
        _inDanger = CanSee(predatorInfo.predator);

        if (_inDanger){
            _threatPosition = predatorInfo.position;
        }else{
            _threatPosition = Vector3.zero;
        }
    }
    // Vision methods

    // END Vision methods

    void OnEnable()
    {
        meerkatsInfo.Add(this);
    }
    void OnDisable()
    {
        meerkatsInfo.Remove(this);
    }

    protected override void Update()
    {
        processCalls();

        base.Update();

        //  - forget calls heard over time
        ForgetCalls();
        // todo - how to implement above regarding close calls
    }
}