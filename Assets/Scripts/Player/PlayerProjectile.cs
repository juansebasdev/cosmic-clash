using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _yBound = 10f;

    private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.y) > _yBound)
            gameObject.SetActive(false);
    }
}
