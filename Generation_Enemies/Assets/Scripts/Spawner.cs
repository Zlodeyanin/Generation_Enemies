using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _currentSpawnPosition;
    [SerializeField] private int[] _directions;

    private Transform[] _spawnPoints;
    private bool _isSpawn = false;

    private void Start()
    {
        _spawnPoints = new Transform[_currentSpawnPosition.childCount];

        for (int i = 0; i < _currentSpawnPosition.childCount; i++)
        {
            _spawnPoints[i] = _currentSpawnPosition.GetChild(i);
        }

        StartSpawnEnemies();
    }

    private void StartSpawnEnemies()
    {
        if (_spawnPoints.Length > 0)
        {
            StartCoroutine(SpawnEnemies());
        }
        else
        {
            _isSpawn = false;
            StopCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies()
    {
        var twoSeconds = new WaitForSeconds(2);
        int spawnPointsMaxIndex = _spawnPoints.Length;
        int spawmPointsMinIndex = 0;
        _isSpawn = true;

        while (_isSpawn)
        {
            int index = Random.Range(spawmPointsMinIndex, spawnPointsMaxIndex);
            GameObject enemy = Instantiate(_enemy, _spawnPoints[index].transform);
            var movementController = enemy.GetComponent<EnemyMowemetContoller>();
            movementController.Init(_directions[index]);
            yield return twoSeconds;
        }
    }
}