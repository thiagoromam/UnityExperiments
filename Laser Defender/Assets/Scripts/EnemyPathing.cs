using System.Linq;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    Transform[] _waypoints;
    int _waypointIndex;

    public WaveConfig WaveConfig { private get; set; }

    void Start()
    {
        if (!WaveConfig)
            return;

        _waypoints = WaveConfig.GetWaypoints().ToArray();

        transform.position = (Vector2)_waypoints[_waypointIndex].transform.position;
    }
    void Update()
    {
        if (WaveConfig)
            return;

        Move();
    }

    private void Move()
    {
        if (_waypointIndex < _waypoints.Length)
        {
            Vector2 targetPosition = _waypoints[_waypointIndex].transform.position;
            float movementInThisFrame = WaveConfig.MoveSpeed * Time.deltaTime;
            Vector2 newPosition = Vector2.MoveTowards(transform.position, targetPosition, movementInThisFrame);

            transform.position = newPosition;

            if (newPosition == targetPosition)
            {
                _waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
