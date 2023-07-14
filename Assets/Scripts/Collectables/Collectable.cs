using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour, IHasPoints
{
    [SerializeField] private int _points;
    [SerializeField] private float _speed;
    [SerializeField] private float _yBound = 10;

    public int points { get => _points; private set => points = _points; }

    private void Update()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.y) > _yBound)
            gameObject.SetActive(false);
    }
}
