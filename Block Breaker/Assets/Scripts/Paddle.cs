using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float _minX = 1;
    [SerializeField] private float _maxX = 15;

    private void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 position = transform.position;

        position.x = Mathf.Clamp(mouse.x, _minX, _maxX);

        transform.position = position;

        Debug.Log(Camera.main.pixelWidth);
    }
}
