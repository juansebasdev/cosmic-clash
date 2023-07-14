using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private float _enemyXRange;
    [SerializeField] private float _coinXRange = 10.5f;
    private int _playerScore;

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
        StartCoroutine(InstatiateCoins());
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

    private IEnumerator InstatiateCoins()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GameObject coin = CoinPooler.Instance.GetPreloadObject();
            if (coin != null)
            {
                coin.SetActive(true);
                coin.transform.position = new Vector2(Random.Range(-_coinXRange, _coinXRange), 5);
            }
        }
    }

    public void IncreasePlayerScore(int points)
    {
        _playerScore += points;
        UIManager.Instance.UpdateScoreText(_playerScore);
    }
}
