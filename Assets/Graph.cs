using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Graph {
	public Dictionary<string, Node> nodes;

	public Graph() {
		nodes = new Dictionary<string, Node> ();
	}

	public bool contains(Node possibleNode) {
		return nodes.ContainsKey (possibleNode.name);
	}

	public void addNode(Node addNode) {
		if (!this.contains (addNode)) {
			nodes.Add (addNode.name, addNode);
		}
	}
	
	public void addEdge(Node source, Node dest) {
		if (this.contains (source)) {
			Node truSource = null;
			nodes.TryGetValue(source.name, out truSource);
			truSource.addEdge(dest);
		}
	}

	public Node getNodeByLocation(int height, int width) {
		string possibleKey = "(" + height.ToString () + "," + width.ToString () + ")";
		if (nodes.ContainsKey(possibleKey)) {
			Node result;
			nodes.TryGetValue(possibleKey, out result);
			return result;
		} else {
			return null;
		}
	}
}
