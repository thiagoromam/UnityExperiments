using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField, Range(0, 5)] float _walkSpeed = 1;

    void Update()
    {
        transform.Translate(Vector2.left * _walkSpeed * Time.deltaTime);
    }
}
