using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour, IEnemy, IShooter, IHasPoints
{
    [SerializeField] protected LayerMask _whatIsPlayer;
    [SerializeField] protected float _attackRange = 0.2f;
    [SerializeField] protected float _minSpeed = 15f;
    [SerializeField] protected float _maxSpeed = 25f;
    [SerializeField] protected float _xBound = 8f;
    [SerializeField] protected float _yBound = 5f;
    [SerializeField] protected bool _canShoot;
    [SerializeField] protected int _points;
    protected Transform _playerTransform;
    protected float _speed = 20f;
    protected float _moveInX;
    protected float _moveInY;
    protected bool _playerInAttackRange;
    protected bool _hasAttacked = false;
    protected Vector2 _directionToTarget;
    public bool canShoot { get => _canShoot; protected set => canShoot = _canShoot; }
    public int points { get => _points; protected set => points = _points; }

    public virtual void Shoot() { }

    private void Start()
    {
        _playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        _speed = Random.Range(_minSpeed, _maxSpeed);
        _directionToTarget = _playerTransform.position - transform.position;

        if (canShoot)
        {
            InvokeRepeating(nameof(Shoot), 0, .8f);
        }
    }

    private void FixedUpdate()
    {
        _playerInAttackRange = Physics2D.OverlapCircle(transform.position, _attackRange, _whatIsPlayer);
    }

    private void Update()
    {
        if (_playerInAttackRange && !_hasAttacked)
            Attack();
        else
            Move();

        if (Mathf.Abs(transform.position.y) > _yBound || Mathf.Abs(transform.position.x) > _xBound)
            Destroy(gameObject);
    }

    public virtual void Move()
    {
        float randomNoise = Random.Range(-2.5f, 2.5f);
        _moveInX = (_directionToTarget.normalized.x + randomNoise) * _speed * Time.deltaTime;
        _moveInY = (_directionToTarget.normalized.y + randomNoise) * _speed * Time.deltaTime;

        transform.Translate(_moveInX, _moveInY, 0);
        if (_hasAttacked && Vector2.Distance(_playerTransform.position, transform.position) > _attackRange)
            _hasAttacked = false;
    }

    public virtual void Attack()
    {
        _directionToTarget = _playerTransform.position - transform.position;
        _moveInX = _directionToTarget.normalized.x * _speed * Time.deltaTime;
        _moveInY = _directionToTarget.normalized.y * _speed * Time.deltaTime;

        transform.Translate(_moveInX, _moveInY, 0);
        _hasAttacked = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }
}
