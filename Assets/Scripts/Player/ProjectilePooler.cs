using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePooler : BasePooler
{
    public static ProjectilePooler Instance { get; private set; }

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
