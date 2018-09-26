using System;
using System.ComponentModel;


namespace BSTtree
{




    class Program
    {


        static void Main(string[] args)
        {

            Console.WriteLine("Please write integers between 0 to 100 separated by a space (no duplicates please): \n");
            string[] userInput = Console.ReadLine().Split(' '); //sep by space delimiter
            int[] x = new int[userInput.Length];
            BSTtree<int> newTree = new BSTtree<int>();
           
            for (var i = 0; i < userInput.Length; i++)
            {
                x[i] = int.Parse(userInput[i]);


                newTree.Insert(x[i]);
                // Console.WriteLine("In order traversal: \n");
                //Console.WriteLine();
                //newTree.PreOrder();
                //Console.WriteLine("Pre order traversal: \n");
                // Console.WriteLine();
                //newTree.PostOrder();
                // Console.WriteLine("Post order traversal: \n");
                //Console.WriteLine();

                //test to print out each, split worked
            }

            Console.WriteLine("\nInOrder: \n");
            newTree.InOrder();
            Console.WriteLine("\nPostOrder: \n");
            newTree.PostOrder();
            Console.WriteLine("\nPreOrder: \n");
            newTree.PreOrder();

            Console.WriteLine("\nPlease enter a value to search for: \n");
            string myString = Console.ReadLine();
            int numVal = Int32.Parse(myString);
            Console.WriteLine(newTree.Contains(numVal));







            Console.WriteLine("\nThe number of items in the tree is: \n");
            Console.WriteLine(newTree.Count());
            Console.WriteLine("\nThe tree's depth is: {0} and the level is: {1} \n", (newTree.Depth() - 1),
                newTree.Depth()); //private method called by the public method && depth is number of edges away from root so subtract 1

            /*For the minimum level, I assume the root and each node having 2 children, therefore
             my test case was {1 5 9 7 3 6 3 3 2} which means 7 nodes given no duplicates, therefore i expect level 3                                   
            */

            Console.WriteLine("\nThe minimum number of levels is: {0} \n",
                Math.Round((Math.Log(newTree.Count(), 2)))); //this will give me a value of 2.8 cast to int for 3
            //math.round will round to the nearest int
            Console.Read();
        }


    }
    
}


