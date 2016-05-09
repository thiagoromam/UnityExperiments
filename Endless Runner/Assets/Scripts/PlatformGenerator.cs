using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    private float _platformWidth;

    public GameObject Platform;
    public Transform GenerationPoint;
    public float DistanceBetween;
    public float DistanceBetweenMin;
    public float DistanceBetweenMax;
    public ObjectPooler ObjectPool;

    void Start()
    {
        _platformWidth = Platform.GetComponent<BoxCollider2D>().size.x;
    }

    void Update()
    {
        if (transform.position.x < GenerationPoint.position.x)
        {
            DistanceBetween = Random.Range(DistanceBetweenMin, DistanceBetweenMax);
            transform.position += new Vector3(_platformWidth + DistanceBetween, 0);

            var newPlatform = ObjectPool.GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
        }
    }
}
