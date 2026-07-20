using UnityEngine;

public class Zombie_Life : MonoBehaviour, I_TakeDamage {

    [Header("---- Life Parameters ----")]
    [SerializeField] private float maxLife = 100;
    [SerializeField] private float minLife = 0;
    [SerializeField] private float currentLife;

    private void Start() {
        currentLife = maxLife;
    }

    public void TakeDamage(int _damage) {
        Debug.Log($"{this.name} take {_damage} damage !");
        RemoveLife( _damage );
    }

    private void RemoveLife(int _damage) {
        currentLife -= _damage;
        CheckLife();
    }

    private void CheckLife() {
        if (currentLife <= minLife) {
            Death();
        }
    }

    private void Death() {
        Debug.Log("This Zombie is Dead !");
        Destroy(this.gameObject);
    }
}
