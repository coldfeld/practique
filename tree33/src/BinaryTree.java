public class BinaryTree {
    private Node root;

    public Node getRoot() { return root; }

    public int getHeight(Node root) {
        if (root == null)
            return 0;
        return Math.max(getHeight(root.left), getHeight(root.right)) + 1;
    }


    public void createBalanced(int num){
        //this.root = new Node(0);
        root = create(this.root, num, 0);
    }

    private Node create(Node current, int value, int level) {
        int next = level;
        if (value !=0) current = new Node(next);
        next++;
        if(value > 1){
            current.left = create(current.left, value/2, next);
            current.right = create(current.right, (value -1)/2, next);
        }
        return current;
    }

    class Node {
        private int value;
        private Node left, right;

        public int getValue() { return value; }

        public Node getLeft() { return left; }

        public Node getRight() { return right; }

        public Node(int value) {
            this.value = value;
            right = null;
            left = null;
        }
    }
}
