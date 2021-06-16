using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float _scrollSpeed = 0.5f;
    
    Material _material;
    Vector2 _offset;

    void Start()
    {
        _material = GetComponent<Renderer>().material;
        _offset = new Vector2(0, _scrollSpeed);
    }
    void Update()
    {
        _material.mainTextureOffset += _offset * Time.deltaTime;
    }
}
