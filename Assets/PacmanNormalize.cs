using UnityEngine;
using System.Collections;

//Will check if pacman needs to become normal or not
public class PacmanNormalize : StateCondition {
	public PacmanNormalize() {
		findWizard ();
	}

	public override bool checkCondition(GameObject thisobject, MonoBehaviour thisScript)
	{
		ScPacman thePac = (ScPacman)thisScript;
		return (!thePac.isSuper);
	}
}
