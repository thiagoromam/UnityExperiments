using System.Collections;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfig[] _waveConfigs;
    [SerializeField] bool _looping = false;

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (_looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        foreach (var waveConfig in _waveConfigs)
        {
            yield return StartCoroutine(SpawnAllEnemiesInWave(waveConfig));
        }
    }
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig currentWave)
    {
        var waypoints = currentWave.GetWaypoints().ToArray();

        for (int i = 0; i < currentWave.NumberOfNames; i++)
        {
            var enemy = Instantiate(currentWave.EnemyPrefab, waypoints[0].position, Quaternion.identity);
            var pathing = enemy.GetComponent<EnemyPathing>();

            pathing.WaveConfig = currentWave;

            yield return new WaitForSeconds(currentWave.TimeBetweenSpawns);
        }
    }
}
