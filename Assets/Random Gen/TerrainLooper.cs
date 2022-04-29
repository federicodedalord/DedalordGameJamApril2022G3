using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainLooper : MonoBehaviour
{
    public GameObject terrainParent;
    public GameObject[] terrains;
    public Vector2[] spawnPos;

    private void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        if (terrains != null && terrains.Length > 0)
        {
            for (int i = 0; i < terrains.Length; i++)
            {
                GameObject go = Instantiate(terrains[i], spawnPos[i], Quaternion.identity);
                go.transform.parent = terrainParent.transform;
                LoopeableObject lo = go.GetComponent<LoopeableObject>();
                if (lo != null)
                {
                    lo.SetFather(GetComponent<TerrainLooper>());
                    lo.Spawn(spawnPos[spawnPos.Length - 1]);
                }
            }
        }
    }

    public void Spawn(Vector2 pos)
    {
        if (terrains != null && terrains.Length > 0)
        {
            GameObject go = Instantiate(terrains[0], pos, Quaternion.identity);
            go.transform.parent = terrainParent.transform;
            LoopeableObject lo = go.GetComponent<LoopeableObject>();
            if (lo != null)
            {
                lo.SetFather(GetComponent<TerrainLooper>());
                lo.Spawn(pos);
            }
        }
    }

    public void Recycle(LoopeableObject lo)
    {
        lo.Despawn();
    }
}
