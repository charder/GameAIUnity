using UnityEngine;
using System.Collections;

public class GhostDie : StateCondition {
	public GhostDie() {
		findWizard ();
	}

	public override bool checkCondition(GameObject thisobject, MonoBehaviour thisScript)
	{
		return (Vector3.Distance (thisobject.transform.position, wizard.pacman.transform.position) < 1 && wizard.pacman.isSuper);
	}
}
