using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyMovement[] _spawnEnemies;
    [SerializeField] private TargetMovement[] _enemyTargets;
    [SerializeField] private Transform _enemiesSpawnPosition;

    private Transform[] _spawnPoints;
    private bool _isSpawn = false;
    private Coroutine _spawner;

    private void Start()
    {
        _spawnPoints = new Transform[_enemiesSpawnPosition.childCount];

        for (int i = 0; i < _enemiesSpawnPosition.childCount; i++)
        {
            _spawnPoints[i] = _enemiesSpawnPosition.GetChild(i);
        }

        StartSpawnEnemies();
    }

    private void StartSpawnEnemies()
    {
        if (_spawnPoints.Length > 0)
        {
            _spawner = StartCoroutine(SpawnEnemies());
        }
        else
        {
            _isSpawn = false;
            StopCoroutine(_spawner);
        }
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds respawnTime = new WaitForSeconds(2);
        int spawnPointsMaxIndex = _spawnPoints.Length;
        int spawmPointsMinIndex = 0;
        _isSpawn = true;

        while (_isSpawn)
        {
            int index = Random.Range(spawmPointsMinIndex, spawnPointsMaxIndex);
            GameObject enemy = Instantiate(_spawnEnemies[index].gameObject, _spawnPoints[index].transform);
            EnemyMovement movementController = enemy.GetComponent<EnemyMovement>();
            movementController.Init(_enemyTargets[index]);           
            yield return respawnTime;
        }
    }
}