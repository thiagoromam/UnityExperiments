using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _paddleOffset = 0.5f;
    [SerializeField] private Vector2 _initialVelocity = new Vector2(2, 15);

    private Rigidbody2D _rigidbody;
    private GameObject _paddle;
    private bool _fixed = true;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
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
}
