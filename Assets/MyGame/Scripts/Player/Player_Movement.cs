using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("---- Movement Parameters ----")]
    [SerializeField] private float movementSpeed;

    private Vector2 movementDirection;


    private void Update() {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
