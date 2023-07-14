using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    bool canShoot { get; }
    void Move();
    void Attack();
}
