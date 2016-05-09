using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ObjectPooler : MonoBehaviour {

    private List<GameObject> _pooledObjects;

    public GameObject PooledObject;
    public int PooledAmount;

    void Start()
    {
        _pooledObjects = new List<GameObject>();

        for (var i = 0; i < PooledAmount; i++)
        {
            var obj = Instantiate(PooledObject);
            obj.SetActive(false);

            _pooledObjects.Add(obj);
        }
    }

    void Update()
    {

    }

    public GameObject GetPooledObject()
    {
        var obj = _pooledObjects.FirstOrDefault(p => !p.activeInHierarchy);

        if (obj == null)
        {
            obj = Instantiate(PooledObject);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }

        return obj;
    }
}
