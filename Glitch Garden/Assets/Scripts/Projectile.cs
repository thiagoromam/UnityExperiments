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
        Attacker attacker = other.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.DealDamage(_damage);
            Destroy(gameObject);
        }
    }
}
