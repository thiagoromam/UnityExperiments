using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _health = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        _health -= damageDealer.Damage;
    }
}
