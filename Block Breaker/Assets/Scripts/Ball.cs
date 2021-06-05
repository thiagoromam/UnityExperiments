using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _paddleOffset = 0.5f;
    [SerializeField] private Vector2 _initialVelocity = new Vector2(2, 15);
    [SerializeField] private AudioClip[] _ballSounds;
    [SerializeField] private float _randomFactor = 0.5f;

    private Rigidbody2D _rigidbody;
    private AudioSource _audioSource;
    private GameObject _paddle;
    private bool _fixed = true;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _paddle = GameObject.Find("Paddle");

    }
    void Update()
    {
        if (_fixed)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LockBallToPaddle()
    {
        transform.position = _paddle.transform.position + new Vector3(0, _paddleOffset);
    }
    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody.velocity = _initialVelocity;
            _fixed = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2();

        velocityTweak.x = Random.Range(0, _randomFactor);
        velocityTweak.y = Random.Range(0, _randomFactor);

        int index = Random.Range(0, _ballSounds.Length);
        AudioClip clip = _ballSounds[index];

        _audioSource.PlayOneShot(clip);
        _rigidbody.velocity += velocityTweak;
    }
}
