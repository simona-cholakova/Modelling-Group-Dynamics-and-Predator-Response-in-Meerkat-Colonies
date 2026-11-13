using System.Collections.Generic;
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

    // Vision variables
    [SerializeField]
    [Tooltip("How far can this entity see")]
    private float viewRadius;
    
    
    [SerializeField]
    [Tooltip("How wide (angle in radians) can this entity see. Change this depedning if it's meerkat, predator, ...\nNote that meerkats have nearly 360 degrees width of vision.")]
    protected float viewAngle = 1.5f;

    
    private Vector2 forward {get {return transform.right; }}
    // ? above is forward direction for 2D, depending on entity rotation
    
    protected List<Entity> visibleEntities;


    [SerializeField]
    [Tooltip("How long to wait (seconds) before its vision should be recalculated, ie to recalculate what it sees. ")]
    protected float viewRecalculation = 1f;
    protected float lastViewRecalc;
    // END Vision variables

    // Info Singleton variables
    // public variable for getting info for easy communication with other entities
    [SerializeField]
    protected PredatorInfo predatorInfo = default;
    [SerializeField]
    protected MeerkatsInfo meerkatsInfo = default;
    // END Info Singleton variables

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


    // Vision methods
    public bool CanSee(Entity entity)
    {
        // whether another entity is visible in the vision of this one
        // the vision of entity is defined as a cone
        // with radius and width of angle
        Vector2 otherPos = entity.transform.position;
        Vector2 toTarget = otherPos - forward;

        // check if target is not that far, within the enitity's vision radius
        // using squares since it's faster than computing square root
        if (toTarget.sqrMagnitude > viewRadius * viewRadius) return false;

        // check if target is within the entity's cone
        // ie it's not behind it, wrt what the entity sees
        // times 0.5f since it's half of the angle to the left and half of the angle to the right
        if (Vector2.Angle(forward, toTarget) > viewAngle * 0.5f) return false;

        // todo - add line raycasting, when you add visual blocks

        return true;
    }

    public int SetVisibleEntities(IEnumerable<Entity> entities)
    {
        // ! note that this method will be mainly used for the predator to see what meerkats it can see
        // ? and for now it will be called once every second, not every frame

        // ! meanwhile meerkats will only use above method, while working under the assumption there is only 1 predator

        // todo - optimize it so that it doesn't create a new list every time

        // from the array, list, any collection
        // add the visible ones
        visibleEntities = new List<Entity>();
        foreach(Entity e in entities)
        {
            if (CanSee(e))
            {
                visibleEntities.Add(e);
            }
        }

        return visibleEntities.Count;
    }

    protected void OnDrawGizmosSelected()
    {
        // below is for drawing the vision cone
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRadius);


        Vector3 left = Quaternion.Euler(0, 0, viewAngle * 0.5f) * forward;
        Vector3 right = Quaternion.Euler(0, 0, -viewAngle * 0.5f) * forward;
        Gizmos.DrawRay(transform.position, left * viewRadius);
        Gizmos.DrawRay(transform.position, right * viewRadius);
    }

    public virtual void RecalculateView()
    {
        // ? this method should be overriden by inheriting classes
        // ? the method is public in case some state needs to trigger a view recalc
    }
    // Vision methods

    protected virtual void Update() {
        if(Time.time - lastViewRecalc > viewRecalculation)
        {
            RecalculateView();
            lastViewRecalc = Time.time;
        }
        stateMachine.Update(this);
        this.transform.position += (velocityVector * Time.deltaTime);
    }

}
