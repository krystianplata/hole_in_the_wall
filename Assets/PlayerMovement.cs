using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerSpeed;
    public int xSentitivity;
    public int ySentitivity;
    public GameObject ui_plane;
    private Rigidbody rigidbody;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ui_plane.activeSelf)
        {
            return;
        }

        if (isMoving)
        {
            rigidbody.freezeRotation = true;
            Vector3 dir = Input.gyro.rotationRate * playerSpeed * Time.deltaTime;
            // transform.Translate(dir.y * xSentitivity * -1, dir.x * ySentitivity, 0);
            Vector3 dir2 = new Vector3(dir.y * xSentitivity * -1, dir.x * ySentitivity, 0);
            rigidbody.velocity = dir2 * 100;
        }
        isMoving = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.parent.gameObject.name == "Bounds")
        {
            isMoving = false;
        }
    }
}
