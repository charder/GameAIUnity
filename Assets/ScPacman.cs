using UnityEngine;
using System.Collections;

public class ScPacman : MonoBehaviour {
	public bool isSuper;
	//public Vector3 pos;TODO: Do not think we need this
	public int superCouter, maxSuperCounter;
	public ScWizard wizard;
	public FSM machine;
	public int points;

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

		points = 0;
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

		//Here is where we eat pellets (This happens independently of state)
		if (wizard.world.points [(int) transform.position.y, (int) transform.position.x] != null) {
			Destroy(wizard.world.points [(int) transform.position.y, (int) transform.position.x]);
			points += 1;
		}

		//Each frame, check if we need to change our state, and then do the behavior
		machine.possibleStateChange (this.gameObject, this);
		machine.performBehavior ();
	}
}
