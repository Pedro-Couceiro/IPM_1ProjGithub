using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidB;

    private bool _jumpCommand;
    private bool _leftCommand;
    private bool _rightCommand;
    [SerializeField] private bool _isGrounded;
    private bool _endJump;
    private bool _canAirJump;
    [SerializeField] private bool _doubleJumpenabled;

    [Header("Valores")]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [SerializeField] private GameObject _groundTestlineStart;
    [SerializeField] private GameObject _groundTestlineEnd;

    private Animator _animator;

    void Start()
    {
        _rigidB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            _leftCommand = true;
        }

        if(Input.GetKey(KeyCode.D))
        {
            _rightCommand = true;
        }

        if(Input.GetKey(KeyCode.W))
        {
            _jumpCommand = true;
        }

        if(Input.GetKeyUp(KeyCode.W))
        {
            _canAirJump = true;

            _doubleJumpenabled = true;
        }
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.Linecast(_groundTestlineStart.transform.position, _groundTestlineEnd.transform.position);

        if(_leftCommand)
        {
            _rigidB.velocity = new Vector2(-_speed, _rigidB.velocity.y);
            _leftCommand = false;
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
        }

        if(_rightCommand)
        {
            _rigidB.velocity = new Vector2(_speed, _rigidB.velocity.y);
            _rightCommand = false;
            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
        }

        if(_endJump)
        {
            Vector2 v = new Vector2(_rigidB.velocity.x, _rigidB.velocity.y / 2.0f);
            _rigidB.velocity = v;
            _endJump = false;
        }

        if(_jumpCommand && _isGrounded)
        {
            _rigidB.velocity = new Vector2(_rigidB.velocity.x, _jumpForce);
            _jumpCommand = false;

            _canAirJump = true;
            _doubleJumpenabled = true;
        }

        if(_doubleJumpenabled && _jumpCommand && !_isGrounded && _canAirJump && _rigidB.velocity.y < 0)
        {
            _rigidB.velocity = new Vector2(_rigidB.velocity.x, _jumpForce);
            _jumpCommand = false;
            _canAirJump = false;
            _doubleJumpenabled = false;
        }
    }

}
