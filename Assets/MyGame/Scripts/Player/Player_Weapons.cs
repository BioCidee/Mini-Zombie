using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Weapons : MonoBehaviour
{
    [Header("---- Weapons Parameters ----")]
    [SerializeField] private float fireDistance;

    [Header("---- Player Movement ----")]
    [SerializeField] private Player_Movement player_Movement;
    [SerializeField] private Transform firePointTransform;

    [Header("---- Player Sprite ----")]
    [SerializeField] private Player_Ambiant player_Ambiant;

    [Header("---- Player Current Weapons ----")]
    [SerializeField] private SO_Weapons mainWeapons = null;
    [SerializeField] private SO_Weapons secondaryWeapons = null;
    [SerializeField] private SO_Weapons currentWeapons = null;

    // Player Parameters
    private PlayerInput playerInput;

    private void Start() {
        playerInput = GameManager.Instance.GetPlayerInput();
    }

    public void PlayerGetWeapons(SO_Weapons _newWeapons) {
        Debug.Log($"New Weapons {_newWeapons.name}");
        if (mainWeapons == null) {
            mainWeapons = _newWeapons;
            currentWeapons = mainWeapons;
            SetPlayerSprite(_newWeapons);
        } else if(secondaryWeapons == null) {
            secondaryWeapons = _newWeapons;
            currentWeapons = secondaryWeapons;
            SetPlayerSprite(_newWeapons);
        } else {
            return;
        }

        if (playerInput.Weapons.enabled == false) EnableWeaponsInput();
    }

    private void OnDisable() {
        playerInput.Weapons.Fire.performed -= OnFire;
        playerInput.Weapons.Reload.performed -= OnReload;
    }

    private void EnableWeaponsInput() {
        playerInput.Weapons.Enable();
        playerInput.Weapons.Fire.performed += OnFire;
        playerInput.Weapons.Reload.performed += OnReload;
        playerInput.Weapons.Switch.performed += OnSwitchWeapons;
    }

    private void SetPlayerSprite(SO_Weapons _newWeapons) {
        player_Ambiant.SetSprite(_newWeapons.playerSprite);
    }

    private void OnReload(InputAction.CallbackContext obj) {
       
    }

    private void OnSwitchWeapons(InputAction.CallbackContext context) {
        Debug.Log("Switch Weapons !");
        if (currentWeapons.name == mainWeapons.name) {
            if (secondaryWeapons != null) {
                currentWeapons = secondaryWeapons;
                SetPlayerSprite(currentWeapons);
            }

            Debug.Log("No secondary");
        } else {
            currentWeapons = mainWeapons;
            SetPlayerSprite(currentWeapons);
        }
    }

    private void OnFire(InputAction.CallbackContext context) {
        Debug.Log("Fire !");
        RaycastHit2D hit = Physics2D.Raycast(firePointTransform.position, firePointTransform.right, fireDistance);
        I_TakeDamage objectDamage;

        if(hit.collider == null) {
            return;
        }

        if (hit.transform.gameObject.TryGetComponent(out objectDamage)) {
            objectDamage.TakeDamage(currentWeapons.weaponsDamage);
            Debug.Log($"{hit.transform.gameObject.name} have Take Damage !");
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Vector3 targetpositon = firePointTransform.position + firePointTransform.right * fireDistance;
        Gizmos.DrawLine(firePointTransform.position, targetpositon);
    }
}
