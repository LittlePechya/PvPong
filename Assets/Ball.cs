using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float DefaultBallSpeed;

    [SerializeField]
    private float SpeedIncreseOnBounce;

    private Rigidbody2D rb;
    private Vector3 lastVelocity;

    public Vector3 StartPosition;

    private float currentBallSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartPosition = transform.position;
        Launch();
    }

    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void Launch() 
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        currentBallSpeed = DefaultBallSpeed;
        rb.velocity = new Vector2(currentBallSpeed * x, currentBallSpeed * y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border") || collision.gameObject.CompareTag("Paddle")) 
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed, 0f);

            currentBallSpeed += SpeedIncreseOnBounce;
            rb.velocity = rb.velocity.normalized * currentBallSpeed;

            Debug.Log("Bounce");
        }
    }

    public void ResetPosition() 
    {
        transform.position = StartPosition;
        rb.velocity = Vector2.zero;
        Launch();
    }

}