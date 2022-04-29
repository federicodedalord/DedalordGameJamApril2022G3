using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum MovementType { Falling, Sliding }
    public MovementType movement;

    [SerializeField] private Rigidbody2D _rb2d;

    private bool OnSpace;
    private bool SpaceUp;
    private bool SpaceWithGround;
    private bool IsGrounded;
    private bool CanJump;
    private bool StopJump;
    private float _xInput;

    private bool TouchingLeftWall;
    private bool TouchingRightWall;

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _extraJumpDistance;

    private float _sustainProgress;

    public bool CanPlay = true;

    public float SustainProgress
    {
        get { return _sustainProgress; }
        set
        {
            _sustainProgress = value;
            GameManager.Instance.SustainSlider.value = _sustainProgress;
        }
    }

    public MovementType Movement { get => movement; set => movement = value; }


    private void OnGUI()
    {
        GUI.Label(new Rect(0, 20, 200, 40), "CanJump: " + CanJump);
        GUI.Label(new Rect(0, 40, 200, 40), "Horizontal Speed: " + _xInput);
        GUI.Label(new Rect(0, 60, 200, 40), "SpaceWithGround: " + SpaceWithGround);
        GUI.Label(new Rect(0, 80, 200, 40), "IsGrounded: " + IsGrounded);
        GUI.Label(new Rect(0, 100, 200, 40), "OnSpace: " + OnSpace);
        GUI.Label(new Rect(0, 120, 200, 40), "StopJump: " + StopJump);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            SustainProgress += collision.gameObject.GetComponent<PowerUp>().Sustain;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("ParedIzquierda"))
        {
            TouchingLeftWall = true;
        }
        if (collision.gameObject.CompareTag("ParedDerecha"))
        {
            TouchingRightWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ParedIzquierda"))
        {

            TouchingLeftWall = false;
        }
        if (collision.gameObject.CompareTag("ParedDerecha"))
        {
            TouchingRightWall = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ParedIzquierda"))
        {
            if (TouchingLeftWall == false)
            {
                TouchingLeftWall = true;
            }
        }
        if (collision.gameObject.CompareTag("ParedDerecha"))
        {
            if (TouchingRightWall == false)
            {
                TouchingRightWall = true;
            }
        }
    }


    private void Update()
    {
        if (!CanPlay)
        {
            _rb2d.velocity = Vector2.zero;
            return;
        }

        switch (Movement)
        {
            case MovementType.Falling:
                FallingMovement();
                break;
            case MovementType.Sliding:
                SliderMovement();
                break;
            default:
                break;
        }
    }

    private void SliderMovement() {
        _rb2d.isKinematic = false;

        // Debug
        Debug.DrawRay(transform.position, Vector2.down * _extraJumpDistance, Color.magenta);

        // Conditionals
        OnSpace = Input.GetKey(KeyCode.Space);
        SpaceUp = Input.GetKeyUp(KeyCode.Space);
        CanJump = Physics2D.Raycast(transform.position, Vector2.down, _extraJumpDistance) && SpaceWithGround;

        // Jump
        if (OnSpace)
        {
            if (IsGrounded)
            {
                StopJump = false;
                SpaceWithGround = true;
                IsGrounded = false;
            }

            if (!Physics2D.Raycast(transform.position, Vector2.down, _extraJumpDistance))
            {
                StopJump = true;
            }

            if (CanJump && !StopJump)
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

    private void FallingMovement()
    {
        _rb2d.isKinematic = true;
        _xInput = Input.GetAxis("Horizontal");


        if (TouchingLeftWall && _xInput < 0)
        {
            _xInput = 1;
        }

        if (TouchingRightWall && _xInput > 0)
        {
            _xInput = -1;
        }

        _rb2d.velocity = Vector2.right * _xInput * _horizontalSpeed;
    }
}
