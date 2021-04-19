using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private float _spawnTime = 2.5f;
    [SerializeField] private float _spawnTimeRange;
    [SerializeField] private float _startY = 7;

    private bool _spawning;

    public void StartSpawning()
    {
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(3);

            if (_spawnTimeRange > 0)
                yield return WaitSpawnTime();

            _spawning = true;

            while (_spawning)
            {
                float x = Random.Range(-8f, 8f);
                GameObject prefab = GetRandomPrefab();
                GameObject element = Instantiate(prefab, new Vector3(x, _startY), Quaternion.identity);

                element.transform.parent = transform;

                yield return WaitSpawnTime();
            }
        }

        StartCoroutine(Coroutine());
    }
    public void OnPlayerDeath()
    {
        _spawning = false;
    }

    private GameObject GetRandomPrefab()
    {
        int index = Random.Range(0, _prefabs.Length);

        return _prefabs[index];
    }
    private WaitForSeconds WaitSpawnTime()
    {
        float seconds = _spawnTime;

        if (_spawnTimeRange > 0)
            seconds =  Random.Range(seconds, _spawnTimeRange);

        return new WaitForSeconds(seconds);
    }
}
