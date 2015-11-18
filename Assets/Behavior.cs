using UnityEngine;

//We will create classes that extend Behavior in order to create behaviors in our tree
public abstract class Behavior {
	public ScWizard wizard;
	
	//Will perform the behavior upon the world
	public abstract void performBehavior();

	//Will reset any variables that will need to be refreshed in the future
	public abstract void notifyChange();
	
	// Use this for initialization
	public void findWizard () {
		wizard = GameObject.Find ("Wizard").GetComponent<ScWizard>();
	}
}
