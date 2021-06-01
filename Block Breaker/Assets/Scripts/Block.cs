using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip _breakSound;
    [SerializeField] private GameObject _sparklesVfx;

    private Level _level;

    private void Start()
    {
        _level = FindObjectOfType<Level>();
        _level.IncreaseBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(_breakSound, Camera.main.transform.position);

        _level.DecreaseBreakableBlocks();
        FindObjectOfType<GameSession>().AddToScore();

        TriggerSparkles();

        Destroy(gameObject);
    }

    private void TriggerSparkles()
    {
        GameObject sparkles = Instantiate(_sparklesVfx, transform.position, transform.rotation);

        Destroy(sparkles, 2);
    }
}
