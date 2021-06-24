using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private StarDisplay _starDisplay;

    public Defender Defender { private get; set; }

    void Start()
    {
        _starDisplay = FindObjectOfType<StarDisplay>();
    }
    void OnMouseDown()
    {
        if (_starDisplay.ExpenStars(Defender.StarCost))
            SpawnDefender();
    }

    private void SpawnDefender()
    {
        Defender defender = Instantiate(Defender, GetSquareClicked(), Quaternion.identity);
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
