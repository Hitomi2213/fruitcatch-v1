using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collide)
    {

        if (collide.gameObject.name == "Floor" || collide.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }

    }
   
}

