using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject ally;
    public Vector3 spawnValues;

    void Start()
    {
        SpawnWaves();
    }

    void SpawnWaves()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(ally, spawnPosition, spawnRotation);
    }
}