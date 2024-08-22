using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour
{
    private bool IsGround() => cc != null ? cc.isGrounded : false;
    public bool isDoubleJump = false;

    [SerializeField]
    private float _speed = 0.0f;
    [SerializeField]
    private float _smoothTime = 0.05f;
    private float _gravity = -9.81f;
    [SerializeField] private float gravityMultipier = 3.0f;
    private float _velocity;
    private float _currentVelocity = 0;
    [SerializeField]
    private float _jumpForce = 4.0f;

    private int _numberOfJump = 0;
    [SerializeField]
    private int maxNumberofJumps = 2;

    private Vector2 _input;
    private Vector3 _direction;
    private CharacterController cc;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    private void ApplyGravity()
    {
        if (IsGround() && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * gravityMultipier * Time.deltaTime;
        }

        _direction.y = _velocity;
    }
    private void ApplyRotation()
    {
        if (_input.magnitude == 0) return;

        //var targetAngle = Mathf.Atan2(_direction.x, _direction.z)*Mathf.Rad2Deg;
        //var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, _smoothTime);
        //transform.rotation = Quaternion.Euler(0.0f, targetAngle, 0.0f);
    }
    private void ApplyMovement()
    {
        Vector3 direction = transform.TransformDirection(_direction);
        cc.Move(direction * _speed * Time.deltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started) return;
        if (isDoubleJump)
        {
            if (!IsGround() && _numberOfJump >= maxNumberofJumps) return;
            if (_numberOfJump == 0) StartCoroutine(WaitForLanding());
            _numberOfJump++;

        }
        else
        {
            if (!IsGround()) return;
        }
        _velocity += _jumpForce;
    }

    private IEnumerator WaitForLanding()
    {
        yield return new WaitUntil(() => !IsGround());
        yield return new WaitUntil(IsGround);
    }

    private void Update()
    {
        ApplyGravity();
        ApplyRotation();
        ApplyMovement();
    }
}
