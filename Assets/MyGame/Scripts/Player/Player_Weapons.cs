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
        playerInput.Weapons.Reload.performed += OnReload;
    }

    private void OnDisable() {
        playerInput.Weapons.Fire.performed -= OnFire;
        playerInput.Weapons.Reload.performed -= OnReload;
    }

    private void OnReload(InputAction.CallbackContext obj) {
       
    }

    private void OnFire(InputAction.CallbackContext context) {
        Debug.Log("Fire !");
        RaycastHit2D hit = Physics2D.Raycast(firePointTransform.position, firePointTransform.right, fireDistance);
        I_TakeDamage objectDamage;

        if(hit.collider == null) {
            return;
        }

        if (hit.transform.gameObject.TryGetComponent(out objectDamage)) {
            objectDamage.TakeDamage();
            Debug.Log($"{hit.transform.gameObject.name} have Take Damage !");
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Vector3 targetpositon = firePointTransform.position + firePointTransform.right * fireDistance;
        Gizmos.DrawLine(firePointTransform.position, targetpositon);
    }
}
