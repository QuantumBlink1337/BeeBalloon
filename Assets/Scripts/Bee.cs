using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    private Rigidbody _rb;
    


    public float moveSpeed = 10f;
    
    private Camera _mainCamera;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _mainCamera = Camera.main;

    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = _mainCamera.nearClipPlane;
        return _mainCamera.ScreenToWorldPoint(mousePosition);
    }
    

    void FixedUpdate()
    {
        Vector3 targetPosition = GetMouseWorldPosition();
        Vector3 currentPosition = _rb.position;
        
        Debug.Log(currentPosition);
        Vector3 newPosition = Vector3.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.fixedDeltaTime);
        _rb.MovePosition(newPosition);
    }

    // private Vector3 ProcessMovement()
    // {
    //     _targetPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
    //     _currentPosition = Vector3.MoveTowards(_currentPosition, _targetPosition, moveSpeed * Time.deltaTime);
    //     return _currentPosition;
    // }
}
