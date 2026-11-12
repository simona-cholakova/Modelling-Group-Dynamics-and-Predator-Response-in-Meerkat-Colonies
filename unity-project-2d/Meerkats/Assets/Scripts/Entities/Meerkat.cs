using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Meerkat : Entity
{

    [SerializeField]
    private CallManager callManager;
    private Queue<Call> callQueue;
    private Queue<Call> processedCloseCalls;
    private int[] callsHeard;
    private float[] callLastTime;

    private Vector3 _avgCCPos;    // avg position of close call pos
    public Vector3 averageCloseCallPos {get {return _avgCCPos; }}

    [SerializeField]
    [Tooltip("For how long (seconds) to memorize certain calls")]
    private float callMemory = 20;      // for how long (seconds) to memorize certain calls
    // todo - can make above a different length for every call



    public void receiveCall(Call call)
    {
        callQueue.Enqueue(call);
    }

    private void Start() {
        callManager.addMeerkat(this);
        callQueue = new Queue<Call>(callManager.MaxQueueSize);
        processedCloseCalls = new Queue<Call>(callManager.MaxQueueSize);
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

        int n = Mathf.Max(processedCloseCalls.Count, callManager.MaxQueueSize);
        if(n == callManager.MaxQueueSize)
        {
            Call lastCall = processedCloseCalls.Dequeue();
            _avgCCPos -= 1/n * lastCall.pos;
        }
        else
        {
            _avgCCPos = n/(n+1) * _avgCCPos;
        }
        _avgCCPos += 1/(n+1) * call.pos;
        processedCloseCalls.Enqueue(call);
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
    // CALL PROCESSING METHODS


    protected override void Update()
    {
        processCalls();

        base.Update();

        // todo - forget calls heard over time
        ForgetCalls();
    }
}