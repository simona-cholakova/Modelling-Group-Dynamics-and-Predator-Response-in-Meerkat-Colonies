using UnityEngine;

[CreateAssetMenu(fileName = "PredatorInfo", menuName = "Info Singletons/Predator Info", order = 0)]
public class PredatorInfo : ScriptableObject {

    private Predator _predator;
    public Predator predator {get {return _predator;} set{_predator = value;}}

    public Vector3 position {get {return _predator == null ? Vector3.zero : _predator.transform.position; }}
    
}