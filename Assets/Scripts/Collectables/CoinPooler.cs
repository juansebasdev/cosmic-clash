using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPooler : BasePooler
{
    public static CoinPooler Instance { get; private set; }
    [SerializeField] private float _xRange = 10.5f;

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
}
