using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float _speed = 1f;

    void Update()
    {
        transform.Rotate(0, 0, _speed * Time.deltaTime);
    }
}
