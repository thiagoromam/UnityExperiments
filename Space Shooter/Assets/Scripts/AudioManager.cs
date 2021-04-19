using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _laserAudio;

    public void PlayLaser()
    {
        _laserAudio.Play();
    }
}
