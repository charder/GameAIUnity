using UnityEngine;
using System.Collections;

//Will check if pacman needs to become normal or not
public class PacmanDead : StateCondition {
	public PacmanDead() {
		findWizard ();
	}
	
	public override bool checkCondition(GameObject thisobject, MonoBehaviour thisScript)
	{
		Vector3 pos1 = wizard.blinky.gameObject.transform.position;
		Vector3 pos2 = wizard.pinky.gameObject.transform.position;
		Vector3 pos3 = wizard.inky.gameObject.transform.position;
		Vector3 pos4 = wizard.clyde.gameObject.transform.position;
		Vector3 mine = wizard.pacman.gameObject.transform.position;

		return (Vector3.Distance (pos1, mine) < 1.0f) || (Vector3.Distance (pos2, mine) < 1.0f) || (Vector3.Distance (pos3, mine) < 1.0f) || (Vector3.Distance (pos4, mine) < 1.0f);
	}
}