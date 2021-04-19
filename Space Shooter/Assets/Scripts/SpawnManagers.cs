using UnityEngine;

public class SpawnManagers : MonoBehaviour
{
    private SpawnManager[] _spawnManagers;

    private void Start()
    {
        _spawnManagers = GetComponentsInChildren<SpawnManager>();
    }

    public void StartSpawning()
    {
        foreach (var spawnManager in _spawnManagers)
            spawnManager.StartSpawning();
    }
    public void OnPlayerDeath()
    {
        foreach (var spawnManager in _spawnManagers)
            spawnManager.OnPlayerDeath();
    }
}
