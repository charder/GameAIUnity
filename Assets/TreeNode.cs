public enum TreeNodes {
	Condition,
	Behavior
};

//TreeNode will be extended by ConditionNode and BehaviorNode (the kinds of TreeNodes)
public interface TreeNode {
	//Will tell you what kind of node this treenode is
	TreeNodes type();
}
