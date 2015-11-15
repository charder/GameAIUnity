using System.Collections.Generic;
using UnityEngine;

//StateNode represents a Node of a Finite State Machine
public class StateNode {
	private string name;
	private List<StateEdge> edges;
	private BehaviorTree tree;

	//A constructor that will set the name and Behavior tree of this Node and will instantiate the list of State Edges
	public StateNode(string name_, BehaviorTree tree_) {
		name = name_;
		edges = new List<StateEdge> ();
		tree = tree_;
	}

	//Will tell you the state node you should change to if needed
	public StateNode checkState(GameObject thisObject) {
		StateNode result;
		foreach (StateEdge edge in edges) {
			result = edge.checkEdgeCondition(thisObject);

			if (result != this) {
				return result;
			}
		}
		return this;
	}

	//Will return the name
	public string getName() {
		return name;
	}
	
	//Will add an edge to the FSM
	public void addEdge(StateEdge edge) {
		edges.Add (edge);
	}

	//Will tell the decision tree to do a behavior
	public void performBehavior() {
		tree.doBehavior ();
	}
}
