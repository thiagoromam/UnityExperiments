using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _health = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        HandleHit(damageDealer);
    }

    private void HandleHit(DamageDealer damageDealer)
    {
        _health -= damageDealer.Damage;

        if (_health <= 0)
            Destroy(gameObject);
    }
}
