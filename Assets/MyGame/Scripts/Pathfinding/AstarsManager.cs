using Mono.Cecil.Cil;
using System.Collections.Generic;
using UnityEngine;

public class AstarsManager : MonoBehaviour
{
    public static AstarsManager instance;

    private void Awake() {
        instance = this;
    }

    private List<Node> GeneratePath(Node start, Node end) {
        List<Node> openSet = new List<Node>();

        foreach(Node n in FindObjectsByType<Node>()) {
            n.gScore = float.MaxValue;
        }

        start.gScore = 0;
        start.hScore = Vector2.Distance(start.transform.position, end.transform.position);
        openSet.Add(start);

        while (openSet.Count > 0) {
            int lowestF = default;

            for (int i = 0; i < openSet.Count; i++) {
                if (openSet[i].FScore() < openSet[lowestF].FScore()) {
                    lowestF = i;
                }
            }

            Node currentNode = openSet[lowestF];
            openSet.Remove(currentNode);
            if(currentNode == end) {
                List<Node> path = new List<Node>();

                path.Insert(0, end);

                while(currentNode != start) {
                    currentNode = currentNode.camFrom;
                    path.Add(currentNode);
                }

                path.Reverse();
                return path;
            }
        }

        return null;
    }
}
