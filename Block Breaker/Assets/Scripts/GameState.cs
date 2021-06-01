using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 10)]
    private float _gameSpeed = 1;

    void Update()
    {
        Time.timeScale = _gameSpeed;
    }
}
