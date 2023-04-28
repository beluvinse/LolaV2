using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public float movSpeed;

    private Rigidbody _myRb;
    private Camera _mainCamera;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private void Start()
    {
        _myRb = GetComponent<Rigidbody>();
        _mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * movSpeed;

        Ray cameraRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float raylenght;

        if (groundPlane.Raycast(cameraRay, out raylenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(raylenght);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    private void FixedUpdate()
    {
        _myRb.velocity = moveVelocity;
    }


}
