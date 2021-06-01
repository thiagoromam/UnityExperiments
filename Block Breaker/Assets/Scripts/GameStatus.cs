using UnityEngine;

public class GameStatus : MonoBehaviour
{
    [SerializeField, Range(0.1f, 10)] private float _gameSpeed = 1;
    [SerializeField] private int _pointsPerBlock = 83;
    [SerializeField] private float _currentScore;

    void Update()
    {
        Time.timeScale = _gameSpeed;
    }

    public void AddToScore()
    {
        _currentScore += _pointsPerBlock;
    }
}
