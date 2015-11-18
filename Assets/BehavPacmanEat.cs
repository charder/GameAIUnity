using UnityEngine;
using System.Collections.Generic;

public class BehavPacmanEat : Behavior {
	public LinkedList<Vector3> path;

	public BehavPacmanEat() {
		findWizard ();
	}

	public override void performBehavior() {
		if (path == null || path.Count <= 0) {
			float dist = float.MaxValue;
			int x = (int) wizard.pacman.transform.position.x;
			int y = (int) wizard.pacman.transform.position.y;
			
			for (int i = 0; i < wizard.world.points.GetLength(0); i++) {
				for (int j = 0; j < wizard.world.points.GetLength(1); j++) {
					if (wizard.world.points[i, j] != null) {
						float currentDist = Vector3.Distance(wizard.pacman.transform.position, new Vector3(j, i));
						
						if (currentDist < dist) {
							dist = currentDist;
							x = j;
							y = i;
						}
					}
				}
			}
			path = wizard.world.findPath (wizard.pacman.transform.position, new Vector3(x, y));
		}
		wizard.pacman.transform.position = new Vector3(path.First.Value.x, path.First.Value.y, -2);
		path.RemoveFirst ();
	}
}