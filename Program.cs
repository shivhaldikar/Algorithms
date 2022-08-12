// See https://aka.ms/new-console-template for more information

// Number of Ways to Climb stairs
//Console.WriteLine(Algo.Problem.NumberOfWaysToClimb(4,new int[3]{1,3,5}));
//Console.WriteLine(Algo.Problem.NumberOfWaysToClimbRecursive(4,new int[3]{1,3,5}));

// Sort Problem
// Console.WriteLine(string.Join(",", Algo.Problem.Sort(1,8,new int[7]{3,1,2,6,4,8,7})));
// Console.WriteLine(string.Join(",", Algo.Problem.BubleSort(new int[7]{3,1,2,6,4,8,7})));

// Console.WriteLine(string.Join(",", Algo.Problem3.FindNumbersThatAddup_Sub(new int[]{3,1,2,6,4,8,7}, 15)));
// (bool _found, string _pairs) = Algo.Problem3.FindNumbersThatAddup_Add(new int[]{3,1,2,6,4,8,5,4,3,78,4,12,14,15,16,17,11,23,22,1,2,5,7,6,9,10,15,21}, 25);
// Console.WriteLine($"{_found} / {_pairs}");
(bool found, string pairs) = Algo.Problem3.FindNumbersThatAddup_SingleIteration(new int[]{3,1,2,6,4,8,5,4,3,78,4,12,14,15,16,17,11,23,22,1,2,5,7,6,9,10,15,21}, 25);
Console.WriteLine($"{found} / {pairs}");

// int[] products = Algo.Problem4.FindProduct(new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9});
// Console.WriteLine($"[{string.Join(" ,",products)}]");
// products = Algo.Problem4.FindProduct_Divison(new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9});
// Console.WriteLine($"[{string.Join(" ,",products)}]");
// BenchmarkDotNet.Running.BenchmarkRunner.Run<Algo.Problem4>();


// Algo.Node node = new Algo.Node("root",
//     new Algo.Node("left",
//         new Algo.Node("left.left"),
//         new Algo.Node("left.right")
//     ), new Algo.Node("right")
// );
// string data = Algo.Problem5.Serialize(node);
// Console.WriteLine(data);
// Console.WriteLine(Algo.Problem5.SerializeJson(node));
// Algo.Node _node = Algo.Problem5.Deserialize(data);
// _node.Left.Left.Value = "Changed";
// Console.WriteLine(Algo.Problem5.SerializeJson(_node));
// BenchmarkDotNet.Running.BenchmarkRunner.Run<Algo.Problem5>();

Console.ReadLine();
