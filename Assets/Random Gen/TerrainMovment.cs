using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovment : MonoBehaviour
{
    public float vel = 10.0f;
    public Vector2 direction = Vector2.zero;
    public LoopeableObject loopObjRef;

    void Start()
    {
        loopObjRef = GetComponent<LoopeableObject>();
    }


    void Update()
    {
        if(loopObjRef != null && loopObjRef.isSpawned)
        {
            Vector2 moveDir = direction * vel * Time.deltaTime;
            transform.Translate(moveDir);
        }
    }
}
