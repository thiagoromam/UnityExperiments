using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject _projectile;
    [SerializeField] Transform _gun;

    void Fire()
    {
        Instantiate(_projectile, _gun.position, _gun.rotation);
    }
}
