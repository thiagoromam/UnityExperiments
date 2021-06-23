using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] GameObject _defender;

    void OnMouseDown()
    {
        GameObject defender = Instantiate(_defender, GetSquareClicked(), Quaternion.identity);
    }

    private Vector2 GetSquareClicked()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
