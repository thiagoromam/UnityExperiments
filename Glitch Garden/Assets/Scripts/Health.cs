using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _points = 100;

    public void DealDamage(int damage)
    {
        _points -= damage;

        if (_points <= 0)
        {
            Destroy(gameObject);
        }
    }
}
