using UnityEngine;

//We will create classes that extend StateCondition in order to create conditions in our Finite State Machine
public abstract class StateCondition {
	public ScWizard wizard;
	
	//Will check the condition and return a bool specifying if we should change our current FSM Node. True is yes and false is no.
	public abstract bool checkCondition(GameObject thisObject, MonoBehaviour thisScript);
	
	// Use this for initialization
	public void findWizard () {
		wizard = GameObject.Find ("Wizard").GetComponent<ScWizard>();
	}
}