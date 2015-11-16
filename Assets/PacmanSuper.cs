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
		if (wizard.world.boolSuperPellets [(int) thePac.pos.y, (int) thePac.pos.x] == true) {
			wizard.world.boolSuperPellets [(int) thePac.pos.y, (int) thePac.pos.x] = false;//First turn the super pellet off
			return true;
		}
		return false;
	}
}
