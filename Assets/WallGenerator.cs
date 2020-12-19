using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public Vector3 SpawnPoint;
    public Vector3 SpawnRotation;
    public GameObject UI;
    public GameObject Player;
    public int ObstacleSpeed;

    private List<GameObject> walls = new List<GameObject>();

    private GameObject activeWall = null;
    private BoxMovement activeScript = null;

    void Start()
    {
        Object[] prefabs = Resources.LoadAll("Walls");
        foreach (var prefab in prefabs)
        {
            if (prefab is GameObject) {
                walls.Add(prefab as GameObject);
            }
        }
    }

    void Update()
    {
        if (activeWall == null && !UI.activeSelf)
        {
            SpawnRandomWall();
        }
        else if (activeWall != null && !activeWall.activeSelf)
        {
            if (activeScript.HasCollided())
            {
                UI.SetActive(true);
                activeWall = null;
            }
            else 
            {
                activeWall = null;
                SpawnRandomWall();
            }
        }
    }

    void SpawnRandomWall()
    {
        activeWall = Instantiate(walls[0]) as GameObject;

        activeWall.AddComponent<MeshCollider>();
        activeScript = activeWall.AddComponent<BoxMovement>();
        activeScript.Player = Player;
        activeScript.ObstacleSpeed = ObstacleSpeed;

        activeWall.transform.position = SpawnPoint;
        activeWall.transform.eulerAngles = SpawnRotation;
    }

    void ClearWall()
    {
        Destroy(activeWall);
        activeWall = null;
        activeScript = null;
    }
}
