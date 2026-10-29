using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    [Header("---- Movement Parameters ----")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private Rigidbody2D rb;
    private PlayerInput input;

    [Header("---- Player Camera ----")]
    [SerializeField] private Camera cam;

    // Input Action Reference
    private Vector2 movementDirection;
    private Vector2 mousePosition;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();

        input = GameManager.Instance.GetPlayerInput();
        input.Movement.Enable();
    }

    private void Update() {
        movementDirection = input.Movement.Move.ReadValue<Vector2>();
        mousePosition = cam.ScreenToWorldPoint(input.Movement.Mouse.ReadValue<Vector2>());
    }

    private void FixedUpdate() {
        PlayerMovement();
        PlayerRotation();
    }

    private void PlayerRotation() {
        /*Vector2 lookDir = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;*/

        Vector2 lookDir;
        lookDir.x = transform.position.x - mousePosition.x;
        lookDir.y = transform.position.y - mousePosition.y;

        float newRotation = math.atan2(lookDir.y, lookDir.x);
        rb.rotation = (newRotation * Mathf.Rad2Deg) + 180;
    }

    private void PlayerMovement() {
      rb.linearVelocity = new Vector2(movementDirection.x * movementSpeed, movementDirection.y * movementSpeed);  
    }


    // Public
    public void SetPlayerSpeed(float _speed) {
        movementSpeed = _speed;
    }
}
