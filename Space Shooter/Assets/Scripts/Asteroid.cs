using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 19;
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private SpawnManagers _spawnManagers;

    void Update()
    {
        transform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Laser")
        {
            _spawnManagers.StartSpawning();

            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);

            Destroy(other.gameObject);
            Destroy(gameObject, 0.25f);
        }
    }
}
