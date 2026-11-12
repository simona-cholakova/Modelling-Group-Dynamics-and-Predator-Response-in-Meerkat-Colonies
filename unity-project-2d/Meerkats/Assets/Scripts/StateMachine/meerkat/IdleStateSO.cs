using UnityEngine;

[CreateAssetMenu(fileName = "IdleStateSO", menuName = "Scriptable Objects/Meerkat/Idle State")]
public class IdleStateSO : StateSO
{
    private void OnEnable()
    {
        _state = new M_Idle();
    }
}