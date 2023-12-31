using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _yBound = 10f;

    private void Update()
    {
        if (GameManager.Instance.gameState == GameStates.play)
        {
            transform.Translate(Vector2.up * _speed * Time.deltaTime);

            if (Mathf.Abs(transform.position.y) > _yBound)
                gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Damage"))
        {
            SFXManager.Instance.PlayHit();
            GameManager.Instance.IncreasePlayerScore(other.gameObject.GetComponent<IHasPoints>().points);
            Destroy(other.gameObject);
        }
    }
}
