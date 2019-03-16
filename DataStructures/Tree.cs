using System;

namespace DataStructures
{
    public class BinaryTree
    {
        public int Key { get; set; }
        public BinaryTree Parent { get; set; }
        public BinaryTree Left { get; set; }
        public BinaryTree Right { get; set; }
        public bool Visited { get; set; }

        public BinaryTree()
        {
            Visited = false;
        }


        public static void VisitRecursive(BinaryTree tree)
        {
            if (tree == null) return;

            tree.Visited = true;
            VisitRecursive(tree.Left);
            VisitRecursive(tree.Right);
        }

        public static void VisitNonRecursive(BinaryTree tree)
        {

            var node = tree;
            while (true)
            {
                node.Visited = true;
                if (node.Left != null)
                {
                    node = node.Left;
                }
                else
                {
                    while (node.Parent.Right == node)
                    {

                        node = node.Parent;
                        
                        /* if node == tree, there is no parent for tree node
                         * so algorithm successfully visited all nodes
                         * */
                        if (node == tree)
                        {
                            return;
                        }
                    }

                    node = node.Parent.Right;
                }
            }
        }

        public static BinaryTree InitializeSimpleTree(int depth, ref int initValue)
        {

            if (depth < 1) return null;
            var t1 = new BinaryTree();
            t1.Key = ++initValue;
            t1.Left = InitializeSimpleTree(depth - 1, ref initValue);
            t1.Right = InitializeSimpleTree(depth - 1, ref initValue);

            if (t1.Left != null)
                t1.Left.Parent = t1;
            if (t1.Right != null)
                t1.Right.Parent = t1;

            return t1;
        }
    }
}