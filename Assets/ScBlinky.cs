﻿using UnityEngine;
using System.Collections;

public class ScBlinky : Ghost {

	// Use this for initialization
	public void Start () {
		softReset ();
	}

	public void softReset() {
		StateNode seek = new StateNode("Seek", new BehavBlinkySeek());
		StateNode evade = new StateNode("Evade", new BehavBlinkyEvade());
		StateNode dead = new StateNode("Dead", new BehavBlinkyDead());
		
		seek.addEdge(new StateEdge(seek, evade, new GhostCheckPellet()));
		evade.addEdge (new StateEdge (evade, seek, new GhostCheckNormalPac ()));
		evade.addEdge(new StateEdge(evade, dead, new GhostDie()));
		dead.addEdge(new StateEdge (dead, seek, new GhostRespawn()));
		
		machine = new FSM (seek);
	}
}
