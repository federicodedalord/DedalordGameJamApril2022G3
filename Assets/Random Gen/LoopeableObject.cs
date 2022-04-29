using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopeableObject : MonoBehaviour
{
    public TerrainLooper father = null;
    public bool isSpawned = false;
    private Vector2 newPos = Vector2.zero;

    public void SetFather(TerrainLooper trLooper)
    {
        if(father == null)
        {
            father = trLooper;
        }
    }

    public void Spawn(Vector2 _newpos)
    {
        isSpawned = true;
        newPos = _newpos;
    }

    public void Despawn()
    {
        if(father != null)
        {
            father.Spawn(newPos);
        }
        Destroy(gameObject);
    }
}
