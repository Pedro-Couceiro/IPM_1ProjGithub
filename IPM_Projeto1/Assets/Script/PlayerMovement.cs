using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidB;

    [Header("Bools")]
    private bool _jumpCommand;
    private bool _leftCommand;
    private bool _rightCommand;
    [SerializeField] private bool _isGrounded;
    private bool _jumpEnded;
    private bool _canDoubleJump;
    [SerializeField] private bool _doubleJumpEnabled;
    private bool _canJump;
    private bool _bombDeploy;

    [Header("Valores")]
    [SerializeField] float _jumpPower;
    [SerializeField] float _runSpeed;
    [SerializeField] private float _jumpBufferTime;
    [SerializeField] private float _coyoteTime;
    private float _jumpCommandTime;
    private float _groundTime;

    [Header("GameObjects")]
    [SerializeField] private GameObject _groundTestLineStart;
    [SerializeField] private GameObject _groundTestLineEnd;
    [SerializeField] private GameObject _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _bombPrefab;

    private Animator _animator;

    void Start()
    {
        _rigidB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _leftCommand = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _rightCommand = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpCommand = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _jumpEnded = true;
            _jumpCommandTime = Time.unscaledTime;
            _canDoubleJump = true;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            GameObject bullet = Instantiate(_bulletPrefab, _firePoint.transform.position, Quaternion.identity);

            if (transform.localScale.x < 0)
            {
                bullet.GetComponent<PlayerProjectile>().Reverse();
            }
        }

    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.Linecast(_groundTestLineEnd.transform.position, _groundTestLineStart.transform.position);

        if (_isGrounded)
        {
            _groundTime = Time.unscaledTime;
            _canJump = true;

        }
        else
        {
            if (Time.unscaledTime - _groundTime > _coyoteTime)
            {
                _canJump = false;
            }
        }

        if (_leftCommand)
        {
            _rigidB.velocity = new Vector2(-_runSpeed, _rigidB.velocity.y);
            _leftCommand = false;
            Vector3 scale = transform.localScale;
            scale.x = -1;
            transform.localScale = scale;
        }

        else if (_rightCommand)
        {
            _rigidB.velocity = new Vector2(_runSpeed, _rigidB.velocity.y);
            _rightCommand = false;
            Vector3 scale = transform.localScale;
            scale.x = 1;
            transform.localScale = scale;
        }


        if (_jumpEnded)
        {
            Vector2 v = new Vector2(_rigidB.velocity.x, _rigidB.velocity.y / 2.0f);
            _rigidB.velocity = v;
            _jumpEnded = false;
        }

        if (_jumpCommand && _canJump && Time.unscaledTime - _jumpCommandTime < _jumpBufferTime)
        {
            _rigidB.velocity = new Vector2(_rigidB.velocity.x, _jumpPower);
            _jumpCommand = false;

            _canDoubleJump = true;
            _doubleJumpEnabled = true;
        }

        if (_doubleJumpEnabled && _jumpCommand && !_isGrounded && _canDoubleJump && _rigidB.velocity.y < 0)
        {
            _rigidB.velocity = new Vector2(_rigidB.velocity.x, _jumpPower);
            _jumpCommand = false;
            _canDoubleJump = false;
            _doubleJumpEnabled = false;
        }

    }

}
