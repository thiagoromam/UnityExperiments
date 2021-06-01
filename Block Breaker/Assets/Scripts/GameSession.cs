using TMPro;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField, Range(0.1f, 10)] private float _gameSpeed = 1;
    [SerializeField] private int _pointsPerBlock = 83;
    [SerializeField] private float _currentScore;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Awake()
    {
        int gamesStatusCount = FindObjectsOfType<GameSession>().Length;

        if (gamesStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        UpdateScoreText();
    }
    private void Update()
    {
        Time.timeScale = _gameSpeed;
    }

    public void AddToScore()
    {
        _currentScore += _pointsPerBlock;

        UpdateScoreText();
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }

    private void UpdateScoreText()
    {
        _scoreText.text = _currentScore.ToString();
    }
}
