using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _yBound = 10f;
    private Transform _playerTransform;
    private float _moveInX;
    private float _moveInY;
    private Vector2 _directionToTarget;
    private bool _hasFired;

    private void Start()
    {
        _playerTransform = GameManager.Instance.playerObject.GetComponent<Transform>();
        _hasFired = false;
    }

    private void Update()
    {
        if (GameManager.Instance.gameState == GameStates.play)
        {
            if (!_hasFired)
            {
                _directionToTarget = _playerTransform.position - transform.position;
                _hasFired = true;
            }

            _directionToTarget.Normalize();
            _moveInX = _directionToTarget.x * _speed * Time.deltaTime;
            _moveInY = _directionToTarget.y * _speed / 2 * Time.deltaTime;
            transform.Translate(_moveInX, _moveInY, 0);

            if (Mathf.Abs(transform.position.y) > _yBound)
                gameObject.SetActive(false);
        }
    }
}
