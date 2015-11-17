using UnityEngine;
using System.Collections;

public class ScPacman : MonoBehaviour {
	public bool isSuper;
	//public Vector3 pos;TODO: Do not think we need this
	public int superCouter, maxSuperCounter;
	public ScWizard wizard;

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
