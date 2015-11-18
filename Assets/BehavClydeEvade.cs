using UnityEngine;

public class BehavClydeEvade : Behavior {
	public BehavClydeEvade() {
		findWizard ();
	}

	public override void performBehavior() {
		int random_int = Mathf.FloorToInt(Random.Range (0, 4));
		if (random_int == 0) { //move Clyde Up
			if (wizard.world.boolTiles[(int) this.wizard.clyde.transform.position.y + 1,(int) this.wizard.clyde.transform.position.x])
			{
				wizard.clyde.transform.position = new Vector3(wizard.clyde.transform.position.x, this.wizard.clyde.transform.position.y + 1,-2);
			}
		}
		else if (random_int == 1){ //move Clyde Right
			if (wizard.world.boolTiles[(int) this.wizard.clyde.transform.position.y,(int) this.wizard.clyde.transform.position.x + 1])
			{
				wizard.clyde.transform.position = new Vector3(wizard.clyde.transform.position.x + 1, this.wizard.clyde.transform.position.y,-2);
			}
			
		}
		else if (random_int == 2){ //move Clyde Left
			if (wizard.world.boolTiles[(int) this.wizard.clyde.transform.position.y - 1,(int) this.wizard.clyde.transform.position.x])
			{
				wizard.clyde.transform.position = new Vector3(wizard.clyde.transform.position.x, this.wizard.clyde.transform.position.y - 1,-2);
			}
		}
		else if (random_int == 3){ //move Clyde Up
			if (wizard.world.boolTiles[(int) this.wizard.clyde.transform.position.y,(int) this.wizard.clyde.transform.position.x - 1])
			{
				wizard.clyde.transform.position = new Vector3(wizard.clyde.transform.position.x - 1, this.wizard.clyde.transform.position.y,-2);
			}
		}
	}
}