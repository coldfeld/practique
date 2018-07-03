public class BinaryTree {
    private Node root;

    public Node getRoot() { return root; }

    public int getHeight(Node root) {
        if (root == null)
            return 0;
        return Math.max(getHeight(root.left), getHeight(root.right)) + 1;
    }

    public void add(int value) {
        root = addRecursive (root, value);
    }

    private Node addRecursive (Node current, int value) {
        if (current == null) {
            return new Node(value);
        } else if (current.left == null) {
            current.left = new Node(value);
        } else {
            current.right = addRecursive (current.right, value);
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
