using UnityEngine;

public class Pistol : MonoBehaviour, I_Interactable {

    [SerializeField] private SO_Weapons weapon;

    public void OnInteract() {
        Debug.Log("Take Pistol !");
        GameManager.Instance.PlayerGetWeapons(weapon);
        Destroy(this.gameObject);
    }
}
