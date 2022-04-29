using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    public string Objtag = "Floor";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Objtag)
        {
            //Debug.Log("Detectado maquinola");
            Destroy(collision.gameObject);
        }
    }
}
