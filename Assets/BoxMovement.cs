using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public GameObject Player = null;
    public float ObstacleSpeed = 1.0f;

    private bool collisionDetected = false;

    void Update()
    {
        if (gameObject.transform.position.z >= -0.5)
        {
            Vector3 dir = new Vector3(0, 0, -1) * ObstacleSpeed * Time.deltaTime;
            transform.Translate(dir.x, dir.y, dir.z);
        }
        else {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    { 
        if(collision.gameObject.name == Player.name)
        { 
            gameObject.SetActive(false);
            collisionDetected = true;
        }
    }

    public bool HasCollided()
    { 
        return collisionDetected;
    }
}
