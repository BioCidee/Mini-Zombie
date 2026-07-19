using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    [Header("---- Movement Parameters ----")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private Rigidbody2D rb;

    [Header("---- Input Action Reference ----")]
    [SerializeField] private InputActionReference inputMove;
    [SerializeField] private InputActionReference inputMousePosition;
    private Vector2 movementDirection;
    private Vector2 mousePosition;
    

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        movementDirection = inputMove.action.ReadValue<Vector2>();
        mousePosition = inputMousePosition.action.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        rb.linearVelocity = new Vector2(movementDirection.x * movementSpeed, movementDirection.y * movementSpeed);

        Debug.Log(mousePosition);

    }
}
