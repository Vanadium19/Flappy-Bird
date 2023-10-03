using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{    
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private float _delay;

    private float _elapsedTime = 0;    

    private void Start()
    {
        Initialize(_enemyPrefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _delay)
        {
            if (TryGetEnemy(out GameObject enemy))
            {
                _elapsedTime = 0;
                SetObjectPosition(enemy);
            }
        }
    }

    public void ResetSpawner()
    {
        ResetPool();
        _elapsedTime = 0;
    }

    private void SetObjectPosition(GameObject enemy)
    {
        int spawnPointNumber = Random.Range(0, _spawnPoints.Count);

        enemy.SetActive(true);
        enemy.GetComponent<Enemy>().Died += OnEnemyDied;
        enemy.transform.position = _spawnPoints[spawnPointNumber].position;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        Bird.AddScore();
    }
}
