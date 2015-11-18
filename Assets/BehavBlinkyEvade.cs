using UnityEngine;

public class BehavBlinkyEvade : Behavior {
	public BehavBlinkyEvade() {
		findWizard ();
	}

	public override void notifyChange() {
		//DO nothing
	}

	public override void performBehavior() {
		int diffX = (int)wizard.pacman.transform.position.x - (int)wizard.blinky.transform.position.x;
		int diffY = (int)wizard.pacman.transform.position.y - (int)wizard.blinky.transform.position.y;
		int blinkyX = (int)wizard.blinky.transform.position.x;
		int blinkyY = (int)wizard.blinky.transform.position.y;
		bool moveX = Mathf.Abs (diffX) > Mathf.Abs (diffY); //whether or not the x distance is greater (priority of direction to move)
		if (diffY > 0) { //pacman is above you
			if (diffX > 0) {//pacman is right of you
				if (moveX && wizard.world.boolTiles[blinkyY,blinkyX - 1])
				{
					wizard.blinky.transform.position = new Vector3 (blinkyX - 1,blinkyY,-2);
				}
				else if (wizard.world.boolTiles[blinkyY - 1,blinkyY])
				{
					wizard.blinky.transform.position = new Vector3 (blinkyX,blinkyY - 1,-2);
				}
				if (wizard.world.boolTiles[blinkyY,blinkyX - 1])
				{
					wizard.blinky.transform.position = new Vector3 (blinkyX - 1,blinkyY,-2);
				}
			}
			else { //pacman is left of you
				if (moveX && wizard.world.boolTiles[blinkyY,blinkyX + 1])
				{
					wizard.blinky.transform.position = new Vector3 (blinkyX + 1,blinkyY,-2);
				}
				else if (wizard.world.boolTiles[blinkyY - 1,blinkyX])
				{
					wizard.blinky.transform.position = new Vector3 (blinkyX,blinkyY - 1,-2);
				}
				else if (wizard.world.boolTiles[blinkyY,blinkyX + 1])
				{
					wizard.blinky.transform.position = new Vector3 (blinkyX + 1,blinkyY,-2);
				}
			}
		}
		else { //pacman is below you 
			if (diffX > 0) {//pacman is right of you
				if (moveX && wizard.world.boolTiles[blinkyY,blinkyX - 1])
				{
					wizard.blinky.transform.position = new Vector3 (blinkyX - 1,blinkyY,-2);
				}
				else if (wizard.world.boolTiles[blinkyY + 1,blinkyX])
				{
					wizard.blinky.transform.position = new Vector3 (blinkyX,blinkyY + 1,-2);
				}
				else if (wizard.world.boolTiles[blinkyY,blinkyX - 1])
				{
					wizard.blinky.transform.position = new Vector3 (blinkyX - 1,blinkyY,-2);
				}
			}
			else { //pacman is left of you
				if (moveX && wizard.world.boolTiles[blinkyY,blinkyX + 1])
				{
					wizard.blinky.transform.position = new Vector3 (blinkyX + 1,blinkyY,-2);
				}
				else if (wizard.world.boolTiles[blinkyY + 1,blinkyX])
				{
					wizard.blinky.transform.position = new Vector3 (blinkyX,blinkyY + 1,-2);
				}
				else if (wizard.world.boolTiles[blinkyY,blinkyX + 1])
				{
					wizard.blinky.transform.position = new Vector3 (blinkyX + 1,blinkyY,-2);
				}
			}
		}
	}
}