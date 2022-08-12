/*
 * Given the root to a binary tree, implement serialize(root), which serializes the tree into a string, and deserialize(s), 
 * which deserializes the string back into the tree.
 * For example, given the following Node class
 * class Node:
 *   def __init__(self, val, left=None, right=None):
 *        self.val = val
 *       self.left = left
 *        self.right = right
 * The following test should pass:
 * node = Node('root', Node('left', Node('left.left')), Node('right'))
 * assert deserialize(serialize(node)).left.left.val == 'left.left'
 */
using System.Text;
using BenchmarkDotNet.Attributes;
namespace Algo
{
    [MemoryDiagnoser]
    public partial class Problem5
    {
        public static string SerializeJson(Node node)
        {
            return "{\"node\": {" + Traverse(node) + "}}";
        }

        public static string Traverse(Node _node)
        {
            string test = string.Empty;
            if (_node != null)
            {
                test = "\"value\": \"" + _node.Value + "\"";
                if (_node.Left != null)
                {
                    test += ",\"left\": {";
                    test += Traverse(_node.Left);
                    test += "}";
                }
                if (_node.Right != null)
                {
                    test += ",\"right\": {";
                    test += Traverse(_node.Right);
                    test += "}";
                }
            }
            return test;
        }

        public static string Serialize(Node _node)
        {
            StringBuilder _serializedString = new StringBuilder();
            if (_node != null)
            {
                _serializedString
                .AppendFormat("{0},", _node.Value)
                .Append(Serialize(_node.Left))
                .Append(Serialize(_node.Right));
            }
            else
            {
                _serializedString.Append(",");
            }

            return _serializedString.ToString();
        }

        static int t;
        public static Node Deserialize(string data)
        {
            if (data == null)
                return null;
            t = 0;
            string[] arr = data.Split(",");
            return Helper(arr);
        }

        public static Node Helper(string[] arr)
        {
            if (string.IsNullOrEmpty(arr[t]))
                return null;
            // create node with this item and recur for children
            Node root
                = new Node(arr[t]);
            t++;
            root.AddLeft(Helper(arr));
            t++;
            root.AddRight(Helper(arr));
            return root;
        }

        static Algo.Node node = new Algo.Node
            (
                "root",
                new Algo.Node
                (
                    "left",
                    new Algo.Node("left.left"),
                    new Algo.Node("left.right")
                ), 
                new Algo.Node("right")
            );

            
        [Benchmark]
        public void _Serialize()
        {
           Serialize(node);
        }

        [Benchmark]
        public void _SerializeJson()
        {
            SerializeJson(node);
        }

        [Benchmark]
        public void _Deserialize()
        {
            Deserialize("root,left,left.left,,,left.right,,,right,,,");
        }
    }


    public class Node
    {
        public Node(string value, Node left = null, Node right = null)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }

        public void AddLeft(Node node)
        {
            this.Left = node;
        }

        public void AddRight(Node node)
        {
            this.Right = node;
        }
        public Node Left { get; private set; }

        public Node Right { get; private set; }

        public string Value { get; set; }
    }
}