using UnityEngine;
using System.Collections;

public class GhostCheckPellet : StateCondition {
	public GhostCheckPellet() {
		findWizard ();
	}

	public override bool checkCondition(GameObject thisobject, MonoBehaviour thisScript)
	{
		return wizard.pacman.isSuper;
	}
}
