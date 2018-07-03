import java.awt.*;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;

public class BinaryTreeGUI extends JFrame {
    public BinaryTreeGUI(BinaryTree parityTree) {
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setBounds(100, 100, 500, 500);
        JPanel contentPane = new JPanel();
        contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
        contentPane.setLayout(new BorderLayout(0, 0));
        DrawBinaryTree drawer = new DrawBinaryTree(parityTree);
        contentPane.add(drawer);
        setContentPane(contentPane);
        setVisible(true);
    }
}

class DrawBinaryTree extends JPanel{
    private BinaryTree parityTree;
    public DrawBinaryTree(BinaryTree parityTree){ this.parityTree = parityTree; }

    @Override
    protected void paintComponent(Graphics g) {
        DrawBinaryTree(g, 0, getWidth(), 0, getHeight() / parityTree.getHeight(parityTree.getRoot()), parityTree.getRoot());
    }

    private void DrawBinaryTree(Graphics g, int startWidth, int endWidth, int startHeight, int level, BinaryTree.Node node) {
        String value = String.valueOf(node.getValue());
        g.setFont(new Font("Times New Roman", Font.BOLD, 18));
        FontMetrics fontMetrics = g.getFontMetrics();
        int currentX = (startWidth + endWidth - fontMetrics.stringWidth(value)) / 2, currentY = startHeight + level / 2;
        g.setColor(Color.BLACK);
        g.drawString(value, currentX, currentY);
        g.setColor(Color.lightGray);
        g.drawLine(currentX, currentY, currentX, currentY);
        if (node.getLeft() != null) {
            DrawBinaryTree(g, startWidth, (startWidth + endWidth) / 2, startHeight + level, level, node.getLeft());
            g.drawLine(currentX, currentY, (3 * startWidth + endWidth - 2 * fontMetrics.stringWidth(String.valueOf(node.getLeft().getValue()))) / 4, startHeight + 3 * level / 2);
        }
        if (node.getRight() != null) {
            DrawBinaryTree(g, (startWidth + endWidth) / 2, endWidth, startHeight + level, level, node.getRight());
            g.drawLine(currentX, currentY, (startWidth + 3 * endWidth - 2 * fontMetrics.stringWidth(String.valueOf(node.getRight().getValue()))) / 4, startHeight + 3 * level / 2);
        }
    }
}
