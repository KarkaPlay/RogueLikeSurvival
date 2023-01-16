using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCombat : Combat
{
    private Camera _mainCamera;

    [SerializeField] protected Projectile _projectile;
    [SerializeField] protected Transform _shotPoint;
    protected Vector3 _targetPoint;

    // Start is called before the first frame update
    private void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        _targetPoint = LookAtCursor();
    }

    private Vector3 LookAtCursor()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hittedObject))
        {
            var direction = hittedObject.point - transform.position;

            // You might want to delete this line.
            // Ignore the height difference.
            direction.y = 0;

            // Make the transform look in the direction.
            //  transform.forward = direction;
            return direction;
        }
        else { return Vector3.zero; }
    }
}