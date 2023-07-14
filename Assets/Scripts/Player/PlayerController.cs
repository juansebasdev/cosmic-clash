using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IShooter
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _xBound = 10.5f;
    [SerializeField] private float _yBound = 4.5f;
    private float _horizontalInput;
    private float _verticalInput;
    private PlayerStates _playerState;
    private bool _isLeft = true;

    private void Start()
    {
        _playerState = PlayerStates.alive;
    }

    private void Update()
    {
        if (_playerState == PlayerStates.alive)
        {
            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");

            transform.Translate(_horizontalInput * _speed * Time.deltaTime, _verticalInput * _speed * Time.deltaTime, 0);

            // Limit the space of movement in both X and Y axis
            ConstraintMovement();

            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }

    private void ConstraintMovement()
    {
        if (transform.position.y > _yBound)
            transform.position = new Vector2(transform.position.x, _yBound);
        if (transform.position.y < -_yBound)
            transform.position = new Vector2(transform.position.x, -_yBound);
        if (transform.position.x > _xBound)
            transform.position = new Vector2(_xBound, transform.position.y);
        if (transform.position.x < -_xBound)
            transform.position = new Vector2(-_xBound, transform.position.y);

    }

    public void Shoot()
    {
        GameObject projectile = ProjectilePooler.Instance.GetPreloadObject();
        if (projectile != null)
        {
            projectile.SetActive(true);
            if (_isLeft)
                projectile.transform.position = transform.position + Vector3.left * 0.6f;
            else
                projectile.transform.position = transform.position + Vector3.right * 0.6f;

            _isLeft = !_isLeft;
        }
    }
}
