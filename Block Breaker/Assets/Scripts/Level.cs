using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int _breakableBlocks;

    public void IncreaseBreakableBlocks()
    {
        _breakableBlocks++;
    }
}
