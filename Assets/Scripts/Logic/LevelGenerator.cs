using System;
using System.Collections.Generic;
using KaiKristo.Shooter.Logic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;

    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject tilePrefab;
    [Range(0, 1)] [SerializeField] private float gemSpawnChance;

    private GameObject prevTile;
    private List<Tile> tileMap = new List<Tile>();

    private void Awake()
    {
        if (instance != null)
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        prevTile = startPoint;
    }

    internal void ClearLevel()
    {
        for (int i = 0; i < tileMap.Count; i++)
        {
            Destroy(tileMap[i].gameObject);
            tileMap.RemoveAt(i);
        }
    }


    public void GenerateStartField()
    {
        for (int x = 0; x < 3; x++)
        for (int z = 0; z < 3; z++)
        {
            GameObject startTile = CreateTile(startPoint.transform.position + new Vector3(x, 0, z));
            //000
            //000 <--from here we start generate level
            //000
            if (x == 1 && z == 2)
            {
                prevTile = startTile;
            }
        }
    }

    public void GenerateNext()
    {
        Direction direction = (Direction) UnityEngine.Random.Range(0, 2);
        GameObject newTile;
        switch (direction)
        {
            case Direction.Forward:
                newTile = Instantiate(tilePrefab);
                newTile.transform.localPosition = prevTile.transform.position + new Vector3(0, 0, 1);
                prevTile = newTile;
                break;
            case Direction.Rigth:
                newTile = Instantiate(tilePrefab);
                newTile.transform.localPosition = prevTile.transform.position + new Vector3(1, 0, 0);
                prevTile = newTile;
                break;
        }
    }

    private GameObject CreateTile(Vector3 position, bool canHaveObject = false, float objectChance = 0, ObjectOnTileType objectType = ObjectOnTileType.Other)
    {
        GameObject tile = Instantiate(tilePrefab);
        tile.transform.localPosition = position;
        tileMap.Add(tile.GetComponent<Tile>());
        if (canHaveObject && objectChance > .0f)
        {
            switch (objectType)
            {
                case ObjectOnTileType.Gem: break;
                case ObjectOnTileType.Other: break;
            }
        }

        return tile;
    }
}