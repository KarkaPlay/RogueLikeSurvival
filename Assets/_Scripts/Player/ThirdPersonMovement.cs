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

    [SerializeField] private LayerMask groundMask;
    private Camera _mainCamera;

    // Start is called before the first frame update
    private void Start()
    {
        playerController = GetComponent<CharacterController>();
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        GatherInput();
        Aim();
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

    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            // Calculate the direction
            var direction = position - transform.position;

            // You might want to delete this line.
            // Ignore the height difference.
            direction.y = 0;

            // Make the transform look in the direction.
            transform.forward = direction;
        }
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            // The Raycast hit something, return with the position.
            return (success: true, position: hitInfo.point);
        }
        else
        {
            // The Raycast did not hit anything.
            return (success: false, position: Vector3.zero);
        }
    }

    private void Move()
    {
        if (_input.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(_input.x, _input.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            // transform.rotation = Quaternion.Euler(0, angle, 0);

            _moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            playerController.Move(_moveDirection.normalized * speed * Time.fixedDeltaTime);
        }
    }
}