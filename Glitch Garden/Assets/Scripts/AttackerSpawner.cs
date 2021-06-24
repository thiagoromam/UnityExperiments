using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float _minSpawnDelay = 1f;
    [SerializeField] float _maxSpawnDelay = 5f;
    [SerializeField] Attacker _prefab;

    bool _spawn = true;

    IEnumerator Start()
    {
        while (_spawn)
        {
            yield return new WaitForSeconds(GetDelayTime());
            SpawnAttacker();
        }
    }

    private float GetDelayTime()
    {
        return Random.Range(_minSpawnDelay, _maxSpawnDelay);
    }
    private void SpawnAttacker()
    {
        Attacker attacker = Instantiate(_prefab, transform.position, transform.rotation);

        attacker.transform.parent = transform;
    }
}
