using UnityEngine;

public class Food : MonoBehaviour {
// to more easily detect food by colliding
// ie when meerkat tries to dig for food it will cast a circle-collider or something
// if it hits this then it consumes the food
// and this food gameobject will be gone back to environment pooling manager
    

    private Environment manager;

    public void SetManager(Environment e)
    {
        manager = e;
    }

    public void Consume()
    {
        manager.pool_food(this);
    }
}