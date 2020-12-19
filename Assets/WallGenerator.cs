using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{

    // Public: script for collisions & material

    public Vector3 spawnPoint;
    public Vector3 spawnRotation = new Vector3(-90.0f, 0.0f, -90.0f);
    public GameObject UI;

    private List<GameObject> walls = new List<GameObject>();
    private GameObject activeWall = null;

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
        if (!activeWall && !UI.activeSelf)
        {
            SpawnRandomWall();
        }
    }

    void SpawnRandomWall()
    {
        activeWall = Instantiate(walls[0]) as GameObject;
        activeWall.transform.position = spawnPoint;
        activeWall.transform.eulerAngles = spawnRotation;
    }

    void ClearUsedWall()
    {
        // Add a delete for the game object
        activeWall = null;
    }
}
