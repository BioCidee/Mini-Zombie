using System.Collections.Generic;
using UnityEngine;

public class NPC_Controller : MonoBehaviour
{
    [Header("---- Path Parameters ----")]
    public Node currentNode;
    public List<Node> path = new List<Node>();

    [Header("---- NPC Parameters ----")]
    [SerializeField] private float speed;
  

    private void Update() {
        CreatePath();
    }

    private void CreatePath() {
        if (path.Count > 0) {
            int x = 0;
            transform.position = Vector3.MoveTowards(transform.position, 
                                 new Vector3(path[x].transform.position.x, path[x].transform.position.y, -2), speed * Time.deltaTime);

            if(Vector2.Distance(transform.position, path[x].transform.position) < 0.1f) {
                currentNode = path[x];
                path.RemoveAt(x);
                Debug.Log("End");
            }
        } else {
            Node[] nodes = FindObjectsByType<Node>(FindObjectsInactive.Include);
            Debug.Log(nodes.Length);
            while (path == null || path.Count == 0) {
                path = AstarsManager.instance.GeneratePath(currentNode, nodes[Random.Range(0, nodes.Length)]);
            }
        }
    }
}
