using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private List<GameObject> activeTiles;
    public GameObject[] tilePrefabs;

    public float tileLength = 30;
    public int numberOfTiles = 3;
    public int totalNumOfTiles = 5;

    public float zSpawn = 0;

    private Transform playerTransform;

    private int previousIndex;

    void Start()
    {
        activeTiles = new List<GameObject>();
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            else
                SpawnTile(Random.Range(0, tilePrefabs.Length));
           
        }

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Update()
    {
        if (playerTransform.position.z - 35 >= zSpawn - (numberOfTiles * tileLength))
        {
            /*int index = Random.Range(0, tilePrefabs.Length);
            while (index == previousIndex)
                index = Random.Range(0, tilePrefabs.Length);
*/          SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();

        }

    }

    public void SpawnTile(int tileIndex)//int index = 0)
    {
        
        GameObject tile = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        // if (tile.activeInHierarchy)
        //     tile = tilePrefabs[index + 8];

        // if(tile.activeInHierarchy)
        //     tile = tilePrefabs[index + 16];

        // tile.transform.position = Vector3.forward * zSpawn;
        // tile.transform.rotation = Quaternion.identity;
        // tile.SetActive(true);

        activeTiles.Add(tile);
         zSpawn += tileLength;
        // previousIndex = index;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        //activeTiles[0].SetActive(false);
        activeTiles.RemoveAt(0);
        //PlayerManager.score += 3;
    }
}
