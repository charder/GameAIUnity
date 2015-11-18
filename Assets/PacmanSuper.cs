using UnityEngine;
using System.Collections;

//Pacman Super will check if pacman needs to become super
public class PacmanSuper : StateCondition {
	Sprite ghostrun;
	public PacmanSuper() {
		findWizard ();
		ghostrun = Resources.Load<Sprite>("GhostRun");
	}

	public override bool checkCondition(GameObject thisobject, MonoBehaviour thisScript)
	{
		Vector3 pacPos = wizard.pacman.pacmanPos ();
		int y = (int)pacPos.y;
		int x = (int)pacPos.x;
		bool[,] superPellets = wizard.world.boolSuperPellets;
		if (y < superPellets.GetLength (0) && y >= 0 && x < superPellets.GetLength (1) && x >= 0) {
			if (superPellets[y, x] == true) {
				wizard.world.boolSuperPellets [y, x] = false;//First turn the super pellet off
				wizard.pacman.points += 4;//Add extra points for eating a super pellet
				wizard.blinky.GetComponent<SpriteRenderer>().sprite = ghostrun;
				wizard.pinky.GetComponent<SpriteRenderer>().sprite = ghostrun;
				wizard.inky.GetComponent<SpriteRenderer>().sprite = ghostrun;
				wizard.clyde.GetComponent<SpriteRenderer>().sprite = ghostrun;
				wizard.pacman.isSuper = true;
				return true;
			}
		}
		return false;
	}
}
