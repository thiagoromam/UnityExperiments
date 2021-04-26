using Assets.Helpers;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private float _fireOffset = -1.17f;
    [SerializeField] private int _minSecondsToFire = 2;
    [SerializeField] private int _maxSecondsToFire = 3;

    private Player _player;
    private Animator _animator;
    private AudioSource _explosionAudio;
    private AudioManager _audioManager;

    void Start()
    {
        _player = GameObject.Find("Player")?.GetComponent<Player>();
        _animator = GetComponent<Animator>();
        _explosionAudio = GetComponent<AudioSource>();
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        SetInitialTop();

        StartCoroutine(FireCoroutine());
    }
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= -5)
            SetInitialTop();
    }

    private void SetInitialTop()
    {
        float y = 7;
        float x = Random.Range(-8f, 8f);

        transform.position = new Vector3(x, y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player?.Damage();
            Destroy();
        }
        else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy();

            _player.AddScore(10);
        }
    }

    private void Destroy()
    {
        _animator.SetTrigger("OnEnemyDeath");
        _speed = 0;

        Destroy(this);
        Destroy(gameObject, 2.8f);

        _explosionAudio.Play();
    }

    IEnumerator FireCoroutine()
    {
        while (true)
        {
            int seconds = IntHelper.Random(_minSecondsToFire, _maxSecondsToFire);

            yield return new WaitForSeconds(seconds);

            var gameObject = Instantiate(_laserPrefab, transform.position + new Vector3(0, _fireOffset), Quaternion.identity);
            var lasers = gameObject.GetComponentsInChildren<Laser>();

            foreach (var laser in lasers)
            {
                laser.gameObject.tag = "EnemyLaser";
                laser.Up = false;
            }

            _audioManager.PlayLaser();
        }
    }
}
