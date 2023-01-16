using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeCombat : MonoBehaviour
{
    private Camera _mainCamera;
    private Vector3 target;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hittedObject))
        {
            if (hittedObject.transform != transform)
            {
                transform.LookAt(hittedObject.point);
                target = hittedObject.point;
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }
            //transform.LookAt(hittedObject.point);// - transform.position;
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 boxPosition = target == null ? Vector3.zero : target;
        Gizmos.DrawWireSphere(boxPosition, 1);
    }
}