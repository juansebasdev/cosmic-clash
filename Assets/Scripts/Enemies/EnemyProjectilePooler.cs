using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectilePooler : BasePooler
{
    public static EnemyProjectilePooler Instance { get; private set; }

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
