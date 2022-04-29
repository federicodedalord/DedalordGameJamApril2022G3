using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb2d;

    private bool OnSpace;
    private bool SpaceUp;
    private bool SpaceWithGround;
    private bool IsGrounded;
    private bool CanJump;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _extraJump;

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 200, 40), "OnSpace: " + OnSpace);
        GUI.Label(new Rect(0, 20, 200, 40), "CanJump: " + CanJump);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            if (IsGrounded == false)
            {
                IsGrounded = true;
            }
        }
    }


    private void Update()
    {
        // Debug
        Debug.DrawRay(transform.position, Vector2.down * _extraJump, Color.magenta);

        // Conditionals
        OnSpace = Input.GetKey(KeyCode.Space);
        SpaceUp = Input.GetKeyUp(KeyCode.Space);
        CanJump = Physics2D.Raycast(transform.position, Vector2.down, _extraJump) && SpaceWithGround;

        // Jump
        if (OnSpace)
        {
            if (IsGrounded)
            {
                SpaceWithGround = true;
                IsGrounded = false;
            }
            if (CanJump)
            {
                _rb2d.velocity = Vector2.up * _jumpForce;
            }
        }
        else
        {
            CanJump = false; 
        }

        if (SpaceWithGround & SpaceUp)
        {
            SpaceWithGround = false;
        }
    }
}
