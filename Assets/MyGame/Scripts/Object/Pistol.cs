using UnityEngine;

public class Pistol : MonoBehaviour, I_Interactable {

    public void OnInteract() {
        Debug.Log("Take Pistol !");
        GameManager.Instance.PlayerGetWeapons();
        Destroy(this.gameObject);
    }
}
