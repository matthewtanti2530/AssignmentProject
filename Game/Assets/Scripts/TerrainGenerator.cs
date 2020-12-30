﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{

    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<GameObject> terrains = new List<GameObject>();

    private List<GameObject> currentTerrains = new List<GameObject>();
    private Vector3 currentPosition = new Vector3(0, 0, 0);

    private void Start() 
    {
        for(int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            SpawnTerrain();
        }
    }

    private void SpawnTerrain()
    {
            GameObject terrain = Instantiate(terrains[Random.Range(0, terrains.Count-1)], currentPosition, Quaternion.identity);
            currentTerrains.Add(terrain);
            if(currentTerrains.Count > maxTerrainCount)
            {
                Destroy(currentTerrains[0]);
                currentTerrains.RemoveAt(0);
            }
            currentPosition.x++;
    }
}
