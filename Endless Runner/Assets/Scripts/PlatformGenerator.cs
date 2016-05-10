using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    private int _platformSelector;
    private float[] _platformWidths;
    
    public Transform GenerationPoint;
    public float DistanceBetween;
    public float DistanceBetweenMin;
    public float DistanceBetweenMax;
    public ObjectPooler[] ObjectPools;

    void Start()
    {
        _platformWidths = new float[ObjectPools.Length];
        for (var i = 0; i < _platformWidths.Length; i++)
        {
            _platformWidths[i] = ObjectPools[i].PooledObject.GetComponent<BoxCollider2D>().size.x;
        }
    }

    void Update()
    {
        if (transform.position.x < GenerationPoint.position.x)
        {
            _platformSelector = Random.Range(0, ObjectPools.Length);

            DistanceBetween = Random.Range(DistanceBetweenMin, DistanceBetweenMax);
            transform.position += new Vector3(_platformWidths[_platformSelector] / 2 + DistanceBetween, 0);

            var newPlatform = ObjectPools[_platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            
            transform.position += new Vector3(_platformWidths[_platformSelector] / 2, 0);
        }
    }
}
