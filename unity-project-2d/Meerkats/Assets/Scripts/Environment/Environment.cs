using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour {
    // currently mainly to:
    //  - pooling manager for food
    //      - spawns up to MAX_FOOD_SPOTS gameobjects
    //      - when a food is consumed it goes back here

    [SerializeField]
    private GameObject foodPrefab;

    [SerializeField]
    private int MAX_FOOD_SPOTS;     // maximum number of foods spawned on the map
    private int currently_spawned_food = 0;
    private int total_spawned_food = 0;

    [SerializeField]
    private Vector2 MAX_POS;    // food will be spawned between -MAX_POS and MAX_POS

    private Stack<GameObject> dead_food;

    private void Awake() {
        dead_food = new Stack<GameObject>(MAX_FOOD_SPOTS);
    }

    public void pool_food(Food food)
    {
        currently_spawned_food--;

        // todo - deactivate obj, put it in dead_food
    }

    private void spawn_food()
    {
        GameObject go;
        if(total_spawned_food == MAX_FOOD_SPOTS)
        {
            // todo - check the pool

            // todo - if empty don't spawn
            // todo - else spawn a food in a random pos
            // go = dead_food.Pop
        }
        else
        {
            // todo - instantiate new food obj
            
        }
    }

}