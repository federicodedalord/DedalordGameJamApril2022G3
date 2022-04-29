using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTriggerDetector : MonoBehaviour
{
    public string terrainTag = "Floor";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == terrainTag) { 
            //Debug.Log("Detectado maquinola");
            LoopeableObject lo = collision.transform.gameObject.GetComponent<LoopeableObject>();
            if (lo != null)
            {
                lo.Despawn();
            }
            else
            {
                Debug.LogError("LO ES NULL");
            }
        }
    }
}
