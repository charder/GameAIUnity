using UnityEngine;
using System.Collections;

public class GhostCheckNormalPac : StateCondition {
	public GhostCheckNormalPac() {
		findWizard ();
	}
	
	public override bool checkCondition(GameObject thisobject, MonoBehaviour thisScript) {
		return !wizard.pacman.isSuper;
	}
}