using UnityEngine;

public class BehavInkyDead : Behavior {
	public BehavInkyDead() {
		findWizard ();
	}

	public override void notifyChange() {
		//DO nothing
	}

	//Send Inky to the death box
	public override void performBehavior() {
		if (wizard.world.currentMap == "hrt201n") {
			wizard.inky.transform.position = new Vector3(97, 67, -2);
		} else {
			wizard.inky.transform.position = new Vector3(70, 51, -2);
		}
	}
}