using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Interaction : MonoBehaviour
{
    [Header("---- Interact Parameters ----")]
    [SerializeField] float interactDistance;
    [SerializeField] private Transform transformInteractionPoint;
    private PlayerInput input;

    private void Start() {
        input = GameManager.Instance.GetPlayerInput();
        EnableInteraction();
    }

    private void OnInteract(InputAction.CallbackContext context) {
        Debug.Log("Try Interaction");
        RaycastHit2D hit = Physics2D.CircleCast(transformInteractionPoint.position, interactDistance, transform.right);

        if (hit.collider == null) return;

        Debug.Log(hit.transform.gameObject.name);

        I_Interactable objectInteract = hit.transform.gameObject.GetComponent<I_Interactable>();

        if (objectInteract == null) {
            Debug.Log("No interaction");
            return;
        }
        

        objectInteract.OnInteract();
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transformInteractionPoint.position, interactDistance);
    }

    private void EnableInteraction() {
        input.Interaction.Enable();
        input.Interaction.Interact.performed += OnInteract;
    }
}
