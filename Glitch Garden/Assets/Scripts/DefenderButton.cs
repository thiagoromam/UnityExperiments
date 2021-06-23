using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender _prefab;
    private DefenderSpawner _spawner;

    private void Start()
    {
        _spawner = FindObjectOfType<DefenderSpawner>();
    }

    void OnMouseDown()
    {
        DefenderButton[] buttons = FindObjectsOfType<DefenderButton>();

        foreach (var button in buttons)
        {
            Color color = button == this ? Color.white : (Color)new Color32(65, 65, 65, 255);

            button.GetComponent<SpriteRenderer>().color = color;

            _spawner.Defender = _prefab;
        }
    }
}
