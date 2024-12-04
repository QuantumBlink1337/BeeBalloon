using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation in degrees per second

    private void FixedUpdate()
    {
        // Rotate the object around its local Z-axis
        transform.Rotate(0f, 0f, rotationSpeed * Time.fixedDeltaTime);
    }
}
