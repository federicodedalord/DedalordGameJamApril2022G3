using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb2d;
    private bool _jumping = false;
    private RaycastHit2D rayHit;

    private bool PressingSpace;

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 200, 20), "Jumping: " + _jumping.ToString());
        GUI.Label(new Rect(0, 20, 200, 100), "PressingSpace: " + PressingSpace);
    }

    private void Update()
    {
        PressingSpace = Input.GetKey(KeyCode.Space);

        Debug.DrawRay(transform.position, Vector2.down * 0.4f, Color.magenta);

        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.down, 0.4f);
        if (!PressingSpace && rayHit.collider != null)
        {
            _jumping = false;
        }
        else if (PressingSpace && !_jumping)
        {
            _rb2d.velocity = new Vector2(0, 6f);
        }
    }
}
