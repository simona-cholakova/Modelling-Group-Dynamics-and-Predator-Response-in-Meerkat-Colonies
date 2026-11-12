using UnityEngine;

[CreateAssetMenu(fileName = "ExploreStateSO", menuName = "Predator States/Explore State")]
public class P_ExploreSO : StateSO
{
    [SerializeField] 
    private float speed = 2.5f;

    [SerializeField]
    [Tooltip("How much to turn when exploring (in radians). 0.35 ~ 20 degrees. I think any more than this and it will erratically change directions.")]
    private float maxTurn = 0.35f;


    [SerializeField]
    [Tooltip("How much to wait until doing a random turn depending on Max Turn variable.")]
    private float turnCooldown = 3f;


    

    private void OnEnable()
    {
        if(_state == null)
        {
            _state = new P_Explore(speed, maxTurn, turnCooldown);
        }
    }
}