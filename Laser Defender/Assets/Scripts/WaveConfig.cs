using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _pathPrefab;
    [SerializeField] float _timeBetweenSpawns = 0.5f;
    [SerializeField] float _spawnRandomFactor = 0.3f;
    [SerializeField] int _numberOfNames = 5;
    [SerializeField] float _moveSpeed = 2;

    public GameObject EnemyPrefab => _enemyPrefab;
    public float TimeBetweenSpawns => _timeBetweenSpawns;
    public float SpawnRandomFactor => _spawnRandomFactor;
    public int NumberOfNames => _numberOfNames;
    public float MoveSpeed => _moveSpeed;


    public IEnumerable<Transform> GetWaypoints()
    {
        foreach (Transform child in _pathPrefab.transform)
        {
            yield return child;
        }
    }
}
