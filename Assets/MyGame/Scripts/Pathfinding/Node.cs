using System.Collections.Generic;
using UnityEngine;


public class Node : MonoBehaviour
{
    public Node camFrom;
    public List<Node> connections;

    public float gScore;
    public float hScore;

    private void Start() {
        
    }

    public float FScore() {
        return gScore + hScore;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        
        for (int i = 0; i < connections.Count; i++) {
            Gizmos.DrawLine(transform.position, connections[i].transform.position);
        }  
    }
}
