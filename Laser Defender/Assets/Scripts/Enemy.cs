using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _scoreValue = 100;

    [Header("Shooting")]
    [SerializeField] float _minTimeBetweenShots = 0.2f;
    [SerializeField] float _maxTimeBetweenShots = 3;
    [SerializeField] GameObject _laserPrefab;
    [SerializeField] float _projectileSpeed = 10;

    [Header("Sound Effects")]
    [SerializeField] AudioClip _shootSound;
    [SerializeField, Range(0, 1)] float _shootSoundVolume = 0.5f;

    float _shotCounter;

    void Start()
    {
        CalculateTimeToNextShoot();

        GetComponent<Health>().Death += OnDeath;
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

        AudioSource.PlayClipAtPoint(_shootSound, Camera.main.transform.position, _shootSoundVolume);
    }

    private void OnDeath()
    {
        FindObjectOfType<GameSession>()?.AddToScore(_scoreValue);
    }
}
