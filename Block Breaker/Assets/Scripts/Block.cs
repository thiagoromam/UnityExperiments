using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip _breakSound;

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

        Destroy(gameObject);
    }
}
