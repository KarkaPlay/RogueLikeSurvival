using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaphone : MonoBehaviour
{
    private Vector3 _input;

    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private void Update()
    {
        GatherInput();
        Look();
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
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        //_rb.angularVelocity = new Vector3(0, _rb.angularVelocity.y, 0);
    }
}