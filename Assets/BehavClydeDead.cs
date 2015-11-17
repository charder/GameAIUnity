using UnityEngine;

public class BehavClydeDead : Behavior {
	public BehavClydeDead() {
		findWizard ();
	}

	//Send Clyde to the death box
	public override void performBehavior() {
		if (wizard.world.currentMap == "hrt201n") {
			wizard.clyde.transform.position = new Vector3(98, 67, -2);
		} else {
			wizard.clyde.transform.position = new Vector3(71, 51, -2);
		}
	}
}