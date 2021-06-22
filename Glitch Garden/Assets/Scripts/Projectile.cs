using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _speed = 1;
    [SerializeField] int _damage = 50;

    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Health health = other.GetComponent<Health>();

        health?.DealDamage(_damage);
    }
}
