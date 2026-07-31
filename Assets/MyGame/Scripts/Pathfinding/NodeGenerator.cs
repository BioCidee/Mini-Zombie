using UnityEngine;

public class NodeGenerator : MonoBehaviour
{
    [Header("---- Grid Parameters ----")]
    [SerializeField] private float height;
    [SerializeField] private float width;
    private Vector2 begeinning = new Vector2(0.5f, 0.5f);

    [Header("---- Node Parameters ----")]
    [SerializeField] private Transform nodeParent;
    [SerializeField] private GameObject nodePrefab;

    private void Start() {
        GenerateNode();
    }


    private void GenerateNode() {
        for (int h = 0; h < height; h++) {
            for (int w = 0; w < width; w++) {
                Vector2 newPos = new Vector2(begeinning.x + w, begeinning.y - (h + 1));
                GameObject newNode = Instantiate(nodePrefab, newPos, Quaternion.identity, nodeParent);
            }
        }
    }
}
