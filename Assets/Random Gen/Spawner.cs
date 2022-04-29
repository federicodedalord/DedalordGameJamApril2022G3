using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obj;
    public Transform ObjFather;
    public float SpawnTimeMax = 10.0f;
    public float SpawnTimeMin = 5.0f;

    private void Start()
    {
        StartCoroutine("Spawn");
    }

    private IEnumerator Spawn()
    {
        float waitTime = Random.Range(SpawnTimeMin, SpawnTimeMax);
        GameObject go = Instantiate(obj, transform.position, transform.rotation, ObjFather);
        yield return new WaitForSeconds(waitTime);
        StartCoroutine("Spawn");
    }
}
