import java.util.Random;

public class BinaryTree {

    private Node root;

    public Node getRoot() { return root; }

    public int getHeight(Node root) {
        if (root == null)
            return 0;
        return Math.max(getHeight(root.left), getHeight(root.right)) + 1;
    }

    public void скeateBalanced(int num){
        root = create(this.root, num);
    }


    public BinaryTree invertCopy(BinaryTree origTree){
        BinaryTree copyTree = new BinaryTree();
        copyTree.root = recursiveInvertCopy(origTree.root, origTree.root.value);
        return  copyTree;
    }

    private Node recursiveInvertCopy(Node current, int neighborVal){
        Node copy = new Node(neighborVal);
        if ((current.left != null) && (current.right != null)) {
            copy.left = recursiveInvertCopy(current.left, current.right.value);
            copy.right = recursiveInvertCopy(current.right, current.left.value);
        }
        if ((current.left == null) && (current.right != null)){
            copy.left = recursiveInvertCopy(current.right, current.right.value);
        }
        if ((current.left != null) && (current.right == null)){
            copy.right = recursiveInvertCopy(current.left, current.left.value);
        }
        return copy;
    }

    private Node create(Node current, int value) {
        Random random = new Random();
        int n = random.nextInt(30);
        if (value !=0) current = new Node(n);
        if(value > 1){
            current.left = create(current.left, value/2);
            current.right = create(current.right, (value -1)/2);
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