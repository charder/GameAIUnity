//ConditionNode represents a Node in a Behvior Tree that will point to another node based on the state of the world
public class ConditionNode : TreeNode {
	private Condition nodeCondition;
	private TreeNode leftNode;
	private TreeNode rightNode;

	//constructor can also take left and right TreeNodes
	public ConditionNode(Condition cond, TreeNode left, TreeNode right) {
		nodeCondition = cond;
		leftNode = left;
		rightNode = right;
	}

	//Will set the left TreeNode
	public void setLeftNode(TreeNode left) {
		leftNode = left;
	}

	//Will set the right TreeNode
	public void setRightNode(TreeNode right) {
		rightNode = right;
	}

	//Will return the type of content
	public TreeNodes type() {
		return TreeNodes.Condition;
	}

	//Will evaluate the condition and 
	public TreeNode evaluateCondition() {
		bool result = nodeCondition.evaluateCondition ();
		if (result) {
			return leftNode;
		} else {
			return rightNode;
		}
	}
}
