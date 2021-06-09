using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 10;
    [SerializeField] float _padding = 1;

    Vector3 _min;
    Vector3 _max;

    void Start()
    {
        SetUpMovementBoundaries();
    }
    void Update()
    {
        Move();
    }

    private void SetUpMovementBoundaries()
    {
        Vector3 padding = new Vector3(_padding, _padding);

        _min = Camera.main.ViewportToWorldPoint(Vector3.zero) + padding;
        _max = Camera.main.ViewportToWorldPoint(Vector3.one) - padding;
    }
    private void Move()
    {
        float inputY = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");
        Vector3 position = transform.position;

        position.x += inputX * _moveSpeed * Time.deltaTime;
        position.y += inputY * _moveSpeed * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, _min.x, _max.x);
        position.y = Mathf.Clamp(position.y, _min.y, _max.y);

        transform.position = position;
    }
}
