using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private float _enemyXRange;
    [SerializeField] private float _coinXRange = 10.5f;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private List<GameObject> _poolsToClean;
    [SerializeField] private List<GameObject> _spawnersToClean;
    [HideInInspector] public GameObject playerObject;
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
        playerObject = Instantiate(_playerPrefab, new Vector2(0, -3.5f), _playerPrefab.transform.rotation);
        playerObject.SetActive(false);
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
        _playerScore = 0;
        UIManager.Instance.UpdateScoreText(_playerScore);
        playerObject.SetActive(true);
        playerObject.GetComponent<PlayerController>().playerState = PlayerStates.alive;
        playerObject.transform.position = new Vector2(0, -3.5f);
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

    public void PlayAgain()
    {
        CleanObjects();
        Play();
    }

    public void Finish()
    {
        gameState = GameStates.finish;
        UIManager.Instance.Finish();
        playerObject.SetActive(false);
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

    private void CleanObjects()
    {
        foreach (GameObject poolObject in _poolsToClean)
        {
            Transform[] childrenInPoolObject = poolObject.GetComponentsInChildren<Transform>();
            foreach (Transform child in childrenInPoolObject)
            {
                if (child.gameObject.layer == 6)
                    child.gameObject.SetActive(false);
            }
        }

        foreach (GameObject spawnObject in _spawnersToClean)
        {
            Transform[] childrenInSpawnObject = spawnObject.GetComponentsInChildren<Transform>();
            foreach (Transform child in childrenInSpawnObject)
            {
                if (child.tag == "Damage")
                    Destroy(child.gameObject);
            }
        }
    }

    public void IncreasePlayerScore(int points)
    {
        _playerScore += points;
        UIManager.Instance.UpdateScoreText(_playerScore);
    }
}
