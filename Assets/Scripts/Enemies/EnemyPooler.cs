using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    public static EnemyPooler Instance { get; private set; }

    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] protected int _numOfEnemies;
    protected List<GameObject> _preloadEnemies;

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
        int idx;
        _preloadEnemies = new List<GameObject>();

        for (int i = 0; i < _numOfEnemies; ++i)
        {
            idx = Random.Range(0, _enemyPrefabs.Count);
            GameObject enemyObject = Instantiate(_enemyPrefabs[idx], Vector3.zero, _enemyPrefabs[idx].transform.rotation);
            enemyObject.SetActive(false);
            enemyObject.transform.SetParent(transform);
            _preloadEnemies.Add(enemyObject);
        }
    }

    public GameObject GetPreloadObject()
    {
        GameObject gameObject = _preloadEnemies.Find(obj => !obj.activeInHierarchy);
        return gameObject ? gameObject : null;
    }
}
