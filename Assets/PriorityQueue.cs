using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This is a priority queue for Nodes
public class PriorityQueue {
	private List<Node> openList;
	private Dictionary<string, Node> AddedList;

	public PriorityQueue(Node startingNode) {
		openList = new List<Node>();
		AddedList = new Dictionary<string, Node> ();

		startingNode.rawCost = 0.0f;
		openList.Add (startingNode);
		AddedList.Add(startingNode.name, startingNode);
	}

	//This will move the newly added node up the tree until it is sitting at the right place
	private void moveUp() {
		int index = openList.Count - 1;
		
		//This pushes the new value up the "tree" until it is in its rightful spot
		while (index != 0 && openList[index].totalCost() < openList[(index - 1)/2].totalCost()) {
			int newIndex = (index - 1)/2;
			Node temp = openList[newIndex];
			
			openList[newIndex] = openList[index];
			openList[index] = temp;
			
			index = newIndex;
		}
	}

	//This will move the small node at the root down to where it belongs	
	private void moveDown() {
		bool isCorrected = false;
		int index = 0;
		do {
			Node leftChild, rightChild;
			//if the current index node is missing children
			if (index*2 + 1 >= openList.Count || index*2 + 2 >= openList.Count) {
				//case where they are missing both children
				if (index*2 + 1 >= openList.Count && index*2 + 2 >= openList.Count) {
					isCorrected = true;
				} 
				//case where they are missing only right child (Not possible to only be missing right child
				else {
					leftChild = openList[index*2 + 1];
					if (leftChild.totalCost() < openList[index].totalCost()) {
						openList[index*2 + 1] = openList[index];
						openList[index] = leftChild;
					}
					isCorrected = true;//Either way we are done here
				}
			}
			//this is when there are both children still
			else {
				leftChild = openList[index*2 + 1];
				rightChild = openList[index*2 + 2];
				
				Node smallestChild;
				int smallestChildIndex;
				
				if (leftChild.totalCost() < rightChild.totalCost()) {
					smallestChild = leftChild;
					smallestChildIndex = index*2 + 1;
				} else {
					smallestChild = rightChild;
					smallestChildIndex = index*2 + 2;
				}
				
				if (openList[index].totalCost() <= smallestChild.totalCost()) {
					isCorrected = true;
				} else {
					openList[smallestChildIndex] = openList[index];
					openList[index] = smallestChild;
					index = smallestChildIndex;
				}
			}
			
		} while (!isCorrected);
	}

	//Insert will add the new Node. This assumes that newnode is not already withing the queue
	public void insert(Node newNode) {
		openList.Add (newNode);
		AddedList.Add (newNode.name, newNode);
		moveUp ();
	}

	//Pop will return the smallest node (by f value) and will fix the tree
	public Node pop () {
		if (openList.Count == 0) {
			return null;
		}

		Node result = openList [0];

		openList[0] = openList [openList.Count - 1];
		openList.RemoveAt(openList.Count - 1);

		return result;
	}

	public bool isVisited(Node node) {
		return AddedList.ContainsKey (node.name);
	}
}
