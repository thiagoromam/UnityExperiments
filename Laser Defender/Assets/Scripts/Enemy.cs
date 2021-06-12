using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _minTimeBetweenShots = 0.2f;
    [SerializeField] float _maxTimeBetweenShots = 3;
    [SerializeField] GameObject _laserPrefab;
    [SerializeField] float _laserSpeed;
    [SerializeField] float _projectileSpeed = 10;

    float _shotCounter;

    void Start()
    {
        CalculateTimeToNextShoot();
    }
    void Update()
    {
        CountDownAndShoot();
    }
    
    private void CalculateTimeToNextShoot()
    {
        _shotCounter = Random.Range(_minTimeBetweenShots, _maxTimeBetweenShots);
    }
    private void CountDownAndShoot()
    {
        _shotCounter -= Time.deltaTime;

        if (_shotCounter <= 0)
        {
            Fire();
            CalculateTimeToNextShoot();
        }
    }
    private void Fire()
    {
        GameObject laser = Instantiate(_laserPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rigidbody = laser.GetComponent<Rigidbody2D>();

        rigidbody.velocity = new Vector2(0, -_projectileSpeed);
    }
}
