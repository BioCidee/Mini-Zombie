using System.Collections.Generic;
using UnityEngine;


public class Node : MonoBehaviour
{
    public Node camFrom;
    public List<Node> connections;
    public float dist;

    public float gScore;
    public float hScore;

    private void Start() {
        Collider2D[] hits = Physics2D.OverlapAreaAll(transform.position, transform.position * dist);

        foreach(Collider2D c in hits) {
            Debug.Log($"This {this.name} have {hits.Length} in his collider ! next is : {c.name}");
        }

       
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
        // Gizmos.DrawSphere(transform.position, dist);
    }
}
