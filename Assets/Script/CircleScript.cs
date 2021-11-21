using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private Vector2 inputVector = Vector2.zero;

    [SerializeField] public float initialSpeed = 10.0f;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            inputVector = GetCursorDirection();
            MoveCircle(inputVector, initialSpeed);
        }
    }

    private void MoveCircle(Vector2 input, float velocity)
    {
        rigidBody2D.velocity = inputVector * velocity;
    }

    public Vector2 GetCursorDirection()
    {
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z));
        Vector3 direction = worldMousePosition - this.transform.position;
        direction.Normalize();
        return (Vector2)direction;
    }
}
