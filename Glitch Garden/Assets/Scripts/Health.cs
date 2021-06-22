using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _points = 100;
    [SerializeField] GameObject _deathEffect;

    public void DealDamage(int damage)
    {
        _points -= damage;

        if (_points <= 0)
        {
            TriggerDeathEffect();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathEffect()
    {
        if (!_deathEffect) return;

        GameObject effect = Instantiate(_deathEffect, transform.position, transform.rotation);

        Destroy(effect, 1f);
    }
}
