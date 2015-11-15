//BehaviorTree represents well.... A behavior tree
public class BehaviorTree {
	TreeNode startNode;

	//Will set the start node in the tree
	public BehaviorTree(TreeNode start) {
		startNode = start;
	}

	public TreeNode getStartNode() {
		return startNode;
	}

	//Will recurse through the tree until a behavior node is found and call the behavior
	public void doBehavior() {
		TreeNode currentNode = startNode;

		while (currentNode.type() == TreeNodes.Condition) {
			ConditionNode currentCondition = (ConditionNode) currentNode;
			currentNode = currentCondition.evaluateCondition();
		}

		BehaviorNode currentBehavior = (BehaviorNode)currentNode;
		currentBehavior.performBehavior ();
	}
}
