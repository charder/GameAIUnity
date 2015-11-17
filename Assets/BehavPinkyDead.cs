using UnityEngine;

public class BehavPinkyDead : Behavior {
	public BehavPinkyDead() {
		findWizard ();
	}

	//Send Pinky to the death box
	public override void performBehavior() {
		if (wizard.world.currentMap == "hrt201n") {
			wizard.pinky.transform.position = new Vector3(98, 68, -2);
		} else {
			wizard.pinky.transform.position = new Vector3(71, 52, -2);
		}
	}
}