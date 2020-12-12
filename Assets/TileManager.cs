using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject tilePrefab;

    private Transform playerTransform;
    private int tileLength = 2;
    private int amountOfTileCircles = 100;
    private int spawnZ = 0;
    private Color[] tileColors;
    private float colorIntensity = 0.5f;
    private List<GameObject> allTiles = new List<GameObject>();

    private int changeColorsFrequency = 30;
    private int numberOfTilesToChange = 300;
    private int currentFrame = 0;

    // Start is called before the first frame update
    void Start()
    {
        tileColors = new[]
        {
            new Color(colorIntensity, 0, colorIntensity),
            new Color(0, 0, colorIntensity),
            new Color(colorIntensity, 0, 0),
            new Color(colorIntensity, 0.92f * colorIntensity, 0.016f * colorIntensity),
        };

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (var i = 0; i < amountOfTileCircles; i++)
        {
            SpawnCircle();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFrame < changeColorsFrequency)
            currentFrame++;
        else
        {
            currentFrame = 0;
            for (var i = 0; i < numberOfTilesToChange; i++)
                SetRandomColor(allTiles[Random.Range(0, allTiles.Count)]);
        }
    }

    void SpawnCircle()
    {
        for (var i = 0; i < 36; i++)
        {
            SpawnTile(spawnZ, i * 10);
        }

        spawnZ += tileLength;
    }

    void SpawnTile(int z, int rotation)
    {
        var gameObject = Instantiate(tilePrefab);
        gameObject.transform.SetParent(transform);
        gameObject.transform.position = Vector3.forward * z;
        gameObject.transform.rotation = Quaternion.AngleAxis(rotation, Vector3.forward);

        SetRandomColor(gameObject);

        allTiles.Add(gameObject);
    }

    void SetRandomColor(GameObject tile)
    {
        var material = tile.GetComponent<Renderer>().material;
        var color = tileColors[Random.Range(0, 4)];
        material.color = color;
        material.SetColor("_EmissionColor", color);
    }
}
