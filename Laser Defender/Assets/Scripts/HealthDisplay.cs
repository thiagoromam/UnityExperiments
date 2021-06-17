using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    TextMeshProUGUI _scoreText;
    Player _player;

    void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        _player = FindObjectOfType<Player>();
    }
    void Update()
    {
        _scoreText.text = _player.Health.ToString();
    }
}
