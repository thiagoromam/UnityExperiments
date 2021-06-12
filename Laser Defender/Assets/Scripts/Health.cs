using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float _points = 100;

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
            Destroy(gameObject);
    }
}
