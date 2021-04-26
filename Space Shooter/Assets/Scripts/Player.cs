using Assets.Helpers;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float _speedMultiplier = 2;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private GameObject _tripleShotPrefab;
    [SerializeField] private GameObject _shields;
    [SerializeField] private GameObject[] _engines;
    [SerializeField] private SpawnManagers _spawnManagers;
    [SerializeField] private float _fireOffset = 1.15f;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private int _lives = 3;
    [SerializeField] private bool _isTripleShotActive;
    [SerializeField] private bool _isSpeedBoostActive;
    [SerializeField] private bool _isShieldsActive;
    [SerializeField] private int _score;
    [SerializeField] private UiManager _uiManager;
    [SerializeField] private AudioManager _audioManager;

    private float _canFire = -1f;

    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
            FireLaser();
    }

    public void Damage()
    {
        if (DisableShields())
            return;

        UpdateLives();

        if (_lives >= 1)
        {
            DamageEngines();
        }
        else
        {
            Destroy();
        }
    }
    public void ActivateTripleShot()
    {
        IEnumerator Countdown()
        {
            _isTripleShotActive = true;

            yield return new WaitForSeconds(5);

            _isTripleShotActive = false;
        }

        StartCoroutine(Countdown());
    }
    public void ActivateSpeedBoost()
    {
        IEnumerator Countdown()
        {
            _isSpeedBoostActive = true;

            yield return new WaitForSeconds(5);

            _isSpeedBoostActive = false;
        }

        StartCoroutine(Countdown());
    }
    public void ActivateShields()
    {
        _isShieldsActive = true;
        _shields.SetActive(true);
    }
    public void AddScore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }

    private void CalculateMovement()
    {
        float speed = _speed;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput);

        if (_isSpeedBoostActive)
            speed *= _speedMultiplier;

        transform.Translate(direction * speed * Time.deltaTime);

        float x = transform.position.x;
        float y = transform.position.y.Clamp(-3.8f, 0);

        if (x < -11.3f)
            x = 11.3f;
        else if (x > 11.3f)
            x = -11.3f;

        transform.position = new Vector3(x, y);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyLaser")
        {
            Destroy(other.gameObject);
            Damage();
        }
    }

    private void FireLaser()
    {
        _canFire = Time.time + _fireRate;

        if (_isTripleShotActive)
        {
            FireTripleShot();
        }
        else
        {
            FireSingleLaser();
        }

        _audioManager.PlayLaser();
    }
    private void FireSingleLaser()
    {
        Instantiate(_laserPrefab, transform.position + new Vector3(0, _fireOffset), Quaternion.identity);
    }
    private void FireTripleShot()
    {
        var tripleShot = Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);

        tripleShot.transform.DetachChildren();
        Destroy(tripleShot.gameObject);
    }

    private bool DisableShields()
    {
        if (_isShieldsActive)
        {
            _isShieldsActive = false;
            _shields.SetActive(false);

            return true;
        }

        return false;
    }
    private void UpdateLives()
    {
        _lives--;
        _uiManager.UpdateLives(_lives);
    }
    private void DamageEngines()
    {
        int index = _lives - 1;
        GameObject engine = _engines[index];

        engine.SetActive(true);
    }
    private void Destroy()
    {
        Destroy(gameObject);
        _spawnManagers.OnPlayerDeath();
    }
}
