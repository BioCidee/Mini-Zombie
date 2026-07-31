using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [Header("---- Spawn Paramaetres ----")]
    [SerializeField] private Transform spawnPointTransform;

    [Header("---- Node Came From ----")]
    [SerializeField] private Node myNode;

    private GameManager gameManager;

    private void Start() {
       
    }
}
