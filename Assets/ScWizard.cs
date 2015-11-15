using UnityEngine;
using System.Collections;


//The wizard is responsible for creating the GUI, forming the World, and holding references to other GameObjects. Not going to lie, he is a busy man.
public class ScWizard : MonoBehaviour {
	public ScPacman pacman;
	public ScBlinky blinky;
	public ScPinky pinky;
	public ScInky inky;
	public ScClyde clyde;
	public GameObject basePowerPoint;
	public WorldCreator world;
	//TODO: Copy over the old code that creates the world out of the files and store references to the ghosts, pacman, etc. WIZARDS KNOW EVERYTHING!!!!!!!!!1!!!!!

	// Use this for initialization
	void Start () {
		pacman = GameObject.Find("Pacman").GetComponent<ScPacman>();
		blinky = GameObject.Find ("Blinky").GetComponent<ScBlinky> ();
		pinky = GameObject.Find("Pinky").GetComponent<ScPinky> ();
		inky = GameObject.Find("Inky").GetComponent<ScInky> ();
		clyde = GameObject.Find ("Clyde").GetComponent<ScClyde>();
		basePowerPoint = GameObject.Find ("PowerPoint");
		world = new WorldCreator ();
		world.createWorld ("hrt201n");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		GUI.Box(new Rect(10,10,150,100), "");
		GUI.Label (new Rect (20, 10, 130, 20), "File to Use:");
		bool setHrtWorld = GUI.Button (new Rect (20, 40, 130, 20), "hrt201n");
		bool setArenaWorld = GUI.Button (new Rect (20, 70, 130, 20), "arena2");

		//Check if we need to reload our world
		if (setHrtWorld) {
			world.cleanUpGraph();
			world.createWorld ("hrt201n");
		} else if (setArenaWorld) {
			world.cleanUpGraph();
			world.createWorld ("arena2");
		}
	}
}
