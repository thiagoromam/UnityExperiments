using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float _points = 100;
    [SerializeField] GameObject _explosionVfx;
    [SerializeField] float _durationOfExplosion = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer)
            HandleHit(damageDealer);
    }

    private void HandleHit(DamageDealer damageDealer)
    {
        _points -= damageDealer.Damage;

        damageDealer.Hit();

        if (_points <= 0)
        {
            Destroy(gameObject);
            CreateExplosion();
        }
    }

    private void CreateExplosion()
    {
        GameObject explosion = Instantiate(_explosionVfx, transform.position, transform.rotation);

        Destroy(explosion, _durationOfExplosion);
    }
}
