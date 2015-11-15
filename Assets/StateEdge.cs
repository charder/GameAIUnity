using UnityEngine;

//StateEdge represents an Edge in a Finite State Machine
public class StateEdge {
	private StateCondition condition;
	private StateNode fromNode, endNode;

	//Will set the comparator the the given one
	public StateEdge(StateNode from, StateNode end, StateCondition cond) {
		fromNode = from;
		endNode = end;
		condition = cond;
	}

	//Will check if the condition for this edge is met. If so, the end Node will be returned, else the same node will be returned
	public StateNode checkEdgeCondition(GameObject thisObject, MonoBehaviour thisScript) {
		bool result = condition.checkCondition (thisObject, thisScript);
		if (result) {
			return endNode;
		} else {
			return fromNode;
		}
	}
}
