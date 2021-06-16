using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void LoadGameOver()
    {
        SceneManager.LoadScene("Gane Over");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
