using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Collider2D _collider;
	private Animator _animator;

    public float MoveSpeed;
    public float JumpForce;
    public bool Grounded;
    public LayerMask WhatIsGround;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
		_animator = GetComponent<Animator>();
    }

    void Update()
    {
        Grounded = Physics2D.IsTouchingLayers(_collider, WhatIsGround);

        _rigidbody.velocity = new Vector2(MoveSpeed, _rigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (Grounded)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, JumpForce);
            }
        }
		
		_animator.SetFloat("Speed", _rigidbody.velocity.x);
		_animator.SetBool("Grounded", Grounded);
    }
}
