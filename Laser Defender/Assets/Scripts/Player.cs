using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float _moveSpeed = 10;
    [SerializeField] float _padding = 1;

    [Header("Projectile")]
    [SerializeField] GameObject _laserPrefab;
    [SerializeField] float _projectileSpeed = 10;
    [SerializeField] float _projectileFiringPeriod = 0.1f;

    Coroutine _fireCoroutine;
    Vector3 _min;
    Vector3 _max;

    void Start()
    {
        SetUpMovementBoundaries();
    }
    void Update()
    {
        Move();
        Fire();
    }
    
    private void SetUpMovementBoundaries()
    {
        Vector3 padding = new Vector3(_padding, _padding);

        _min = Camera.main.ViewportToWorldPoint(Vector3.zero) + padding;
        _max = Camera.main.ViewportToWorldPoint(Vector3.one) - padding;
    }
    private void Move()
    {
        float inputY = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");
        Vector3 position = transform.position;

        position.x += inputX * _moveSpeed * Time.deltaTime;
        position.y += inputY * _moveSpeed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, _min.x, _max.x);
        position.y = Mathf.Clamp(position.y, _min.y, _max.y);

        transform.position = position;
    }
    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(_fireCoroutine);
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(_laserPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rigidbody = laser.GetComponent<Rigidbody2D>();

            rigidbody.velocity = new Vector2(0, _projectileSpeed);

            yield return new WaitForSeconds(_projectileFiringPeriod);
        }
    }
}
