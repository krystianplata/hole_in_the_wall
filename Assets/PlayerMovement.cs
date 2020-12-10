using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int playerSpeed;
    public int xSentitivity;
    public int ySentitivity;
    // Start is called before the first frame update
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Input.gyro.rotationRate * playerSpeed * Time.deltaTime;
        transform.Translate(dir.y * xSentitivity * -1, dir.x * ySentitivity, 0);
    }
}
