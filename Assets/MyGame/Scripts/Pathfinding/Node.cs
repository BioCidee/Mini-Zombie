using System.Collections.Generic;
using UnityEngine;


public class Node : MonoBehaviour
{
    public Node camFrom;
    public LayerMask layerProps;
    public List<Node> connections;
    public float setDist;
    public float connectionNodeDist = 2.5f;
    public float currentDist;

    public float gScore;
    public float hScore;

    private void Awake() {
        this.GetComponent<BoxCollider2D>().enabled = false;

        currentDist = 1;
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, Vector2.one * currentDist, 0);
        //Debug.Log($"{name} a détecté {hits.Length} colliders");
        foreach (Collider2D c in hits) {
            //Debug.Log($"-> {c.gameObject.name} sur layer {LayerMask.LayerToName(c.gameObject.layer)} ({c.gameObject.layer})");
            if (((1 << c.gameObject.layer) & layerProps.value) != 0) {
                //Debug.Log($"{name} DOIT être détruit (mur/props détecté)");
                Destroy(gameObject);
                enabled = false;
                return;
            }
        }
    }

    private void Start() {
        this.GetComponent<BoxCollider2D>().enabled = true;

        currentDist = connectionNodeDist;
        connections = new List<Node>();

        int count = 0;
        Debug.Log("Beggining Connection");
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, Vector2.one * currentDist, 0);
        Debug.Log($"{this.name}: The lenght of the hit list is {hits.Length}");

        foreach (Collider2D c in hits) {
            Debug.Log("Beggining ForEach collider in Hits");
            Node nextNod = null;

            Debug.Log("Beggining detection of Node Component");
            if (c.transform.TryGetComponent<Node>(out nextNod)) {
                Debug.Log("Node Component DETECTED, see if its me");
                if (nextNod == this) continue;

                Debug.Log($"This {nextNod.name} in the collider  of {this.name}! On /  {count + 1}");

                connections.Add(nextNod);
                Debug.Log("Connection Add ");
                count++;
            } 
        }

        this.GetComponent<BoxCollider2D>().enabled = false;
    }

    public float FScore() {
        return gScore + hScore;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        
        for (int i = 0; i < connections.Count; i++) {
            Gizmos.DrawLine(transform.position, connections[i].transform.position);
        }  

        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, Vector3.one * setDist);
    }
}
