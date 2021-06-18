using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float _timeToWait = 4;

    int _index;

    void Start()
    {
        _index = SceneManager.GetActiveScene().buildIndex;

        if (_index == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(++_index);
    }

    private IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(_timeToWait);
        LoadNextScene();
    }
}
