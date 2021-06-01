using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip _breakSound;
    [SerializeField] private GameObject _sparklesVfx;

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
            PlayDestroySound();
            TriggerSparkles();
            Destroy();
        }
    }

    private bool IsBreakable()
    {
        return tag == "Breakable";
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
