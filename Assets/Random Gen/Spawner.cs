using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obj;
    public Transform ObjFather;
    
    [Header("Spawn Time")]
    public float SpawnTimeMax = 10.0f;
    public float SpawnTimeMin = 5.0f;
    
    [Header("Spawn Position")]
    public Vector2 maxSpawnPos = Vector2.zero;
    public Vector2 minSpawnPos = Vector2.zero;

    private void Start()
    {
        StartCoroutine("Spawn");
    }

    private IEnumerator Spawn()
    {
        float waitTime = Random.Range(SpawnTimeMin, SpawnTimeMax);
        Vector2 spawnpos = new Vector2(Random.Range(minSpawnPos.x, maxSpawnPos.x), Random.Range(minSpawnPos.y, maxSpawnPos.y));
        GameObject go = Instantiate(obj, spawnpos, transform.rotation, ObjFather);
        yield return new WaitForSeconds(waitTime);
        StartCoroutine("Spawn");
    }
}
