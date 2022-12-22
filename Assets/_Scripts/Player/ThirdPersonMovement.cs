using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    private CharacterController playerController;
    [SerializeField] private float speed = 5;

    private Vector3 _input;
    private Vector3 _moveDirection;

    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    // Start is called before the first frame update
    private void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        GatherInput();
        Look();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GatherInput()
    {
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = 0;
        _input.z = Input.GetAxisRaw("Vertical");
        _input.Normalize();
    }

    private void Look()
    {
        if (_input.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(_input.x, _input.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            // transform.rotation = Quaternion.Euler(0, angle, 0);

            _moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
        }

        //_rb.angularVelocity = new Vector3(0, _rb.angularVelocity.y, 0);
    }

    private void Move()
    {
        if (_input.magnitude >= 0.1f)
        {
            playerController.Move(_moveDirection.normalized * speed * Time.fixedDeltaTime);
        }
    }
}