using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    public GameObject Tile1;
    public GameObject Tile2;
    public GameObject Tile3; // New prefab
    public GameObject StartTile;

    private float Index = 0;

    private void Start()
    {
        GenerateStartTiles();
    }

    private void Update()
    {
        MoveGenerator();

        if (transform.position.x >= Index)
        {
            GenerateNewTiles();
            Index += 31.9f;
        }
    }

    private void GenerateStartTiles()
    {
        InstantiateStartTile(new Vector3(7, 0, 0));
        InstantiateStartTile(new Vector3(-1, 0, 0));
        InstantiateStartTile(new Vector3(-9, 0, 0));
        InstantiateStartTile(new Vector3(-17, 0, 0));
        InstantiateStartTile(new Vector3(-25, 0, 0));
    }

    private void InstantiateStartTile(Vector3 position)
    {
        GameObject startPlane = Instantiate(StartTile, transform);
        startPlane.transform.position = position;
    }

    private void MoveGenerator()
    {
        gameObject.transform.position += new Vector3(4 * Time.deltaTime, 0, 0);
    }

    private void GenerateNewTiles()
    {
        int randomInt1 = Random.Range(0, 3); 
        InstantiateTile(randomInt1, new Vector3(-32, 0, 0));

        int randomInt2 = Random.Range(0, 3); 
        InstantiateTile(randomInt2, new Vector3(-48, 0, 0));
    }

    private void InstantiateTile(int randomInt, Vector3 position)
    {
        GameObject tempTile;
        if (randomInt == 0)
        {
            tempTile = Instantiate(Tile1, transform);
        }
        else if (randomInt == 1)
        {
            tempTile = Instantiate(Tile2, transform);
        }
        else
        {
            tempTile = Instantiate(Tile3, transform); 
        }
        tempTile.transform.position = position;

        Destroy(tempTile, 15f);
    }
}
