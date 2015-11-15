using UnityEngine;

//We will create classes that extend Condition in order to create conditions in our tree
public abstract class Condition : MonoBehaviour {
	GameObject wizard;

	//Will check the condition and return a bool specifying the left or right node as a result. The left node is true, the right node is false
	public abstract bool evaluateCondition();

	// Use this for initialization
	void Start () {
		wizard = GameObject.Find ("Wizard");
	}
}