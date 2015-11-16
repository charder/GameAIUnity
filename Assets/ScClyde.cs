using UnityEngine;
using System.Collections;

public class ScClyde : Ghost {

	// Use this for initialization
	public void Start () {
		StateNode seek = new StateNode("Seek", new BehavClydeSeek());
		StateNode evade = new StateNode("Evade", new BehavClydeEvade());
		StateNode dead = new StateNode("Dead", new BehavClydeDead());
		
		seek.addEdge(new StateEdge(seek, evade, new GhostCheckPellet()));
		evade.addEdge(new StateEdge(evade, dead, new GhostDie()));
		dead.addEdge(new StateEdge (dead, seek, new GhostRespawn()));
		
		machine = new FSM (seek);
	}
}
