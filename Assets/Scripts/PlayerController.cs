using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;

    private Vector2 _movementValue;
    
    void Update()
    {
        MovementSystem();
    }

    private void Move(Vector3 position)
    {
        transform.position += position * (movementSpeed * Time.deltaTime);
    }

    private void MovementSystem()
    {
        Move(new Vector3(_movementValue.x, 0, _movementValue.y));
    }

    public void OnMove(InputValue value)
    {
        _movementValue = value.Get<Vector2>();
    }
}
