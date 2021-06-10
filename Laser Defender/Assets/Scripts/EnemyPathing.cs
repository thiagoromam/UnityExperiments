using System.Linq;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] WaveConfig _waveConfig;
    
    Transform[] _waypoints;
    float _moveSpeed = 2;
    int _waypointIndex;

    void Start()
    {
        _waypoints = _waveConfig.GetWaypoints().ToArray();
        _moveSpeed = _waveConfig.MoveSpeed;

        transform.position = (Vector2)_waypoints[_waypointIndex].transform.position;
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_waypointIndex < _waypoints.Length)
        {
            Vector2 targetPosition = _waypoints[_waypointIndex].transform.position;
            float movementInThisFrame = _moveSpeed * Time.deltaTime;
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
