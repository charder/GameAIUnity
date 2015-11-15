using UnityEngine;
using System.Collections;

public class GhostCheckPellet : StateCondition {
	public override bool checkCondition(GameObject thisobject, MonoBehaviour thisScript)
	{
		return wizard.pacman.isSuper;
	}
}
