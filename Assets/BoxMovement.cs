using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public GameObject Player;

    public int obstacleSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(0,0,1) * obstacleSpeed * Time.deltaTime;
        transform.Translate(dir.x, dir.y, dir.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == Player.name)
        {
            transform.Translate(3, 2, 4);
        }
    }
}
