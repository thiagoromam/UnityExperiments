using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject _projectile;
    [SerializeField] Transform _gun;

    Animator _animator;
    AttackerSpawner _laneSpawner;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _laneSpawner = GetLaneSpawner();
    }
    void Update()
    {
        if (IsAttackerInLane())
        {
            _animator.SetBool("isAttacking", true);
        }
        else
        {
            _animator.SetBool("isAttacking", false);
        }
    }
    void Fire()
    {
        Instantiate(_projectile, _gun.position, _gun.rotation);
    }

    private AttackerSpawner GetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (var spawner in spawners)
        {
            bool isCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;

            if (isCloseEnough)
                return spawner;
        }

        return null;
    }
    private bool IsAttackerInLane()
    {
        return _laneSpawner.transform.childCount > 0;
    }
}
