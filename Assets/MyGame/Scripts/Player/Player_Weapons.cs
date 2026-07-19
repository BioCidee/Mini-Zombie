using UnityEngine;

public class Player_Weapons : MonoBehaviour
{
    [Header("---- Weapons Parameters ----")]
    [SerializeField] private bool isPlayerHaveWeapons = false;

    [Header("---- Player Movement ----")]
    [SerializeField] private Player_Movement player_Movement;

    public void PlayerGetWeapons() {
        isPlayerHaveWeapons = true;
    }
}
