using UnityEngine;
using System.Collections;

public abstract class Ghost : MonoBehaviour {
	public bool isDead;
	public int counter, maxCounter;
	public Vector3 pos;

	public void setup(int x, int y) {
		isDead = true;
		maxCounter = 150;
		counter = 0;

		transform.position = new Vector3 (x, y);
	}

	// Use this for initialization
	public void Start () {

	}
	
	// Update is called once per frame
	public void Update () {
		counter++;
		if (counter == maxCounter) {
			isDead = false;
		}
	}
}
