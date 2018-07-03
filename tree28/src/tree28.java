import java.util.Random;
import java.util.Scanner;

public class tree28 {
    public static void main(String[] args) {
        BinaryTree parityTree = new BinaryTree();
        System.out.print("Количество вершин: N = ");
        Scanner scanner =  new Scanner(System.in);
        int N = scanner.nextInt();
        Random random = new Random();
        for (int i = 1; i <= N; i++) {
            parityTree.add(random.nextInt(10));
        }
        new BinaryTreeGUI(parityTree);
    }
}
