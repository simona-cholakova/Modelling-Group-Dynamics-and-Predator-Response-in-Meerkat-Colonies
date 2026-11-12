using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{
    // stuff every entity should have
    public Vector3 velocityVector;  // for moving/applying forces to entity from scripts
    // ! if there are possible race conditions on velocityVector, consider how to implement safe locking s.t everything is applied correctly


    [SerializeField]
    protected float _health;
    public float Health { get {return _health; }}

    [SerializeField]
    private float _maxHealth = 100f;
    public float maxHealth { get {return _maxHealth; }}

    [SerializeField]
    private StateSO initialState;
    private StateMachine stateMachine;

    public void DealDamage(float damage)
    {
        // Debug.Log(this.name + " attacked");
        // Debug.Log("Health before: " + _health);
        // Debug.Log("Damage of attack: " + damage);
        if (damage >= _health) 
        { 
            _health = 0;
            // todo - death handling
        }
        else
        {
            _health -= damage;
        }
        // Debug.Log("Health after: " + _health);
    }
    
    void Awake()
    {
        stateMachine = new StateMachine(initialState);   
    }

    private void Update() {
        stateMachine.Update(this);
        this.transform.position += (velocityVector * Time.deltaTime);
    }

}
