using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField, Range(0, 5)] float _walkSpeed = 1;
    [SerializeField] bool _canWalk = false;
    [SerializeField] int _damage = 20;

    Animator _animator;
    Health _targetHealth;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (_canWalk)
            transform.Translate(Vector2.left * _walkSpeed * Time.deltaTime);

        if (_targetHealth?.Points <= 0)
            ClearCurrentTarget();
    }

    void OnWalkEnter()
    {
        _canWalk = true;
    }
    void OnWalkLeave()
    {
        _canWalk = false;
    }

    public void Attack(GameObject target)
    {
        _animator.SetBool("isAttacking", true);
        _targetHealth = target.GetComponent<Health>();
    }

    public void StrikeCurrentTarget()
    {
        if (!_targetHealth) return;

        _targetHealth.DealDamage(_damage);
    }

    private void ClearCurrentTarget()
    {
        _targetHealth = null;
        _animator.SetBool("isAttacking", false);
    }
}
