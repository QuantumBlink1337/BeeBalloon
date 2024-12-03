using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    private Rigidbody _rb;
    


    public float moveSpeed = 10f;
    public float rotationSpeed = 5f;
    private float _lockedZ;
    
    private Camera _mainCamera;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;
        
        _lockedZ = transform.position.z;

    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(_mainCamera.transform.position.z - transform.position.z);
        return _mainCamera.ScreenToWorldPoint(mousePosition);
    }

    private void RotateTowards(Vector3 targetPos)
    {
        Vector3 dir = targetPos - transform.position;
        
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 180f);
        
        Quaternion q = Quaternion.Euler(0f, 0f, angle);
        _rb.MoveRotation(Quaternion.Lerp(transform.rotation, q, rotationSpeed * Time.fixedDeltaTime));
    }
    

    void FixedUpdate()
    {
        Vector3 targetPosition = GetMouseWorldPosition();
        Vector3 currentPosition = _rb.position;


        targetPosition.z = _lockedZ;
        currentPosition.z = _lockedZ;
        Debug.Log(currentPosition);
        Vector3 newPosition = Vector3.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.fixedDeltaTime);
      
        _rb.MovePosition(newPosition);
        RotateTowards(targetPosition);
    }

    // private Vector3 ProcessMovement()
    // {
    //     _targetPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
    //     _currentPosition = Vector3.MoveTowards(_currentPosition, _targetPosition, moveSpeed * Time.deltaTime);
    //     return _currentPosition;
    // }
}
