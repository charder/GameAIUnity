using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;

public class WorldCreator { //Destroy & Print seem to be part of MonoBehavior, this is why I am extending it
	public GameObject[,] points;
	public GameObject[,] tiles;
	public bool[,] boolTiles, boolSuperPellets;
	public Graph currentGraph;
	public GameObject baseTile, basePoint;
	public Sprite spriteClear, spriteImpass;
	public string currentMap;
	public PriorityQueue queue;

	//Will instantiate all of the members
	public WorldCreator() {
		baseTile = GameObject.Find ("Tile");
		basePoint = GameObject.Find ("Point");
		spriteClear = Resources.Load <Sprite> ("Clear");
		spriteImpass = Resources.Load <Sprite> ("Impass");
	}
	
	//Will erase all of the waypoints in order to pepare for new ones
	public void cleanUpWaypoints() {
		if (points != null) {
			for (int i = 0; i < points.GetLength(0); i++) {
				for (int j = 0; j < points.GetLength(1); j++) {
					UnityEngine.Object.Destroy(points[i, j]);
				}
			}
		}
		points = null;
	}
	
	//Will erase old objects in order to prepare for new ones
	public void cleanUpGraph() {
		currentGraph = null;
		boolTiles = null;
		cleanUpWaypoints ();
		for (int i = 0; i < tiles.GetLength(0); i++) {
			for (int j = 0; j < tiles.GetLength(1); j++) {
				if (tiles[i, j] != null) {
					UnityEngine.Object.Destroy(tiles[i, j]);
				}
			}
		}
	}
	
	//extractNumer will collect the number characters from someLine and return them as an integer
	private int extractNumber(String someLine) {
		String onlyNumers = "";
		foreach (char c in someLine) {
			if (c >= '0' && c <= '9') {
				onlyNumers += c;
			}
		}
		return Int32.Parse (onlyNumers);
	}
	
	//Will reduce the size of bigMap by half in both x and y and store this as tile objects
	private void shrinkify(bool[,] bigMap) {
		int height = bigMap.GetLength (0);
		int width = bigMap.GetLength (1);
		
		int newHeight = height / 2;
		int newWidth = width / 2;
		
		bool[,] connections = new bool[newHeight, newWidth];
		boolSuperPellets = new bool[newHeight, newWidth];

		for (int i = 0; i < newHeight; i++) {
			for (int j = 0; j < newWidth; j++) {
				boolSuperPellets[i, j] = false;
			}
		}
		
		for (int i = 0; i < newHeight; i++) {
			for (int j = 0; j < newWidth; j++) {
				
				int count = 0;
				if (bigMap[i*2,j*2] == false) {
					count++;
				} if (bigMap[i*2,j*2 + 1] == false) {
					count++;
				} if (bigMap[i*2 + 1,j*2] == false) {
					count++;
				} if (bigMap[i*2 + 1,j*2 + 1] == false) {
					count++;
				}
				
				if (count < 2) {
					connections[i, j] = true;
				} else if (count < 3) {
					if ((bigMap[i*2 + 1,j*2] == false && bigMap[i*2 + 1, j*2 + 1] == false) ||
					    (bigMap[i*2 + 1, j*2] == false && bigMap[i*2, j*2] == false) ||
					    (bigMap[i*2, j*2 + 1] == false && bigMap[i*2 + 1, j*2 + 1] == false) ||
					    (bigMap[i*2, j*2] == false && bigMap[i*2, j*2 + 1] == false)) {
						
						connections[i, j] = true;
					} else {
						connections[i, j] = false;
					}
				} else { //there are more than 2 unwalkable squares, so make this square unwalkable
					connections[i, j] = false;
				}
			}
		}
		//Here we are creating all of the tiles that represent the world.
		tiles = new GameObject[newHeight, newWidth];
		for (int i = 0; i < newHeight; i++) {
			for (int j = 0; j < newWidth; j++) {
				tiles[i,j] = (GameObject) UnityEngine.Object.Instantiate(baseTile, new Vector3(j, i, 1), new Quaternion());
				if (connections[i,j] == false) {
					tiles[i,j].GetComponent<SpriteRenderer>().sprite = spriteImpass;
					tiles[i, j].AddComponent<BoxCollider2D>();
				} else {
					tiles[i,j].GetComponent<SpriteRenderer>().sprite = spriteClear;
				}
			}
		}
		boolTiles = connections;
		//here we are goint to create the box for the ghosts in each map
		if (currentMap == "hrt201n") {
			boolTiles[69, 96] = false;
			boolTiles[68, 96] = false;
			boolTiles[67, 96] = false;
			boolTiles[66, 96] = false;
			boolTiles[66, 97] = false;
			boolTiles[66, 98] = false;
			boolTiles[66, 99] = false;
			boolTiles[67, 99] = false;
			boolTiles[68, 99] = false;
			boolTiles[69, 99] = false;

			tiles[69, 96].GetComponent<SpriteRenderer>().sprite = spriteImpass;
			tiles[68, 96].GetComponent<SpriteRenderer>().sprite = spriteImpass;
			tiles[67, 96].GetComponent<SpriteRenderer>().sprite = spriteImpass;
			tiles[66, 96].GetComponent<SpriteRenderer>().sprite = spriteImpass;
			tiles[66, 97].GetComponent<SpriteRenderer>().sprite = spriteImpass;
			tiles[66, 98].GetComponent<SpriteRenderer>().sprite = spriteImpass;
			tiles[66, 99].GetComponent<SpriteRenderer>().sprite = spriteImpass;
			tiles[67, 99].GetComponent<SpriteRenderer>().sprite = spriteImpass;
			tiles[68, 99].GetComponent<SpriteRenderer>().sprite = spriteImpass;
			tiles[69, 99].GetComponent<SpriteRenderer>().sprite = spriteImpass;

		} else if (currentMap == "arena2") {
			boolTiles[53, 69] = false;
			boolTiles[52, 69] = false;
			boolTiles[51, 69] = false;
			boolTiles[50, 69] = false;
			boolTiles[50, 70] = false;
			boolTiles[50, 71] = false;
			boolTiles[50, 72] = false;
			boolTiles[51, 72] = false;
			boolTiles[52, 72] = false;
			boolTiles[53, 72] = false;
			
			tiles[53, 69].GetComponent<SpriteRenderer>().sprite = spriteImpass;
			tiles[52, 69].GetComponent<SpriteRenderer>().sprite = spriteImpass;
			tiles[51, 69].GetComponent<SpriteRenderer>().sprite = spriteImpass;
			tiles[50, 69].GetComponent<SpriteRenderer>().sprite = spriteImpass;
			tiles[50, 70].GetComponent<SpriteRenderer>().sprite = spriteImpass;
			tiles[50, 71].GetComponent<SpriteRenderer>().sprite = spriteImpass;
			tiles[50, 72].GetComponent<SpriteRenderer>().sprite = spriteImpass;
			tiles[51, 72].GetComponent<SpriteRenderer>().sprite = spriteImpass;
			tiles[52, 72].GetComponent<SpriteRenderer>().sprite = spriteImpass;
			tiles[53, 72].GetComponent<SpriteRenderer>().sprite = spriteImpass;
		}
	}
	
	//Will create all of the tiles and the representation of the word
	public void createWorld (string fileName) {
		currentMap = fileName;
		int bigHeight, bigWidth;
		bool[,] bigConnections = null;
		currentGraph = new Graph ();
		try {
			string line;
			TextAsset theTextFile = Resources.Load<TextAsset>(fileName);
			StringReader theReader = new StringReader(theTextFile.text);
			theReader.ReadLine();//This reads the graph type line (not needed)
			bigHeight = extractNumber(theReader.ReadLine());//This reads the height of the graph
			bigWidth = extractNumber (theReader.ReadLine());//This reads the width of the graph
			theReader.ReadLine();//This read the word map (not needed)
			bigConnections = new bool[bigHeight, bigWidth];
			int currentHeight = 0;
			int currentWidth = 0;
			
			List<string> lines = new List<string>();
			
			line = theReader.ReadLine();
			
			while (line != null) {
				lines.Add(line);
				line = theReader.ReadLine();
			}
			
			theReader.Close();
			
			for (int i = lines.Count - 1; i >=0; i--) {
				line = lines[i];
				if (line != null) {
					foreach (char c in line) {
						bigConnections[currentHeight, currentWidth] = (c == '.');//Set the value to 1 if the terrain is walkable and 0 otherwise
						currentWidth++;
					}
				}
				currentWidth = 0;
				currentHeight++;
			}
		}
		catch (Exception e)
		{
			Debug.Log("An error has occured while parsing the file:" + e.Message);
		}
		shrinkify(bigConnections);
		createPoints ();
		createGraph ();
		resetGraph ();
	}


	//Will create copies of the normal point and put them in the world
	private void createPoints() {
		points = new GameObject[tiles.GetLength (0), tiles.GetLength (1)];
		for (int i = 0; i < boolTiles.GetLength(0); i++) {
			for (int j = 0; j < boolTiles.GetLength(1); j++) {
				if (boolTiles[i,j] == true) {
					points[i,j] = (GameObject) UnityEngine.Object.Instantiate(basePoint, new Vector3(j, i, -1), new Quaternion());
				}
			}
		}

	}
	
	//Will create the graph treating all reachable areas as nodes
	private void createGraph() {
		currentGraph = new Graph();
		
		int height = boolTiles.GetLength (0);
		int width = boolTiles.GetLength (1);
		//Here is where we form our graph
		//First we add all of the nodes
		for (int i = 0; i < height; i++) {
			for (int j = 0; j < width; j++) {
				if (boolTiles[i, j] == true) {
					currentGraph.addNode(new Node(i, j));
				}
			}
		}
		//Now we add all of our connections
		foreach(Node node in currentGraph.nodes.Values) {
			int nodeHeight = node.heightPos;
			int nodeWidth = node.widthPos;
			
			bool isUp = nodeHeight > 0;
			bool isRight = nodeWidth < (width - 1);
			bool isDown = nodeHeight < (height - 1);
			bool isLeft = nodeWidth > 0;

			/*
			//We need to check upper left pos
			if (isUp && isLeft && boolTiles[nodeHeight - 1, nodeWidth - 1]) {
				currentGraph.addEdge(node, currentGraph.getNodeByLocation(nodeHeight - 1, nodeWidth - 1));
			}
			*/
			//We need to check upper pos
			if (isUp && boolTiles[nodeHeight - 1, nodeWidth]) {
				currentGraph.addEdge(node, currentGraph.getNodeByLocation(nodeHeight - 1, nodeWidth));
			}
			/*
			//We need to check upper right pos
			if (isUp && isRight && boolTiles[nodeHeight - 1, nodeWidth + 1]) {
				currentGraph.addEdge(node, currentGraph.getNodeByLocation(nodeHeight - 1, nodeWidth + 1));
			}
			*/
			//We need to check right pos
			if (isRight && boolTiles[nodeHeight, nodeWidth + 1]) {
				currentGraph.addEdge(node, currentGraph.getNodeByLocation(nodeHeight, nodeWidth + 1));
			}
			/*
			//We need to check lower right pos
			if (isDown && isRight && boolTiles[nodeHeight + 1, nodeWidth + 1]) {
				currentGraph.addEdge(node, currentGraph.getNodeByLocation(nodeHeight + 1, nodeWidth + 1));
			}
			*/
			//We need to check lower pos
			if (isDown && boolTiles[nodeHeight + 1, nodeWidth]) {
				currentGraph.addEdge(node, currentGraph.getNodeByLocation(nodeHeight + 1, nodeWidth));
			}
			/*
			//We need to check lower left pos
			if (isDown && isLeft && boolTiles[nodeHeight + 1, nodeWidth - 1]) {
				currentGraph.addEdge(node, currentGraph.getNodeByLocation(nodeHeight + 1, nodeWidth - 1));
			}
			*/
			//We need to check left pos
			if (isLeft && boolTiles[nodeHeight, nodeWidth - 1]) {
				currentGraph.addEdge(node, currentGraph.getNodeByLocation(nodeHeight, nodeWidth - 1));
			}
		}
	}

	//Will reset all of the costs and parents of the nodes in the queue
	public void resetGraph() {
		foreach (Node currentNode in currentGraph.nodes.Values) {
			currentNode.rawCost = float.MaxValue;
			currentNode.parent = null;
		}
	}

	//This is the method that will do A*. It returns a vector of locations to follow
	public LinkedList<Vector3> findPath(Vector3 start, Vector3 end) {
		LinkedList<Vector3> result = new LinkedList<Vector3> ();
		Node startNode = currentGraph.getNodeByLocation ((int)start.y, (int)start.x);
		startNode.rawCost = 0.0f;
		queue = new PriorityQueue (startNode);
		while (!queue.isEmpty()) {
			//The A* magic happens here
			Node minNode = queue.pop ();
			//if this is our ending node, stop pathfinding and form our full path on the graph
			if (minNode == currentGraph.getNodeByLocation ((int) end.y, (int) end.x)) {
				//Here we form the path depending
				Node currentNode = minNode;
				
				while (currentNode != null) {
					result.AddFirst(new Vector3(currentNode.widthPos, currentNode.heightPos));
					currentNode = currentNode.parent;
				}
				resetGraph();
				return result;
			}
			//else, we need to update our priority queue, etc.
			else {
				float currentRaw = minNode.rawCost;
				foreach (Node neighbor in minNode.edges.Values) {
					if (queue.isVisited(neighbor)) {
						float oldRaw = neighbor.rawCost;
						float newRaw = currentRaw + Vector2.Distance(new Vector2(minNode.widthPos, minNode.heightPos), new Vector2(neighbor.widthPos, neighbor.heightPos));
						if (newRaw < oldRaw) {
							neighbor.rawCost = newRaw;
							neighbor.parent = minNode;
						}
					} else {
						neighbor.rawCost = currentRaw + Vector2.Distance(new Vector2(minNode.widthPos, minNode.heightPos), new Vector2(neighbor.widthPos, neighbor.heightPos));
						neighbor.parent = minNode;
						queue.insert(neighbor);
					}
				}
			}
		}
		resetGraph ();
		return result;
	}
}
