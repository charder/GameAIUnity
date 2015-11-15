//BehaviorNode represents a node in a behavior tree that will perform actions in the world
public class BehaviorNode : TreeNode {
	private Behavior nodeBehavior;

	public BehaviorNode(Behavior behav) {
		nodeBehavior = behav;
	}

	//Will tell you that the node is a behavior node
	public TreeNodes type() {
		return TreeNodes.Behavior;
	}

	public void performBehavior() {
		nodeBehavior.performBehavior ();
	}
	
}
