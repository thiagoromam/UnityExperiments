using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField, Range(0, 5)] float _walkSpeed = 1;
    [SerializeField] bool _canWalk = false;

    void Update()
    {
        if (_canWalk)
            transform.Translate(Vector2.left * _walkSpeed * Time.deltaTime);
    }

    void OnWalkEnter()
    {
        _canWalk = true;
    }
}
