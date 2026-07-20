using UnityEngine;

public class Zombie_Life : MonoBehaviour, I_TakeDamage {
    public void TakeDamage() {
        Debug.Log($"{this.name} take damage !");
    }
}
