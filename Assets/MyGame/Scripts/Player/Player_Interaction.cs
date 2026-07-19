using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Interaction : MonoBehaviour
{
    [Header("---- Interact Parameters ----")]
    [SerializeField] float interactDistance;
    private PlayerInput input;

    private void Start() {
        input = GameManager.Instance.GetPlayerInput();
        EnableInteraction();
    }

    private void OnInteract(InputAction.CallbackContext context) {
        Debug.Log("Try Interaction");
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, interactDistance, transform.right);

        I_Interactable objectInteract = hit.transform.gameObject.GetComponent<I_Interactable>();

        if (objectInteract == null) return;

        objectInteract.OnInteract();
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactDistance);
    }

    private void EnableInteraction() {
        input.Interaction.Enable();
        input.Interaction.Interact.performed += OnInteract;
    }
}
