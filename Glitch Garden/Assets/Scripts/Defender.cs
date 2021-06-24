using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int _starCost = 100;

    private StarDisplay _starDisplay;

    void Start()
    {
        _starDisplay = FindObjectOfType<StarDisplay>();
    }

    void AddStars(int amount)
    {
        _starDisplay.AddStars(amount);
    }
}
