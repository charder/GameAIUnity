using UnityEngine;

//We will create classes that extend StateCondition in order to create conditions in our Finite State Machine
public abstract class StateCondition : MonoBehaviour {
	public GameObject wizard;
	
	//Will check the condition and return a bool specifying if we should change our current FSM Node. True is yes and false is no.
	public abstract bool checkCondition(GameObject thisObject);
	
	// Use this for initialization
	void Start () {
		wizard = GameObject.Find ("Wizard");
	}
}