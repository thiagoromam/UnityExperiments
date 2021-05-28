using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int _breakableBlocks;

    private SceneLoader _sceneLoader;

    private void Start()
    {
        _sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void IncreaseBreakableBlocks()
    {
        _breakableBlocks++;
    }
    public void DecreaseBreakableBlocks()
    {
        _breakableBlocks--;

        if (_breakableBlocks <= 0)
            _sceneLoader.LoadNextScene();
    }
}
