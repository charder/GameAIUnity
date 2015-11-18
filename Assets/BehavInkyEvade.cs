using UnityEngine;
using System.Collections.Generic;

public class BehavInkyEvade : Behavior {
	public LinkedList<Vector3> path;
	public int pathCounter;

	public BehavInkyEvade() {
		findWizard ();
		pathCounter = 10;
	}

	public override void notifyChange() {
		pathCounter = 10;
		path = null;
	}

	public override void performBehavior() {
		if (pathCounter == 10 || path.Count == 0) {
			path = wizard.world.findPath (wizard.inky.transform.position, wizard.pacman.transform.position);
			pathCounter = 0;
		} else {
			pathCounter++;
		}
		if (path.Count > 0) {
			wizard.inky.transform.position = new Vector3(path.First.Value.x, path.First.Value.y, -2);
			path.RemoveFirst ();
		}
	}
}