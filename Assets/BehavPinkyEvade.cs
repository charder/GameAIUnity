using UnityEngine;

public class BehavPinkyEvade : Behavior {
	public BehavPinkyEvade() {
		findWizard ();
	}

	public override void performBehavior() {
		int diffX = (int)wizard.pacman.transform.position.x - (int)wizard.pinky.transform.position.x;
		int diffY = (int)wizard.pacman.transform.position.y - (int)wizard.pinky.transform.position.y;
		int pinkyX = (int)wizard.pinky.transform.position.x;
		int pinkyY = (int)wizard.pinky.transform.position.y;
		bool moveX = Mathf.Abs (diffX) > Mathf.Abs (diffY); //whether or not the x distance is greater (priority of direction to move)
		if (diffY > 0) { //pacman is above you
			if (diffX > 0) {//pacman is right of you
				if (moveX && wizard.world.boolTiles[pinkyY,pinkyX - 1])
				{
					wizard.pinky.transform.position = new Vector3 (pinkyX - 1,pinkyY,-2);
				}
				else if (wizard.world.boolTiles[pinkyY - 1,pinkyY])
				{
					wizard.pinky.transform.position = new Vector3 (pinkyX,pinkyY - 1,-2);
				}
				if (wizard.world.boolTiles[pinkyY,pinkyX - 1])
				{
					wizard.pinky.transform.position = new Vector3 (pinkyX - 1,pinkyY,-2);
				}
			}
			else { //pacman is left of you
				if (moveX && wizard.world.boolTiles[pinkyY,pinkyX + 1])
				{
					wizard.pinky.transform.position = new Vector3 (pinkyX + 1,pinkyY,-2);
				}
				else if (wizard.world.boolTiles[pinkyY - 1,pinkyX])
				{
					wizard.pinky.transform.position = new Vector3 (pinkyX,pinkyY - 1,-2);
				}
				else if (wizard.world.boolTiles[pinkyY,pinkyX + 1])
				{
					wizard.pinky.transform.position = new Vector3 (pinkyX + 1,pinkyY,-2);
				}
			}
		}
		else { //pacman is below you 
			if (diffX > 0) {//pacman is right of you
				if (moveX && wizard.world.boolTiles[pinkyY,pinkyX - 1])
				{
					wizard.pinky.transform.position = new Vector3 (pinkyX - 1,pinkyY,-2);
				}
				else if (wizard.world.boolTiles[pinkyY + 1,pinkyX])
				{
					wizard.pinky.transform.position = new Vector3 (pinkyX,pinkyY + 1,-2);
				}
				else if (wizard.world.boolTiles[pinkyY,pinkyX - 1])
				{
					wizard.pinky.transform.position = new Vector3 (pinkyX - 1,pinkyY,-2);
				}
			}
			else { //pacman is left of you
				if (moveX && wizard.world.boolTiles[pinkyY,pinkyX + 1])
				{
					wizard.pinky.transform.position = new Vector3 (pinkyX + 1,pinkyY,-2);
				}
				else if (wizard.world.boolTiles[pinkyY + 1,pinkyX])
				{
					wizard.pinky.transform.position = new Vector3 (pinkyX,pinkyY + 1,-2);
				}
				else if (wizard.world.boolTiles[pinkyY,pinkyX + 1])
				{
					wizard.pinky.transform.position = new Vector3 (pinkyX + 1,pinkyY,-2);
				}
			}
		}
	}
}