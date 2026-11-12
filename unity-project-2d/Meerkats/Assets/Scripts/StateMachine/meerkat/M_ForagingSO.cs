

using UnityEngine;

[CreateAssetMenu(fileName = "ForagingStateSO", menuName = "Meerkat States/Foraging State")]
public class M_ForagingSO : StateSO {

    [SerializeField]
    [Tooltip("How much is too close for spacing with other meerkats")]
    private float closeLimit = 2;

    
    [SerializeField]
    [Tooltip("How much is too far for spacing with other meerkats")]
    private float farLimit = 10;

    
    [SerializeField]
    [Tooltip("How strong is the repulsive force when too close to other meerkats")]
    private float repulsiveForce = 1;

    
    [SerializeField]
    [Tooltip("How strong is the attractive force when too far from other meerkats")]
    private float attractiveForce = 1.5f;


    [SerializeField]
    [Tooltip("How strong is the exploring force, force for just wandering about")]
    private float exploringForce = 0.5f;


    [SerializeField]
    [Tooltip("How much to turn at most when exploring, note 0.35 ~ 20 degrees")]
    private float maxTurn = 0.35f;

    

    

    private void Awake() {
        if(_state == null)
        {
            _state = new M_Foraging(exploringForce,  maxTurn, repulsiveForce, attractiveForce, closeLimit, farLimit);
        }
    }
}