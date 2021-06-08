using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 10;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float inputY = Input.GetAxis("Vertical");
        float inputX = Input.GetAxis("Horizontal");
        Vector3 position = transform.position;

        position.x += inputX * _moveSpeed * Time.deltaTime;
        position.y += inputY * _moveSpeed * Time.deltaTime;

        transform.position = position;
    }
}
