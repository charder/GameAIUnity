using UnityEngine;

//We will create classes that extend Behavior in order to create behaviors in our tree
public abstract class Behavior {
	GameObject wizard;
	
	//Will perform the behavior upon the world
	public abstract void performBehavior();
	
	// Use this for initialization
	public void findWizard () {
		wizard = GameObject.Find ("Wizard");
	}
}
