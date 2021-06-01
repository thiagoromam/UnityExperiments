using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip _breakSound;
    [SerializeField] private GameObject _sparklesVfx;
    [SerializeField] private int _maxHits;
    [SerializeField] private int _timesHit;

    private Level _level;

    private void Start()
    {
        _level = FindObjectOfType<Level>();

        if (IsBreakable())
            _level.IncreaseBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsBreakable())
        {
            HandleHit();
        }
    }

    private bool IsBreakable()
    {
        return tag == "Breakable";
    }
    private void HandleHit()
    {
        _timesHit++;

        if (_timesHit >= _maxHits)
        {
            PlayDestroySound();
            TriggerSparkles();
            Destroy();
        }
    }

    private void PlayDestroySound()
    {
        AudioSource.PlayClipAtPoint(_breakSound, Camera.main.transform.position);
    }
    private void Destroy()
    {
        _level.DecreaseBreakableBlocks();
        FindObjectOfType<GameSession>().AddToScore();

        Destroy(gameObject);
    }
    private void TriggerSparkles()
    {
        GameObject sparkles = Instantiate(_sparklesVfx, transform.position, transform.rotation);

        Destroy(sparkles, 2);
    }
}
