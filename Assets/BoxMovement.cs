using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public GameObject Player = null;
    public int ObstacleSpeed = 1;

    private bool collisionDetected = false;

    void Update()
    {
        if (gameObject.transform.position.z >= -1)
        {
            Vector3 dir = new Vector3(-1, 0, 0) * ObstacleSpeed * Time.deltaTime;
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
