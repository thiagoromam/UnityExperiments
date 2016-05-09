using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject DestructionPoint;

    void Start()
    {
        DestructionPoint = GameObject.Find("PlataformDestructionPoint");
    }

    void Update()
    {
        if (transform.position.x < DestructionPoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }
}
