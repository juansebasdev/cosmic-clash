using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private float _enemyXRange;
    [SerializeField] private float _coinXRange = 10.5f;
    private int _playerScore;
    private bool _hasPause;
    public GameStates gameState;

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
        gameState = GameStates.start;
        UIManager.Instance.MainMenu();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (gameState != GameStates.start)
                Pause();
        }
    }

    public void Play()
    {
        gameState = GameStates.play;
        UIManager.Instance.Gameplay();
        StartCoroutine(InstatiateEnemies());
        StartCoroutine(InstatiateCoins());
    }

    public void Pause()
    {
        _hasPause = !_hasPause;
        if (_hasPause)
        {
            gameState = GameStates.pause;
            UIManager.Instance.Pause();
            StopAllCoroutines();
        }
        else
        {
            gameState = GameStates.play;
            Play();
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    private IEnumerator InstatiateEnemies()
    {
        while (gameState == GameStates.play)
        {
            yield return new WaitForSeconds(2.5f);
            Vector2 enemyPos = new Vector2(Random.Range(-_enemyXRange, _enemyXRange), 4);
            EnemySpawner.Instance.SpawnEnemies(enemyPos);
        }
    }

    private IEnumerator InstatiateCoins()
    {
        while (gameState == GameStates.play)
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
