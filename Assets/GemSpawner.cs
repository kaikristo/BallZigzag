using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public static GemSpawner instance;


    [SerializeField]
    GameObject gemPrefab;
    [SerializeField]
    [Range(0, 100)]
    int gemSpawnChance;

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

    public void SpawnGem(Transform position)
    {
        Instantiate(gemPrefab, position);
    }
    public void TryToSpawn(Transform position)
    {
        bool gem = UnityEngine.Random.Range(0, 100) > (100-gemSpawnChance) ? true : false;
        if (gem) SpawnGem(position);
    }

}
