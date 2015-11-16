using UnityEngine;
using System.Collections;

public class ScPinky : Ghost {
	// Use this for initialization
	public void Start () {
		StateNode seek = new StateNode("Seek", new BehavPinkySeek());
		StateNode evade = new StateNode("Evade", new BehavPinkyEvade());
		StateNode dead = new StateNode("Dead", new BehavPinkyDead());
		
		seek.addEdge(new StateEdge(seek, evade, new GhostCheckPellet()));
		evade.addEdge(new StateEdge(evade, dead, new GhostDie()));
		dead.addEdge(new StateEdge (dead, seek, new GhostRespawn()));
		
		machine = new FSM (seek);
	}
}
