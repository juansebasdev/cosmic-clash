using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private float _enemyXRange;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        StartCoroutine(InstatiateEnemies());
    }

    private IEnumerator InstatiateEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);
            Vector2 enemyPos = new Vector2(Random.Range(-_enemyXRange, _enemyXRange), 4);
            EnemySpawner.Instance.SpawnEnemies(enemyPos);
        }
    }
}
