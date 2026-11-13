using UnityEngine;

[CreateAssetMenu(fileName = "RunStateSO", menuName = "Meerkat States/Run State")]
public class RunStateSO : StateSO
{
    [SerializeField] private float speed = 5f;

    private void OnEnable()
    {
        _state = new M_Run(speed);
    }
}