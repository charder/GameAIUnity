using UnityEngine;
using System.Collections;

//Pacman Super will check if pacman needs to become super
public class PacmanSuper : StateCondition {
	public PacmanSuper() {
		findWizard ();
	}

	public override bool checkCondition(GameObject thisobject, MonoBehaviour thisScript)
	{
		ScPacman thePac = (ScPacman)thisScript;
		Vector3 pacPos = wizard.pacman.pacmanPos ();
		int y = (int)pacPos.y;
		int x = (int)pacPos.x;
		bool[,] superPellets = wizard.world.boolSuperPellets;
		if (y < superPellets.GetLength (0) && y >= 0 && x < superPellets.GetLength (1) && x >= 0) {
			if (superPellets[y, x] == true) {
				wizard.world.boolSuperPellets [(int) pacPos.y, (int) pacPos.x] = false;//First turn the super pellet off
				return true;
			}
		}
		return false;
	}
}
