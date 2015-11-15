using UnityEngine;
using System.Collections;

public class GhostDie : StateCondition {
	public bool checkCondition(GameObject thisobject)
	{
		return (Vector3.Distance(thisobject.transform.position,wizard.pacman.transform.position) < 1 && wizard.pacman.isSuper)
	}
}
