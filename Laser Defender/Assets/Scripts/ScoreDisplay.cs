using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    private GameSession _gameSession;

    void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        _gameSession = FindObjectOfType<GameSession>();
    }
    void Update()
    {
        _scoreText.text = _gameSession.Score.ToString();
    }
}
