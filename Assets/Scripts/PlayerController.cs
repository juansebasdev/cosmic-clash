using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _horizontalInput;
    private float _verticalInput;
    private PlayerStates _playerState;

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
        }
    }
}
