using System.Collections.Generic;
using UnityEngine;

//FSM represents a finite state machine. Internally it stores the active node in an FSM and functions to see if the 
//	active node needs to change and to perform the behavior associated with the active node
public class FSM {
	private StateNode currentNode;

	//constructor will set the current Node;
	public FSM(StateNode start) {
		currentNode = start;
	}
		
	//Will check if the current node needs changing and do so if needed;
	public void possibleStateChange(GameObject thisObject, MonoBehaviour thisScript) {
		currentNode = currentNode.checkState(thisObject, thisScript);
	}

	//Will tell the decision tree of the current node to do a behavior
	public void performBehavior() {
		currentNode.performBehavior ();
	}
}