using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 _lastPlayerPosition;
    private float _distanceToMove;

    public PlayerController Player;

    void Start()
    {
        Player = FindObjectOfType<PlayerController>();
        _lastPlayerPosition = Player.transform.position;
    }

    void Update()
    {
        _distanceToMove = Player.transform.position.x - _lastPlayerPosition.x;
        
        transform.position += new Vector3(_distanceToMove, 0);

        _lastPlayerPosition = Player.transform.position;
    }
}
