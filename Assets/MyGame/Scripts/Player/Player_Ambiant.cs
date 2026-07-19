using UnityEngine;

public class Player_Ambiant : MonoBehaviour
{
    [Header("---- Player Sprite ----")]
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] public Sprite pistolSprite;
    [SerializeField] public Sprite weaponsSprite;
    [SerializeField] public Sprite reloadWeaponsSprite;
    [SerializeField] public Sprite silencerWeaponslSprite;

    public void SetSprite(Sprite _sprite) {
        playerSprite.sprite = _sprite;
    }
}
