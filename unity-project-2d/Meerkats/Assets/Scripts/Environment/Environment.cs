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
    private float MAX_X, MAX_Y;    // food will be spawned between -MAX_X and +MAX_X, same for y

    private Stack<GameObject> dead_food;

    private void Awake() {
        dead_food = new Stack<GameObject>(MAX_FOOD_SPOTS);
    }

    public void poolFood(Food food)
    {
        currently_spawned_food--;

        // - deactivate obj, put it in dead_food
        food.gameObject.SetActive(false);
        dead_food.Push(food.gameObject);
    }

    private void spawnFood()
    {
        GameObject go;
        if(total_spawned_food == MAX_FOOD_SPOTS)
        {
            // - check the pool
            // - if empty don't spawn
            // - else spawn a food in a random pos
            if(dead_food.Count == 0){
                return;
            }
            else
            {
                go = dead_food.Pop();
            }   
        }
        else
        {
            // - instantiate new food obj
            go = Instantiate(foodPrefab);
            go.GetComponent<Food>().SetManager(this); //without it, the first time a meerkat eats food -error, because Food doesn’t know its manager
            total_spawned_food++;
        }
        currently_spawned_food++;
        
        float x = Random.Range(-MAX_X, MAX_X);
        float y = Random.Range(-MAX_Y, MAX_Y);
        go.transform.position = new Vector3(x, y, -5);
        go.SetActive(true);
    }

    void Update()
    {
        while (currently_spawned_food < MAX_FOOD_SPOTS)
        {
            spawnFood();
        }
    }
}