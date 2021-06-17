using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float _delayInSeconds = 2;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");

        FindObjectOfType<GameSession>()?.ResetGame();
    }
    public void LoadGameOver()
    {
        IEnumerator Load()
        {
            yield return new WaitForSeconds(_delayInSeconds);
            SceneManager.LoadScene("Game Over");
        }

        StartCoroutine(Load());
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
