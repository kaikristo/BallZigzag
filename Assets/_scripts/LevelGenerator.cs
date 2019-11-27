
using System;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;

    [SerializeField]
    GameObject startPoint;
    [SerializeField]
    GameObject tilePrefab;


  
    private GameObject prev;


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

    internal void ClearLevel()
    {

        foreach (GameObject tile in GameObject.FindGameObjectsWithTag("Tile"))
            Destroy(tile);
    }

 
    public void GenerateStartField()
    {
        for (int x = 0; x < 3; x++)
            for (int z = 0; z < 3; z++)
            {
                GameObject tile = Instantiate(tilePrefab, startPoint.transform);
                tile.transform.localPosition = new Vector3(x - 1, 0, z - 1);
                tile.GetComponent<Tile>().CanHaveGem = false;
                if (x == 1 && z == 2) prev = tile;
            }
    }
    public void GenerateNext()
    {
        Direction direction = (Direction)UnityEngine.Random.Range(0, 2);
        GameObject newTile = null;
        switch (direction)
        {
            case Direction.Forward:
                
                    newTile = Instantiate(tilePrefab);
                    newTile.transform.localPosition = prev.transform.position + new Vector3(0, 0, 1);
                    prev = newTile;

                    break;
                
            case Direction.Rigth:
                
                    newTile = Instantiate(tilePrefab);
                    newTile.transform.localPosition = prev.transform.position + new Vector3(1, 0, 0);
                    prev = newTile;
                    break;
                
            default:
                break;
            
        }
        newTile.GetComponent<Tile>().CanHaveGem = true;


    }
}


