using LeetCodeStudy.DataStructs;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetCodeStudy.Timus.AdventureMode
{
    public class DataStruct
    {
        #region 数组
        //探险模式--数组I
        public int[] GetConcatenation(int[] nums)
        {
            int len1 = nums.Length;
            int len2 = len1 * 2;
            int[] res = new int[len2];
            for (int i = 0; i < len2; i++)
            {
                if (i < len1)
                    res[i] = nums[i];
                if (i >= len1)
                    res[i] = nums[i - len1];
            }
            return res;
        }
        public int[] Shuffle(int[] nums, int n)
        {
            int len = nums.Length;
            int[] res = new int[len];
            int i = 0;
            int j = n;
            while (i < len / 2)
            {
                res[2 * i] = nums[i];
                res[2 * i + 1] = nums[j];
                i++;
                j++;
            }
            return res;
        }
        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int len = nums.Length;
            int count = 0;
            int res = 0;
            for (int i = 0; i < len; i++)
            {
                if (nums[i] == 1)
                    count++;
                if (nums[i] == 0 || i == len - 1)
                {
                    if (res < count)
                        res = count;
                    count = 0;
                }
            }
            return res;
        }

        //探险模式--数组II
        public int[] FindErrorNums(int[] nums)
        {
            int len = nums.Length;
            int[] count = new int[len + 1];
            int error = 0;
            int miss = 0;
            foreach (int x in nums)
                count[x]++;
            for (int i = 1; i <= len; i++)
            {
                if (count[i] == 2)
                    error = i;
                if (count[i] == 0)
                    miss = i;
            }
            return [error, miss];
        }
        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            int len = nums.Length;
            int[] count = new int[len];
            for (int i = 0; i < len; i++)
            {
                int cur = nums[i];
                for (int j = 0; j < len; j++)
                {
                    if (cur > nums[j])
                        count[i]++;
                }
            }
            return count;
        }
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            int len = nums.Length;
            int[] count = new int[len + 1];
            List<int> dis = new List<int>();
            foreach (int x in nums)
                count[x] = x;
            for (int i = 1; i < len + 1; i++)
                if (count[i] == 0)
                    dis.Add(i);
            return dis;
        }
        #endregion

        #region 栈
        public IList<string> BuildArray(int[] target, int n)
        {
            List<string> op = new List<string>();
            int j = 0;
            int len = target.Length;
            for (int i = 1; i <= n && j < len; i++)
            {
                if (target[j] == i)
                {
                    op.Add("Push");
                    j++;
                }
                else
                {
                    op.Add("Push");
                    op.Add("Pop");
                }

            }
            return op;
        }
        public int EvalRPN(string[] tokens)
        {
            var Stack = new Stack<int>();
            foreach (var s in tokens)
            {
                if (s == "+" || s == "-" || s == "*" || s == "/")
                {
                    var a = Stack.Pop();
                    var b = Stack.Pop();
                    var res = s switch
                    {
                        "+" => b + a,
                        "-" => b - a,
                        "*" => b * a,
                        "/" => b / a,
                    };
                    Stack.Push(res);
                }
                else
                {
                    Stack.Push(int.Parse(s));
                }
            }
            return Stack.Pop();
        }
        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            var Stack = new Stack<int>();
            int preTime = 0;
            int[] res = new int[n];
            foreach (var l in logs)
            {
                string[] s = l.Split(":");
                int id = int.Parse(s[0]);
                string status = s[1];
                int time = int.Parse(s[2]);
                if (status == "start")
                {
                    if (Stack.Count > 0)
                        res[Stack.Peek()] += time - preTime;
                    Stack.Push(id);
                    preTime = time;
                }
                else
                {
                    res[Stack.Peek()] += time - preTime + 1;
                    Stack.Pop();
                    preTime = time + 1;
                }
            }
            return res;
        }

        public int[] FinalPrices(int[] prices)
        {
            int len = prices.Length;
            var stack = new Stack<int>();
            for (int i = 0; i < len; i++)
            {
                while (stack.Count > 0 && prices[stack.Peek()] >= prices[i])
                {
                    int idx = stack.Pop();
                    prices[idx] = prices[idx] - prices[i];
                }
                stack.Push(i);
            }
            return prices;
        }
        public int[] DailyTemperatures(int[] temperatures)
        {
            int len = temperatures.Length;
            int[] res = new int[len];
            var stack = new Stack<int>();
            for (int i = 0; i < len; i++)
            {
                while (stack.Count > 0 && temperatures[stack.Peek()] < temperatures[i])
                {
                    int idx = stack.Pop();
                    res[idx] = i - idx;
                }
                stack.Push(i);
            }
            return res;
        }
        public int LargestRectangleArea(int[] heights)
        {
            int area = 0;
            int len = heights.Length;
            int[] h = new int[len + 2];
            Array.Copy(heights, 0, h, 1, len);
            //单调栈
            var stack = new Stack<int>();
            for (int i = 0; i < len + 2; i++)
            {
                while (stack.Count > 0 && h[stack.Peek()] > h[i])
                {
                    int height = h[stack.Pop()];
                    int width = i - stack.Peek() - 1;
                    area = Math.Max(area, height * width);

                }
                stack.Push(i);
            }


            //暴力破解
            //for (int i = 0; i < len; i++)
            //{
            //    int h = heights[i];
            //    int left = i;
            //    int right = i;
            //    while (left > 0 && heights[left - 1] >= h)
            //        left--;
            //    while (right < len - 1 && heights[right + 1] >= h)
            //        right++;
            //    int w = right - left + 1;
            //    area = Math.Max(area, w * h);
            //}
            return area;
        }
        #endregion
        #region 测验一
        public int[] PlusOne(int[] digits)
        {
            int len = digits.Length;
            int[] res = new int[len + 1];
            for (int i = len - 1; i >= 0; i--)
            {
                if (digits[i] < 9)
                {
                    digits[i]++;
                    return digits;
                }
                digits[i] = 0;
            }
            res[0] = 1;
            return res;
        }
        public bool ValidMountainArray(int[] arr)
        {
            int len = arr.Length;
            int i = 0;
            while (i < len - 1 && arr[i] < arr[i + 1])
                i++;
            while (i < len - 1 && arr[i] > arr[i + 1])
                i++;
            if (i == len - 1 || i == 0)
                return false;
            return i == len - 1;
        }
        #endregion
        #region 测验二
        public string RemoveDuplicateLetters(string s)
        {
            var list = new List<char>();
            foreach (var c in s)
            {
                if (list.Contains(c)) { }
                else
                {
                    list.Add(c);
                }
            }
            return string.Join("", list);
        }
        #endregion

        #region 队列
        public int CountStudents(int[] students, int[] sandwiches)
        {
            int[] count = new int[2];
            foreach (int s in students)
                count[s]++;
            foreach (int sand in sandwiches)
            {
                if (count[sand] == 0)
                    return count[0] + count[1];
                count[sand]--;
            }
            return count[0] + count[1];
        }
        public int TimeRequiredToBuy(int[] tickets, int k)
        {
            var queue = new Queue<int>();
            int res = 0;
            for (int i = 0; i < tickets.Length; i++)
                queue.Enqueue(i);
            while (true)
            {
                int person = queue.Dequeue();
                tickets[person]--;
                res++;
                if (person == k && tickets[person] == 0)
                    return res;
                if (tickets[person] > 0)
                    queue.Enqueue(person);
            }
        }

        #endregion
        #region 堆
        public int LastStoneWeight(int[] stones)
        {
            int len = stones.Length;
            int res = 0;
            for (int i = 0; i < len; i++)
            {
                var a = stones[i];


            }
            return 1;
        }

        #endregion
        #region 树
        public IList<IList<int>> Le2velOrder(TreeNode root)
        {
            var res = new List<IList<int>>();
            if (root == null) return res;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var size = queue.Count;
                var levelList = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    TreeNode node = queue.Dequeue();
                    levelList.Add(node.val);
                    if (node.left != null) queue.Enqueue(node.left);
                    if (node.right != null) queue.Enqueue(node.right);
                }
                res.Add(levelList);
            }
            return res;
        }
        public IList<int> RightSideView(TreeNode root)
        {
            var res = new List<int>();
            if (root == null) return res;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    if (i == size - 1)
                        res.Add(node.val);
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
            }
            return res;
        }
        public IList<double> AverageOfLevels(TreeNode root)
        {
            var res = new List<double>();
            if (root == null) return res;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var size = queue.Count;
                double sum = 0;
                for (int i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    sum += node.val;
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                res.Add(sum / size);
            }
            return res;
        }

        public IList<int> LargestValues(TreeNode root)
        {
            var res = new List<int>();
            if (root == null) return res;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var size = queue.Count;
                int max = queue.Peek().val;
                for (int i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    if (max < node.val)
                        max = node.val;
                    if (node.left != null)
                        queue.Enqueue(node.left);
                    if (node.right != null)
                        queue.Enqueue(node.right);
                }
                res.Add(max);
            }
            return res;
        }
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null || root.val == val) return root;
            if (val < root.val)
                return SearchBST(root.left, val);
            else
                return SearchBST(root.right, val);

        }
        long prev = long.MinValue;
        public bool IsValidBST(TreeNode root)
        {

            if (root == null) return true;
            if (!IsValidBST(root.left))
                return false;
            if (root.val <= prev)
                return false;
            prev = root.val;
            return IsValidBST(root.right);
        }
        public TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null) return new TreeNode(val);
            if (root.val < val)
                root.right = InsertIntoBST(root.right, val);
            else if (root.val > val)
                root.left = InsertIntoBST(root.left, val);
            return root;
        }
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null) return null;
            if (root.val < key)
                DeleteNode(root.right, key);
            else if (root.val > key)
                DeleteNode(root.left, key);
            else
            {
                if (root.left == null) return root.right;
                if (root.right == null) return root.left;
                var minNode = root.right;
                while (minNode.left != null)
                    minNode = minNode.left;
                root.val = minNode.val;
                root.right = DeleteNode(root.right, minNode.val);
            }
            return root;
        }
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return root;
            if (p.val > root.val && q.val > root.val)
                return LowestCommonAncestor(root.right, p, q);
            if (p.val < root.val && q.val < root.val)
                return LowestCommonAncestor(root.left, p, q);
            return root;
        }
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return Build1(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1);
        }
        private TreeNode Build1(int[] pre, int preHead, int preEnd, int[] inArr, int inHead, int inEnd)
        {
            if (preHead > preEnd) return null;
            var root = new TreeNode(pre[preHead]);
            int index = inHead;
            while (root.val != inArr[index])
                index++;
            int leftSize = index - preHead;
            root.left = Build1(pre, preHead + 1, leftSize + preHead, inArr, inHead, index - 1);
            //根左右，左子树=根节点后一个（+1） -> 根节点+左子树长度
            //左根右，左子树=第0个 -> 根节点前一个（-1）
            root.right = Build1(pre, preHead + leftSize + 1, preEnd, inArr, index + 1, inEnd);
            //根左右，右子树=根节点后两个（左子树长度+1） -> 末尾都是右子树
            //左根右，右子树=根节点后一个 -> 末尾都是右子树）
            return root;
        }
        public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
        {
            return Build2(preorder, 0, preorder.Length - 1, postorder, 0, postorder.Length - 1);
        }
        private TreeNode Build2(int[] pre, int preHead, int preEnd, int[] post, int postHead, int postEnd)
        {
            if (preHead > preEnd) return null;
            var root = new TreeNode(pre[preHead]);
            int index = postHead;
            int leftVal = pre[preHead + 1];
            while (leftVal != post[index])
                index++;
            int leftSize = index - postHead+1;
            root.left = Build2(pre, preHead + 1, index - 1, post, post, postEnd);
            return root;
        }
        #endregion
    }

    public class StackForQueue
    {
        private Stack<int> InStack;
        private Stack<int> OutStack;
        public StackForQueue()
        {
            InStack = new Stack<int>();
            OutStack = new Stack<int>();
        }

        public void Push(int x)
        {
            InStack.Push(x);
        }

        public int Pop()
        {
            if (OutStack.Count == 0)
            {
                while (InStack.Count > 0)
                {
                    var a = InStack.Pop();
                    OutStack.Push(a);
                }
            }
            return OutStack.Pop();
        }

        public int Peek()
        {
            if (OutStack.Count == 0)
            {
                while (InStack.Count > 0)
                {
                    var a = InStack.Pop();
                    OutStack.Push(a);
                }
            }
            return OutStack.Peek();
        }

        public bool Empty()
        {
            return InStack.Count == 0 && OutStack.Count == 0;
        }
    }
}
