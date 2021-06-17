using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] int _score;

    public int Score => _score;

    void Awake()
    {
        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddToScore(int value)
    {
        _score += value;
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
