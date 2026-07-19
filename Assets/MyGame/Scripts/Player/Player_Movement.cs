using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    [Header("---- Movement Parameters ----")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private Rigidbody2D rb;

    [Header("---- Player Camera ----")]
    [SerializeField] private Camera cam;

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
        mousePosition = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    private void FixedUpdate() {
        PlayerRotation();
        PlayerMovement();
    }

    private void PlayerRotation() {
        Vector2 lookDir = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    private void PlayerMovement() {
        rb.linearVelocity = new Vector2(movementDirection.x * movementSpeed, movementDirection.y * movementSpeed);  
    }
}
