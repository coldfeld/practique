import java.util.Random;
import java.util.Scanner;

public class tree33 {
    public static void main(String[] args) {
        BinaryTree parityTree = new BinaryTree();
        System.out.print("Количество вершин: N = ");
        Scanner scanner =  new Scanner(System.in);
        int N = scanner.nextInt();
        parityTree.createBalanced(N);

        new BinaryTreeGUI(parityTree);
    }
}
