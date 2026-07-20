using UnityEngine;

public class Weapons : MonoBehaviour, I_Interactable
{
    [SerializeField] private SO_Weapons weapon;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer.sprite = weapon.weaponsSprite;
    }

    public void OnInteract() {
        GameManager.Instance.PlayerGetWeapons(weapon);
        Destroy(this.gameObject);
    }
}
