using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] private float _speed = 3;
    [SerializeField] private int _powerupId = 0;
    private AudioManager _audioManager;

    // 0 - Triple Shot
    // 1 - Speed
    // 2 - Shields

    void Start()
    {
        _audioManager = GameObject.Find("AudioManager")?.GetComponent<AudioManager>();

        float y = 7;
        float x = Random.Range(-8f, 8f);

        transform.position = new Vector3(x, y);
    }
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y <= -5)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            switch (_powerupId)
            {
                case 0: player.ActivateTripleShot(); break;
                case 1: player.ActivateSpeedBoost(); break;
                case 2: player.ActivateShields(); break;
            }

            _audioManager?.PlayPowerup();

            Destroy(gameObject);
        }
    }
}
