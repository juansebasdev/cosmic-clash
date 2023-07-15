using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (GameManager.Instance.gameState == GameStates.play)
        {
            transform.Translate(Vector2.down * _speed * Time.deltaTime);
        }
    }
}
