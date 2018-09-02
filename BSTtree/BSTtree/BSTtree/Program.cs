using System;


namespace BSTtree
{

    class BSTnode
    {
        public int data;
        public BSTnode left;
        public BSTnode right;
        public void display()
        {
            Console.Write(data);
        }
    }


    class BSTtree
    {
        int inserts = 0;
        int duplicates = 0;
        public BSTnode pRoot;
       
        public BSTtree()
        {
            pRoot = null; //public constructor
            
        }

        public BSTnode rootNode()
        {
            return pRoot;
        }

        public void insertNode(int num)
        {
            
            BSTnode newNode = new BSTnode();
            newNode.data = num;
            if (pRoot == null)
            {
                pRoot = newNode; //empty tree case
                inserts++;
                
                
               
            }
            else
            {
                inserts++;
                BSTnode pCur = pRoot;
                BSTnode parentNode; //
                
                while (true) //keeps going until finished
                {
                    parentNode = pCur;
                    if (num < pCur.data)
                    {
                        pCur = pCur.left;
                        if (pCur == null) //if the left is empty create a new node
                        {
                            parentNode.left = newNode;
                            
                            return;
                        }
                    }
                    else if (num > pCur.data)
                    {
                        pCur = pCur.right;
                        if (pCur == null)
                        {
                            parentNode.right = newNode; //again empty check for right
                            
                            return;
                        }
                    }

                    else if (num == pCur.data) //duplicates
                    {
                        duplicates++;
                        
                        Console.WriteLine("You have entered a duplicate value: {0} time(s)",duplicates);
                        return;
                        
                        
                    }
                    

                }
            }
            
        }

  

        //use in order traversal to display from smallest to largest
        public void inOrderTraversal(BSTnode pRoot)
        {
            if (pRoot != null)
            {
                inOrderTraversal(pRoot.left);
                Console.Write(pRoot.data + " ");
                inOrderTraversal(pRoot.right);
                
            }
            
        }

        public int Count()
        {
            return (inserts-duplicates);
        }

        public int Depth()
        {
            return Depth(pRoot);
        }

        private int Depth(BSTnode pRoot)
        {
            if (pRoot==null)
            {
                return 0;
            }
            else
            {
                int depthRight = Depth(pRoot.right);
                int depthLeft = Depth(pRoot.left);

                if (depthRight>depthLeft) //right
                {
                    return (depthRight+1);
                }
                else if(depthRight==depthLeft) //doesn't matter which your return
                {
                    return (depthRight + 1);
                }
                else //left
                {
                    return (depthLeft + 1);
                }
            }
        }

        

    }

        class Program
        {


        static void Main(string[] args)
        {

            Console.WriteLine("Please write integers between 0 to 100 separated by a space (no duplicates please): \n");
            string[] userInput = Console.ReadLine().Split(' '); //sep by space delimiter
            int[] x = new int[userInput.Length];
            BSTtree newTree = new BSTtree();
            for (int i = 0; i < userInput.Length; i++)
            {
                x[i] = int.Parse(userInput[i]);


                newTree.insertNode(x[i]);
                newTree.inOrderTraversal(newTree.rootNode());
                Console.WriteLine();

                //test to print out each, split worked
            }

            Console.WriteLine("The number of items in the tree is: \n");
            Console.WriteLine(newTree.Count());
            Console.WriteLine("The tree's depth is: {0} and the level is: {1} \n", (newTree.Depth() - 1), newTree.Depth()); //private method called by the public method && depth is number of edges away from root so subtract 1
                                                                                                                                                        
             /*For the minimum level, I assume the root and each node having 2 children, therefore
              my test case was {1 5 9 7 3 6 3 3 2} which means 7 nodes given no duplicates, therefore i expect level 3                                   
             */

            Console.WriteLine("The minimum number of levels is: {0} \n", Math.Round((Math.Log(newTree.Count(), 2)))); //this will give me a value of 2.8 cast to int for 3
            //math.round will round to the nearest int

        }


    }
    
}


