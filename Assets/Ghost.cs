using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Ghost : MonoBehaviour {
	public bool isDead;
	public int counter, maxCounter;
	//public Vector3 pos;TODO: I do not think we will use this
	public FSM machine;
	public List<Vector3> path;
	public ScWizard wizard;

	public void setup(int x, int y) {
		isDead = true;
		maxCounter = 150;
		counter = 0;
		wizard = GameObject.Find ("Wizard").GetComponent<ScWizard> ();
	}

	//Will find what location PacMan is closest to and return this value as a Vector
	public Vector3 pamanPos() {
		return new Vector3(Mathf.Round(wizard.pacman.transform.position.x), Mathf.Round(wizard.pacman.transform.position.y));
	}

	// Update is called once per frame
	public void Update () {
		if (!isDead) {
			counter++;
			if (counter == maxCounter) {
				isDead = false;
				counter = 0;
			}
		}
	}
}
