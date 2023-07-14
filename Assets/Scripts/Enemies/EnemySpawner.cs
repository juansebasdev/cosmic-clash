using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] protected int _numOfEnemies;
    private int _idx;

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

    public void SpawnEnemies(Vector2 startPosition)
    {
        _idx = Random.Range(0, _enemyPrefabs.Count);
        for (int i = 0; i < _numOfEnemies; ++i)
        {
            GameObject enemyObject = Instantiate(_enemyPrefabs[_idx], Vector3.zero, _enemyPrefabs[_idx].transform.rotation);
            enemyObject.transform.SetParent(transform);
            enemyObject.transform.position = startPosition;
        }
    }
}
