using UnityEngine;

[CreateAssetMenu(fileName = "ChaseStateSO", menuName = "Predator States/Chase State")]
public class P_ChaseSO : StateSO
{
    [SerializeField]
    [Tooltip("The speed with which the predator chases a prey. Should be ~2x faster than normal. Normal can be taken as the speed when exploring")]
    private float speed = 5f;

    private void OnEnable()
    {
        if(_state == null)
        {
            _state = new P_Chase(speed);
        }
    }
}