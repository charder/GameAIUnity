using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node {
	public Dictionary<string, Node> edges;
	public Node parent;
	public float rawCost;
	public float heuristicCost;
	public int heightPos;
	public int widthPos;
	public string name;

	public Node(int height, int width) {
		edges = new Dictionary<string, Node> ();
		parent = null;
		rawCost = float.MaxValue;
		heuristicCost = 0.0f;
		heightPos = height;
		widthPos = width;
		name = "(" + heightPos.ToString () + "," + widthPos.ToString () + ")";
	}

	public void addEdge(Node edge) {
		if (!this.containsEdge (edge)) {
			edges.Add(edge.name, edge);
		}
	}

	public bool containsEdge(Node edge) {
		return edges.ContainsKey (edge.name);
	}

	public float totalCost() {
		return rawCost + heuristicCost;
	}
}
