using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _speed = 1;

    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
}
