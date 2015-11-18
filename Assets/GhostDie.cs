using UnityEngine;
using System.Collections;

public class GhostDie : StateCondition {
	public GhostDie() {
		findWizard ();
	}

	public override bool checkCondition(GameObject thisobject, MonoBehaviour thisScript)
	{
		bool result = Vector3.Distance (thisobject.transform.position, wizard.pacman.transform.position) < 1 && wizard.pacman.isSuper;
		if (result) {
			Ghost spooky = (Ghost) thisScript;
			spooky.isDead = true;
			return true;
		}
		return false;
	}
}
