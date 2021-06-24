using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject _projectile;
    [SerializeField] Transform _gun;

    AttackerSpawner _laneSpawner;

    void Start()
    {
        SetLaneSpawner();
    }
    void Update()
    {
        if (IsAttackerInLane())
        {
            Debug.Log("shoot pew pew");
        }
        else
        {
            Debug.Log("sit and wait");
        }
    }
    void Fire()
    {
        Instantiate(_projectile, _gun.position, _gun.rotation);
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (var spawner in spawners)
        {
            bool isCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;

            if (isCloseEnough)
            {
                _laneSpawner = spawner;

                break;
            }
        }
    }
    private bool IsAttackerInLane()
    {
        return _laneSpawner.transform.childCount > 0;
    }
}
