using UnityEngine;
using System.Collections;

public class BehavPacmanDead : Behavior {
	public BehavPacmanDead() {
		findWizard ();
	}

	public override void notifyChange() {
		//DO nothing
	}

	public override void performBehavior() {
		wizard.softReset ();
		wizard.pacman.softReset ();
		wizard.blinky.softReset ();
		wizard.pinky.softReset ();
		wizard.inky.softReset ();
		wizard.clyde.softReset ();
	}
}