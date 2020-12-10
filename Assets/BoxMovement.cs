using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public GameObject Player;
    public GameObject UI;

    public int obstacleSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (UI.activeSelf) return;
        Vector3 dir = new Vector3(-1,0,0) * obstacleSpeed * Time.deltaTime;
        transform.Translate(dir.x, dir.y, dir.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == Player.name)
        {
            transform.Translate(10, 0, 0);
            // Revert to UI state
            UI.SetActive(true);
        }
    }
}
