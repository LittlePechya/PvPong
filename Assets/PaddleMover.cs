using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMover : MonoBehaviour
{
    [SerializeField]
    private float MaxSpeed = 5f;

    [SerializeField]
    private float Acceleration = 3f;

    [SerializeField]
    private float RotationSpeed = 100f;

    private Rigidbody2D rb;
    private Vector2 moveDirection = Vector2.zero;
    private Vector2 inputVector = Vector2.zero;
    private Vector2 rotationVector = Vector2.zero;

    public Vector3 StartPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        StartPosition = transform.position;
    }

    public void SetInputVector(Vector2 direction) 
    {
        inputVector = direction;
    }

    public void SetRotationVector(Vector2 rotation) 
    {
        rotationVector = rotation;
    }

    void Update()
    {
        // Up-Down momement
        moveDirection = new Vector2(0, inputVector.y) * MaxSpeed;
        rb.velocity = Vector2.Lerp(rb.velocity, moveDirection, Acceleration * Time.deltaTime);

        // Left-Right rotation
        float rotationAmount = rotationVector.x * RotationSpeed * Time.deltaTime;
        rb.MoveRotation(rb.rotation + rotationAmount);
    }

    public void ResetPosition()
    {
        transform.position = StartPosition;
        rb.velocity = Vector2.zero;
    }
}