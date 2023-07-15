using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float _yBound = 10f;
    private Transform _playerTransform;
    private float angle;
    private Vector2 _directionToTarget;
    private Quaternion _rotation;

    private void Start()
    {
        _playerTransform = GameManager.Instance.playerObject.GetComponent<Transform>();
    }

    private void Update()
    {
        if (GameManager.Instance.gameState == GameStates.play)
        {
            _directionToTarget = (_playerTransform.position - transform.position);
            angle = Mathf.Atan2(_directionToTarget.y, _directionToTarget.x) * Mathf.Rad2Deg;
            _rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = _rotation;

            if (Mathf.Abs(transform.position.y) > _yBound)
                gameObject.SetActive(false);
        }
    }
}
