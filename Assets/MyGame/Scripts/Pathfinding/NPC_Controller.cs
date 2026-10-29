using System.Collections.Generic;
using UnityEngine;

public class NPC_Controller : MonoBehaviour
{
    [Header("---- Path Parameters ----")]
    public Node currentNode;
    public List<Node> path = new List<Node>();

    [Header("---- NPC Parameters ----")]
    [SerializeField] private float speed;

    [Header("---- Spawn Parameters ----")]
    [SerializeField] private float nodeDetection;

    private List<GameObject> nodelist = new List<GameObject>();

    private void Start()
    {
        nodelist = NodeGenerator.Instance.ReturnNodeList();

        SetCurrentNode();
    }

    private void Update() {
        CreatePath();
    }

    private void SetCurrentNode()
    {
        GameObject nearestGameObject = nodelist[1].gameObject;
        Vector2 nearestDistance = transform.position - nodelist[0].transform.position;
        float NdistX = nearestDistance.x;
        float NdistY = nearestDistance.y;

        foreach (GameObject hit in nodelist) 
        {
            if (hit.TryGetComponent<Node>(out Node _node))
            {
                Node newNode = _node;

                Vector2 distance = transform.position - hit.transform.position;

                if (distance.x < nearestDistance.x && distance.y < nearestDistance.y)
                {
                    nearestDistance = distance;
                    nearestGameObject = hit.gameObject;
                }
            }
        }

        currentNode = nearestGameObject.GetComponent<Node>();
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, nodeDetection);
    }
}
