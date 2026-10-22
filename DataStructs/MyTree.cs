using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeStudy.DataStructs
{


    //定义树节点
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val)
        {
            this.val = val;
        }
    }
    public class MyTree
    {

        public void TreeConstructor()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);

            // --- 开始遍历 ---
            Console.Write("前序遍历 (根-左-右): ");
            Console.WriteLine();
            PreOrder(root);
            Console.WriteLine();
            Console.Write("中序遍历 (左-根-右): ");
            Console.WriteLine();
            InOrder(root);
            Console.WriteLine();
            Console.Write("后序遍历 (左-右-根): ");
            Console.WriteLine();
            PostOrder(root);
            Console.WriteLine();
            Console.Write("层序遍历 (从上往下): ");
            Console.WriteLine();
            LevelOrder(root);

        }

     

        private void PreOrder(TreeNode root)
        {
            if (root == null) return;
            Console.Write(root.val);
            PreOrder(root.left);
            PreOrder(root.right);
        }
        private void InOrder(TreeNode root)
        {
            if (root == null) return;
            InOrder(root.left);
            Console.Write(root.val);
            InOrder(root.right);
        }
        private void PostOrder(TreeNode root)
        {
            if (root == null) return;
            PostOrder(root.left);
            PostOrder(root.right);
            Console.Write(root.val);
        }
        private void LevelOrder(TreeNode root)
        {
            if (root == null) return;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                Console.Write(node.val);

                // 有左孩子就入队，有右孩子就入队
                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
        }
    }
}
