using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float xVelocity = 0f;
    [SerializeField] private float yVelocity = 0f;
    [SerializeField] private float zVelocity = 0f;

    void Update()
    {
        float deltaX = xVelocity * Time.deltaTime;
        float deltaY = yVelocity * Time.deltaTime;
        float deltaZ = zVelocity * Time.deltaTime;

        Vector3 rotationVector = new(deltaX, deltaY, deltaZ);

        transform.Rotate(rotationVector);
    }
}
