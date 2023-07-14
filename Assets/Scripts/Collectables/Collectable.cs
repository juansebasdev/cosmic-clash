using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour, IHasPoints
{
    [SerializeField] private int _points;

    public int points { get => _points; private set => points = _points; }
}
