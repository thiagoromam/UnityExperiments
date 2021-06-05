using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip _breakSound;
    [SerializeField] private GameObject _sparklesVfx;
    [SerializeField] private int _timesHit;
    [SerializeField] private Sprite[] _hitSprites;

    private Level _level;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _level = FindObjectOfType<Level>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

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

        if (_timesHit > _hitSprites.Length)
        {
            PlayDestroySound();
            TriggerSparkles();
            Destroy();
        }
        else
        {
            ShowNextHitSprite();
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
    private void ShowNextHitSprite()
    {
        _spriteRenderer.sprite = _hitSprites[_timesHit - 1];
    }
}
