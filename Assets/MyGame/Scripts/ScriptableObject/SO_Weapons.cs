using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "WeaponsType")]
public class SO_Weapons : ScriptableObject
{
    public string weaponName;
    public string weaponType;
    public string weaponId;
    public int weaponsDamage;
    public float timeToReaload;
    public float fireDistance;
    public Sprite weaponsSprite;
    public Sprite playerSprite;
}
