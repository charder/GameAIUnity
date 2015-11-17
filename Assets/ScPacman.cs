using UnityEngine;
using System.Collections;

public class ScPacman : MonoBehaviour {
	public bool isSuper;
	//public Vector3 pos;TODO: Do not think we need this
	public int superCouter, maxSuperCounter;
	public ScWizard wizard;
	public FSM machine;

	//Will find what location PacMan is closest to and return this value as a Vector
	public Vector3 pacmanPos() {
		return new Vector3(Mathf.Round(wizard.pacman.transform.position.x), Mathf.Round(wizard.pacman.transform.position.y));
	}

	// Use this for initialization
	void Start () {
		isSuper = false;
		superCouter = 0;
		maxSuperCounter = 150;
		wizard = GameObject.Find ("Wizard").GetComponent<ScWizard> ();

		StateNode dead = new StateNode ("Dead", new BehavPacmanDead() );
		StateNode normal = new StateNode ("Normal", new BehavPacmanEat ());
		StateNode beSuper = new StateNode ("Super", new BehavPacmanPower ());
		normal.addEdge (new StateEdge(normal, beSuper, new PacmanSuper ()));
		normal.addEdge (new StateEdge(normal, dead, new PacmanDead ()));
		beSuper.addEdge (new StateEdge(beSuper, normal, new PacmanNormalize ()));
		machine = new FSM (normal);
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

		//Each frame, check if we need to change our state, and then do the behavior
		machine.possibleStateChange (this.gameObject, this);
		machine.performBehavior ();
	}
}
