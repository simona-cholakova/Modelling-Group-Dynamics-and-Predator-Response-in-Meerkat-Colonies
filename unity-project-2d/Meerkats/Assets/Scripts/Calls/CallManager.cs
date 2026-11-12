using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CallManager", menuName = "ScriptableObjects/Meerkat Call Manager")]
public class CallManager : ScriptableObject {
    // class for managing call comunication between meerkats
    //  - when meerkats send out calls
    //  - when meerkats receive calls
    
    [SerializeField]
    private int _maxQueueSize=30;
    public int MaxQueueSize {get {return _maxQueueSize;}} 

    private List<Meerkat> meerkats = new List<Meerkat>();   // list of all the meerkats

    private void Awake() {
    }

    public void sendCall(Call call)
    {
        foreach (Meerkat meerkat in meerkats)
        {
            // todo - limit call to meerkats who are close enough
            // todo - meerkat receives call when sound propagates to it, not instantly when the call is given
            meerkat.receiveCall(call);
        }
    }

    public void addMeerkat(Meerkat meerkat)
    {
        meerkats.Add(meerkat);
    }
}