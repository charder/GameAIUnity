using UnityEngine;

public class BehavInkySeek : Behavior {
	public BehavInkySeek() {
		findWizard ();
	}

	public override void performBehavior() {
		int diffX = (int)wizard.pacman.transform.position.x - (int)wizard.inky.transform.position.x;
		int diffY = (int)wizard.pacman.transform.position.y - (int)wizard.inky.transform.position.y;
		int inkyX = (int)wizard.inky.transform.position.x;
		int inkyY = (int)wizard.inky.transform.position.y;
		bool moveX = Mathf.Abs (diffX) > Mathf.Abs (diffY); //whether or not the x distance is greater (priority of direction to move)
		if (diffY > 0) { //pacman is above you
			if (diffX > 0) {//pacman is right of you
				if (moveX && wizard.world.boolTiles[inkyY,inkyX - 1])
				{
					wizard.inky.transform.position = new Vector3 (inkyX - 1,inkyY,-2);
				}
				else if (wizard.world.boolTiles[inkyY - 1,inkyY])
				{
					wizard.inky.transform.position = new Vector3 (inkyX,inkyY - 1,-2);
				}
				if (wizard.world.boolTiles[inkyY,inkyX - 1])
				{
					wizard.inky.transform.position = new Vector3 (inkyX - 1,inkyY,-2);
				}
			}
			else { //pacman is left of you
				if (moveX && wizard.world.boolTiles[inkyY,inkyX + 1])
				{
					wizard.inky.transform.position = new Vector3 (inkyX + 1,inkyY,-2);
				}
				else if (wizard.world.boolTiles[inkyY - 1,inkyX])
				{
					wizard.inky.transform.position = new Vector3 (inkyX,inkyY - 1,-2);
				}
				else if (wizard.world.boolTiles[inkyY,inkyX + 1])
				{
					wizard.inky.transform.position = new Vector3 (inkyX + 1,inkyY,-2);
				}
			}
		}
		else { //pacman is below you 
			if (diffX > 0) {//pacman is right of you
				if (moveX && wizard.world.boolTiles[inkyY,inkyX - 1])
				{
					wizard.inky.transform.position = new Vector3 (inkyX - 1,inkyY,-2);
				}
				else if (wizard.world.boolTiles[inkyY + 1,inkyX])
				{
					wizard.inky.transform.position = new Vector3 (inkyX,inkyY + 1,-2);
				}
				else if (wizard.world.boolTiles[inkyY,inkyX - 1])
				{
					wizard.inky.transform.position = new Vector3 (inkyX - 1,inkyY,-2);
				}
			}
			else { //pacman is left of you
				if (moveX && wizard.world.boolTiles[inkyY,inkyX + 1])
				{
					wizard.inky.transform.position = new Vector3 (inkyX + 1,inkyY,-2);
				}
				else if (wizard.world.boolTiles[inkyY + 1,inkyX])
				{
					wizard.inky.transform.position = new Vector3 (inkyX,inkyY + 1,-2);
				}
				else if (wizard.world.boolTiles[inkyY,inkyX + 1])
				{
					wizard.inky.transform.position = new Vector3 (inkyX + 1,inkyY,-2);
				}
			}
		}
	}
}