using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float _minX = 1;
    [SerializeField] private float _maxX = 15;

    private Lazy<GameSession> _gameSession;
    private Ball _ball;

    private void Start()
    {
        _gameSession = new Lazy<GameSession>(FindObjectOfType<GameSession>);
        _ball = FindObjectOfType<Ball>();
    }
    private void Update()
    {
        Vector3 position = transform.position;

        position.x = Mathf.Clamp(GetXPosition(), _minX, _maxX);

        transform.position = position;
    }

    private float GetXPosition()
    {
        if (_gameSession.Value.IsAutoPlayEnabled())
            return _ball.transform.position.x;

        return Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
    }
}
