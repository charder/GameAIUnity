using UnityEngine;
using System.Collections;
using System;


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

	//Will place all of the ghosts and paman in the world
	public void placeWorldCharacters() {
		if (world.currentMap == "hrt201n") {
			blinky.transform.position = new Vector3(97, 68, -2);
			//blinky.pos = new Vector3(97, 68);//TODO: I commented these out (I do not think they are necessary and some of them are wrong anyways :P)
			pinky.transform.position = new Vector3(98, 68, -2);
			//blinky.pos = new Vector3(98, 68);
			inky.transform.position = new Vector3(97, 67, -2);
			//inky.pos = new Vector3(97, 67);
			clyde.transform.position = new Vector3(98, 67, -2);
			//clyde.pos = new Vector3(98, 67);

			pacman.transform.position = new Vector3(97, 65, -2);
			//pacman.pos = new Vector3(97, 65);

		} else if (world.currentMap == "arena2") {
			blinky.transform.position = new Vector3(70, 52, -2);
			//blinky.pos = new Vector3(70, 52);
			pinky.transform.position = new Vector3(71, 52, -2);
			//blinky.pos = new Vector3(71, 52);
			inky.transform.position = new Vector3(70, 51, -2);
			//inky.pos = new Vector3(60, 51);
			clyde.transform.position = new Vector3(71, 51, -2);
			//clyde.pos = new Vector3(71, 51);

			pacman.transform.position = new Vector3(70, 49, -2);
			//pacman.pos = new Vector3(70, 49, -2);
		}
	}

	//Will put a super pellet on the tile that is clicked on
	public void makeSuperPoint() {
		Vector3 pos = Input.mousePosition;
		if (pos.x > 160 || pos.y < Screen.height - 150) {
			pos.z = 10.0f;
			pos = Camera.main.ScreenToWorldPoint (pos);

			int closestHeight = -1;
			int closestWidth = -1;
			float dist = 1.0f;
			
			for (int i = 0; i < world.points.GetLength(0); i++) {
				for (int j = 0; j < world.points.GetLength(1); j++) {
					if (world.points [i, j] != null) {
						float currentDist = Vector2.Distance (new Vector2 (world.points [i, j].transform.position.x, world.points [i, j].transform.position.y), new Vector2 (pos.x, pos.y));
						if (currentDist < dist) {
							dist = currentDist;
							closestHeight = i;
							closestWidth = j;
						}
					}
				}
			}

			if (closestWidth != -1 && closestHeight != -1) {
				world.points[closestHeight, closestWidth].GetComponent<SpriteRenderer>().sprite = basePowerPoint.GetComponent<SpriteRenderer>().sprite;
				world.boolSuperPellets[closestHeight, closestWidth] = true;
			}
		}
	}

	//Will move Pacman to the closest open clicked point, allows for better AI testing
	public void movePacman() {
		Vector3 pos = Input.mousePosition;
		if (pos.x > 160 || pos.y < Screen.height - 150) {
			pos.z = 10.0f;
			pos = Camera.main.ScreenToWorldPoint (pos);
			
			int closestHeight = -1;
			int closestWidth = -1;
			float dist = 1.0f;
			
			for (int i = 0; i < world.boolTiles.GetLength(0); i++) {
				for (int j = 0; j < world.boolTiles.GetLength(1); j++) {
					if (world.boolTiles [i, j]) {
						float currentDist = Vector2.Distance (new Vector2 (j, i), new Vector2 (pos.x, pos.y));
						if (currentDist < dist) {
							dist = currentDist;
							closestHeight = i;
							closestWidth = j;
						}
					}
				}
			}
			
			if (closestWidth != -1 && closestHeight != -1) {
				pacman.transform.position = new Vector3 (closestWidth, closestHeight, -2);
				pacman.GetComponent<ScPacman>().machine.currentNode.notifyChange();
			}
		}
	}

	// Use this for initialization
	void Start () {
		pacman = GameObject.Find("Pacman").GetComponent<ScPacman>();
		blinky = GameObject.Find ("Blinky").GetComponent<ScBlinky> ();
		pinky = GameObject.Find("Pinky").GetComponent<ScPinky> ();
		inky = GameObject.Find("Inky").GetComponent<ScInky> ();
		clyde = GameObject.Find ("Clyde").GetComponent<ScClyde>();

		basePowerPoint = GameObject.Find ("PowerPoint");

		softReset ();
	}

	public void softReset() {
		if (world != null) {
			world.cleanUpGraph ();
		}
		world = new WorldCreator ();
		world.createWorld ("hrt201n");

		placeWorldCharacters ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {	//If the user left clicks, find start node
			makeSuperPoint();
		}
		if (Input.GetMouseButtonDown (1)) {//If the user right clicks, moves pacman 
			movePacman();
		}
	}

	void OnGUI() {
		GUI.Box(new Rect(10,10,150,130), "");
		GUI.Label (new Rect (20, 10, 130, 20), "File to Use:");
		bool setHrtWorld = GUI.Button (new Rect (20, 40, 130, 20), "hrt201n");
		bool setArenaWorld = GUI.Button (new Rect (20, 70, 130, 20), "arena2");
		GUI.Label (new Rect (20, 100, 130, 20), "PacMan Points: " + Convert.ToString(pacman.points));

		//Check if we need to reload our world
		if (setHrtWorld) {
			pacman.GetComponent<ScPacman>().machine.currentNode.notifyChange();
			blinky.GetComponent<ScBlinky> ().machine.currentNode.notifyChange ();
			world.cleanUpGraph();
			world.createWorld ("hrt201n");
			placeWorldCharacters();
			pacman.points = 0;
		} else if (setArenaWorld) {
			pacman.GetComponent<ScPacman>().machine.currentNode.notifyChange();
			blinky.GetComponent<ScBlinky> ().machine.currentNode.notifyChange ();
			world.cleanUpGraph();
			world.createWorld ("arena2");
			placeWorldCharacters();
			pacman.points = 0;
		}
	}
}
