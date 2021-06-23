using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    void OnMouseDown()
    {
        DefenderButton[] buttons = FindObjectsOfType<DefenderButton>();

        foreach (var button in buttons)
        {
            Color color = button == this ? Color.white : (Color)new Color32(65, 65, 65, 255);

            button.GetComponent<SpriteRenderer>().color = color;
        }
    }
}
