using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _laserAudio;
    [SerializeField] private AudioSource _powerupAudio;

    public void PlayLaser()
    {
        _laserAudio.Play();
    }
    public void PlayPowerup()
    {
        _powerupAudio.Play();
    }
}
