using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] GameObject _defender;

    void OnMouseDown()
    {
        GameObject defender = Instantiate(_defender, transform.position, Quaternion.identity);


    }
}
