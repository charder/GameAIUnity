using UnityEngine;

public class BehavBlinkyDead : Behavior {
	public BehavBlinkyDead() {
		findWizard ();
	}

	public override void notifyChange() {
		//Nothing needed
	}

	//Send Blinky to the death box
	public override void performBehavior() {
		if (wizard.world.currentMap == "hrt201n") {
			wizard.blinky.transform.position = new Vector3(97, 68, -2);
		} else {
			wizard.blinky.transform.position = new Vector3(70, 52, -2);
		}
	}
}