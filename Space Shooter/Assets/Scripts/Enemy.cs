using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4;
    private Player _player;
    private Animator _animator;
	private AudioSource _explosionAudio;

    void Start()
    {
        _player = GameObject.Find("Player")?.GetComponent<Player>();
        _animator = GetComponent<Animator>();
		_explosionAudio = GetComponent<AudioSource>();

        SetInitialTop();
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
}
