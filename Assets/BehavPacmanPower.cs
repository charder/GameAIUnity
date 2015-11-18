using UnityEngine;
using System.Collections.Generic;

public class BehavPacmanPower : Behavior {
	public LinkedList<Vector3> path;

	public BehavPacmanPower() {
		findWizard ();
	}

	public override void notifyChange() {
		path = null;
	}

	public override void performBehavior() {
		if (path == null || path.Count <= 0) {
			string ghost = "";
			float dist = float.MaxValue;
			float currentDist;
			
			currentDist = Vector3.Distance (wizard.blinky.transform.position, wizard.pacman.transform.position);
			if (currentDist < dist) {
				dist = currentDist;
				ghost = "B";
			}
			
			currentDist = Vector3.Distance (wizard.pinky.transform.position, wizard.pacman.transform.position);
			if (currentDist < dist) {
				dist = currentDist;
				ghost = "P";
			}
			
			currentDist = Vector3.Distance (wizard.inky.transform.position, wizard.pacman.transform.position);
			if (currentDist < dist) {
				dist = currentDist;
				ghost = "I";
			}
			
			currentDist = Vector3.Distance (wizard.clyde.transform.position, wizard.pacman.transform.position);
			if (currentDist < dist) {
				dist = currentDist;
				ghost = "C";
			}
			
			if (ghost == "B") {
				path = wizard.world.findPath(wizard.pacman.transform.position, wizard.blinky.transform.position);
			} else if (ghost == "P") {
				path = wizard.world.findPath(wizard.pacman.transform.position, wizard.pinky.transform.position);
			} else if (ghost == "I") {
				path = wizard.world.findPath(wizard.pacman.transform.position, wizard.inky.transform.position);
			} else if (ghost == "C") {
				path = wizard.world.findPath(wizard.pacman.transform.position, wizard.clyde.transform.position);
			}
		}
		wizard.pacman.transform.position = new Vector3(path.First.Value.x, path.First.Value.y, -2);
		path.RemoveFirst ();
	}
}