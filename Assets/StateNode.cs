using System.Collections.Generic;
using UnityEngine;

//StateNode represents a Node of a Finite State Machine
public class StateNode {
	private string name;
	private List<StateEdge> edges;
	private Behavior behav;

	//A constructor that will set the name and Behavior tree of this Node and will instantiate the list of State Edges
	public StateNode(string name_, Behavior behav_) {
		name = name_;
		edges = new List<StateEdge> ();
		behav = behav_;
	}

	//Will tell you the state node you should change to if needed
	public StateNode checkState(GameObject thisObject, MonoBehaviour thisScript) {
		StateNode result;
		foreach (StateEdge edge in edges) {
			result = edge.checkEdgeCondition(thisObject, thisScript);

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

	//Will reset any of the variables in a behavior
	public void notifyChange() {
		behav.notifyChange ();
	}

	//Will tell the decision tree to do a behavior
	public void performBehavior() {
		behav.performBehavior ();
	}
}
