using UnityEngine;
using System.Collections;

public class ScPacman : MonoBehaviour {
	public bool isSuper;
	//public Vector3 pos;TODO: Do not think we need this
	public int superCouter, maxSuperCounter;
	//TODO: Create all of the FSM Nodes and edges, BehaviorTree nodes for each FSM Node

	// Use this for initialization
	void Start () {
		isSuper = false;
		superCouter = 0;
		maxSuperCounter = 150;
	}
	
	// Update is called once per frame
	void Update () {
		if (isSuper) {
			superCouter++;
			if (superCouter == maxSuperCounter) {
				isSuper = false;
				superCouter = 0;
			}
		}
	}
}
