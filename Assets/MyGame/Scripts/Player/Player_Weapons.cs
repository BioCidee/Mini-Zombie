using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Weapons : MonoBehaviour
{
    [Header("---- Weapons Parameters ----")]
    [SerializeField] private bool isPlayerHaveWeapons = false;
    [SerializeField] private float fireDistance;

    [Header("---- Player Movement ----")]
    [SerializeField] private Player_Movement player_Movement;
    [SerializeField] private Transform firePointTransform;

    [Header("---- Player Sprite ----")]
    [SerializeField] private Player_Ambiant player_Ambiant;

    // Player Parameters
    private PlayerInput playerInput;

    private void Start() {
        playerInput = GameManager.Instance.GetPlayerInput();
    }

    public void PlayerGetWeapons() {
        isPlayerHaveWeapons = true;
        player_Ambiant.SetSprite(player_Ambiant.pistolSprite);

        playerInput.Weapons.Enable();
        playerInput.Weapons.Fire.performed += OnFire;
    }

    private void OnFire(InputAction.CallbackContext context) {
        
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Vector3 targetpositon = firePointTransform.position + firePointTransform.right * fireDistance;
        Gizmos.DrawLine(firePointTransform.position, targetpositon);
    }
}
