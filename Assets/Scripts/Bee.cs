using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    


    public float moveSpeed = 10f;
    public float rotationSpeed = 5f;
    
    private Rigidbody _rb;
    private Camera _mainCamera;
    
    private float _lockedZ;
    private bool _isFlipped = false;

    private const float flipThreshold = 90f;
    private const float hyteresisBuffer = 10f;

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
        
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + 180f;

        // if (!_isFlipped && angle > flipThreshold + hyteresisBuffer)
        // {
        //     _isFlipped = true;
        // }
        // else if (_isFlipped && angle < flipThreshold - hyteresisBuffer)
        // {
        //     _isFlipped = false;
        // }
        
        //
        //
        // if (dir.x < 0) // Target is to the left.
        // {
        //     transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); // Flip to face left.
        // }
        // else // Target is to the right.
        // {
        //     transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z); // Default orientation.
        // }
        // transform.localScale = _isFlipped ? new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z)
        //     : new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        
        
        
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


}
