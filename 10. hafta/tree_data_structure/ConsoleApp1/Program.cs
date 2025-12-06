using System;
using System.Collections.Generic;

class Node
{
    public int Data;
    public Node Left;
    public Node Right;

    public Node(int data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}

class BinaryTree
{
    public Node Root;

    // BST ekleme
    public void Insert(int data)
    {
        Root = InsertRecursive(Root, data);
    }

    private Node InsertRecursive(Node root, int data)
    {
        if (root == null)
            return new Node(data);

        if (data < root.Data)
            root.Left = InsertRecursive(root.Left, data);
        else
            root.Right = InsertRecursive(root.Right, data);

        return root;
    }

    // PREORDER
    public void Preorder(Node node)
    {
        if (node == null) return;

        Console.Write(node.Data + " ");
        Preorder(node.Left);
        Preorder(node.Right);
    }

    // INORDER
    public void Inorder(Node node)
    {
        if (node == null) return;

        Inorder(node.Left);
        Console.Write(node.Data + " ");
        Inorder(node.Right);
    }

    // POSTORDER
    public void Postorder(Node node)
    {
        if (node == null) return;

        Postorder(node.Left);
        Postorder(node.Right);
        Console.Write(node.Data + " ");
    }

    // LEVEL ORDER
    public void LevelOrder()
    {
        if (Root == null) return;

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(Root);

        while (queue.Count > 0)
        {
            Node temp = queue.Dequeue();
            Console.Write(temp.Data + " ");

            if (temp.Left != null)
                queue.Enqueue(temp.Left);

            if (temp.Right != null)
                queue.Enqueue(temp.Right);
        }
    }
}

class Program
{
    static void Main()
    {
        BinaryTree tree = new BinaryTree();

        Console.WriteLine("Agaca eklenecek sayilari girin (bitirmek icin 0):");

        while (true)
        {
            int value = Convert.ToInt32(Console.ReadLine());
            if (value == 0)
                break;

            tree.Insert(value);
        }

        Console.Write("\nPreorder: ");
        tree.Preorder(tree.Root);

        Console.Write("\nInorder: ");
        tree.Inorder(tree.Root);

        Console.Write("\nPostorder: ");
        tree.Postorder(tree.Root);

        Console.Write("\nLevel-order: ");
        tree.LevelOrder();

        Console.ReadLine();
    }
}
