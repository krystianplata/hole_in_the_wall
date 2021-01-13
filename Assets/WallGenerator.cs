using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WallGenerator : MonoBehaviour
{
    public Vector3 SpawnPoint;
    public Vector3 SpawnRotation;
    public GameObject UI;
    public GameObject Player;
    public TMP_Text ScoreLabel;

    public float ObstacleSpeed;
    public float ObstacleSpeedGain;

    private List<GameObject> walls = new List<GameObject>();

    private GameObject activeWall = null;
    private BoxMovement activeScript = null;
    private int currentScore = 0;
    private int highestScore = 0;

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
                ScoreLabel.SetText(" " + highestScore.ToString());
                currentScore = 0;
                UI.SetActive(true);
                activeWall = null;
            }
            else 
            {
                currentScore++;
                highestScore = currentScore > highestScore ? currentScore : highestScore;
                activeWall = null;
                SpawnRandomWall();
            }
        }
    }

    void SpawnRandomWall()
    {
        activeWall = Instantiate(walls[Random.Range(0, walls.Count)]) as GameObject;

        activeWall.AddComponent<MeshCollider>();
        activeScript = activeWall.AddComponent<BoxMovement>();
        activeScript.Player = Player;
        activeScript.ObstacleSpeed = ObstacleSpeed;

        activeWall.transform.position = SpawnPoint;
        activeWall.transform.eulerAngles = SpawnRotation;

        ObstacleSpeed += ObstacleSpeed * ObstacleSpeedGain;
    }

    void ClearWall()
    {
        Destroy(activeWall);
        activeWall = null;
        activeScript = null;
    }
}
