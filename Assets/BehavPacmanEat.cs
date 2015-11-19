using UnityEngine;
using System.Collections.Generic;

public class BehavPacmanEat : Behavior {
	public LinkedList<Vector3> path;

	public BehavPacmanEat() {
		findWizard ();
	}

	public override void notifyChange() {
		path = null;
	}

	public override void performBehavior() {
		if (path == null || path.Count <= 0) {
			bool superPellet = false; //whether or not a super pellet is nearby
			float dist = float.MaxValue;
			int x = (int) wizard.pacman.transform.position.x;
			int y = (int) wizard.pacman.transform.position.y;
			
			for (int i = 0; i < wizard.world.points.GetLength(0); i++) {
				for (int j = 0; j < wizard.world.points.GetLength(1); j++) {
					if (wizard.world.points[i, j] != null && !wizard.world.boolSuperPellets[i,j]) {
						float currentDist = Vector3.Distance(wizard.pacman.transform.position, new Vector3(j, i));
						
						if (currentDist < dist) {
							dist = currentDist;
							x = j;
							y = i;
						}
						//if two distances are equal, it basically flips a coin and returns that
						else if (!superPellet && currentDist == dist && Random.Range((int)0,(int)2) == 1) {
							dist = currentDist;
							x = j;
							y = i;
						}
		
					}
					else if (wizard.world.points[i,j] != null && wizard.world.boolSuperPellets[i,j])
					{
						float currentDist = Vector3.Distance(wizard.pacman.transform.position, new Vector3(j, i));
						
						if (currentDist <= dist) {
							superPellet = true;
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