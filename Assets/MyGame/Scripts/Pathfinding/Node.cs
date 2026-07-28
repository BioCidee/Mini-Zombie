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
        connections = new List<Node>();

        int count = 0;
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, Vector2.one * dist, 0);

        foreach(Collider2D c in hits) {
            Node nextNod = null;

            if(c.transform.TryGetComponent<Node>(out nextNod)) {

                if (nextNod == this) continue;

                Debug.Log($"This {nextNod.name} in the collider  of {this.name}! On /  {count + 1}");

                connections.Add(nextNod);
                count++;
            }
            
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
        Gizmos.DrawCube(transform.position, Vector3.one * dist);
    }
}
