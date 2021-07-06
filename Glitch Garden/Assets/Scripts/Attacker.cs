using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField, Range(0, 5)] float _walkSpeed = 1;
    [SerializeField] bool _canWalk = false;

    Animator _animator;
    GameObject _currentTarget;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (_canWalk)
            transform.Translate(Vector2.left * _walkSpeed * Time.deltaTime);
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
        _currentTarget = target;
    }
}
