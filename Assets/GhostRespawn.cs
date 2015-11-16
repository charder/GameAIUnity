using UnityEngine;
using System.Collections;

public class GhostRespawn : StateCondition {
	public GhostRespawn() {
		findWizard ();
	}

	public override bool checkCondition(GameObject thisObject, MonoBehaviour thisScript) {
		Ghost spooky = (Ghost)thisScript;
		return (!spooky.isDead);
	}
}
