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

    public void Spawn(Transform position)
    {
        Instantiate(gemPrefab, position);
    }

}
