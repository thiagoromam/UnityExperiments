using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _speed = 8;
    
    public bool Up = true;

    void Update()
    {
        transform.Translate(GetDirection() * _speed * Time.deltaTime);

        if (transform.position.y > 8)
            Destroy(gameObject);
    }

    private Vector3 GetDirection()
    {
        return Up ? Vector3.up : Vector3.down;
    }
}
