using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Enemy))]

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private int _spawnTimeStep;

    [SerializeField] private Enemy _enemy;

    private EnemiePoint[] _points;

    private float _runningTime;

    private void Awake()
    {
        int spawnTime = 0;

        _points = gameObject.GetComponentsInChildren<EnemiePoint>();

        foreach (EnemiePoint point in _points)
        {
            spawnTime += _spawnTimeStep;
            point._enemyTimeSpawnStep = spawnTime;
            Debug.Log(point._enemyTimeSpawnStep);
        }
    }

    private void Update()
    {
        _runningTime += Time.deltaTime;

        foreach (EnemiePoint point in _points)
        {
            if (point._enemyTimeSpawnStep - _runningTime < 0)
            {
                point.CreateCoin(_enemy);
            }

            if (CheckAllPointsForUse())
            {
                ResetSpawnPoints();
            }
        }
    }

    private bool CheckAllPointsForUse()
    {
        foreach (EnemiePoint point in _points)
        {
            if (point.IsUsed == false)
            {
                return false;
            }
        }

        return true;
    }

    private void ResetSpawnPoints()
    {
        foreach (EnemiePoint point in _points)
        {
            point.IsUsed = false;
        }

        _runningTime = 0;
    }
}