using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] GameObject _defender;

    void OnMouseDown()
    {
        GameObject defender = Instantiate(_defender, GetSquareClicked(), Quaternion.identity);
    }

    private Vector2 SnapToGrid(Vector2 position)
    {
        position.x = Mathf.RoundToInt(position.x);
        position.y = Mathf.RoundToInt(position.y);

        return position;
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 grid = SnapToGrid(position);

        return grid;
    }
}
