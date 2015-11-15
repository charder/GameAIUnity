using UnityEngine;
using System.Collections;

public class GhostRespawn : StateCondition {
	public override bool checkCondition(GameObject thisObject, MonoBehaviour thisScript) {
		return false;
		/*//TODO: Behavior stuff
		if (wizard.world.currentMap == "hrt201n") {
			if (thisObject.name == "Blinky") {
				thisObject.transform.position = new Vector3();
			} else if (thisObject.name == "Pinky") {

			} else if (thisObject.name == "Inky") {

			} else if (thisObject.name == "Clyde") {

			}
		} else {
			if (thisObject.name == "Blinky") {
				
			} else if (thisObject.name == "Pinky") {
				
			} else if (thisObject.name == "Inky") {
				
			} else if (thisObject.name == "Clyde") {
				
			}
		}
		*/
	}
}
