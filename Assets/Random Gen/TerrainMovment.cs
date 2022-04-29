using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMovement : MonoBehaviour
{
    public float vel = 10.0f;
    public Vector2 direction = Vector2.zero;

    void Update()
    {
        Vector2 moveDir = direction * vel * Time.deltaTime;
        transform.Translate(moveDir);
    }
}
