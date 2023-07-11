using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiePoint : MonoBehaviour
{
    public int _enemyTimeSpawnStep;
    public Vector3 Position { get; private set; }

    public bool IsUsed;

    public void CreateCoin(Enemy enemy)
    {
        if (IsUsed)
        {
            return;
        }
        else
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            IsUsed = true;
        }
    }
}
