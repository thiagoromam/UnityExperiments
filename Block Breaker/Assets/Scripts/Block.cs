using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip _breakSound;

    private Level _level;
    private GameStatus _gameStatus;

    private void Start()
    {
        _level = FindObjectOfType<Level>();
        _gameStatus = FindObjectOfType<GameStatus>();

        _level.IncreaseBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(_breakSound, Camera.main.transform.position);

        _level.DecreaseBreakableBlocks();
        _gameStatus.AddToScore();

        Destroy(gameObject);
    }
}
