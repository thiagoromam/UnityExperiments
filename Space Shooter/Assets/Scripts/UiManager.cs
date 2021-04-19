using Assets.Helpers;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _gameOverText;
    [SerializeField] private Text _restartText;
    [SerializeField] private Image _livesImage;
    [SerializeField] private Sprite[] _livesSprites;
    [SerializeField] private GameManager _gameManager;

    void Start()
    {
        UpdateScore(0);
        UpdateLives(3);
        ToggleGameOver(false);
        ToggleRestartMessage(false);
    }

    public void UpdateScore(int score)
    {
        _scoreText.text = $"Score: {score}";
    }
    public void UpdateLives(int lives)
    {
        lives = lives.Clamp(0, 3);

        _livesImage.sprite = _livesSprites[lives];

        if (lives == 0)
        {
            ShowGameOver();
            ToggleRestartMessage(true);
        }
    }

    private void ShowGameOver()
    {
        _gameManager.GameOver();

        IEnumerator Coroutine()
        {
            bool visible = false;

            while (true)
            {
                visible = !visible;

                ToggleGameOver(visible);
                yield return new WaitForSeconds(0.5f);
            }
        }

        StartCoroutine(Coroutine());
    }
    private void ToggleGameOver(bool visible)
    {
        _gameOverText.gameObject.SetActive(visible);
    }
    private void ToggleRestartMessage(bool visible)
    {
        _restartText.gameObject.SetActive(visible);
    }
}
