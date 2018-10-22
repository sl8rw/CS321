using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    class Program
    {
        private ExpTree newExpressionTree;

        public void Menu()
        {
            int flag = 0;
            string expressionString = "A1-12-C1"; 
            string varName;
            string varValue;
            double numValue;

            newExpressionTree = new ExpTree(expressionString);

            while (flag != 1) //1 causes problems
            {
                Console.WriteLine("_________________MENU_________________");
                Console.WriteLine("The expression entered is: " + expressionString);
                /*Console.WriteLine("Would you like to update this expression? Enter y for yes and n for no \n");
                char userInput = Console.ReadKey().KeyChar; //this can cause errors in program testing, just for my own testing purposes
                if (userInput == 'y')
                {
                    Console.WriteLine("Please input your new expression with NO whitespaces: \n");
                    expressionString = Console.ReadLine();

                }*/

                Console.WriteLine("(1): Update Expression");
                Console.WriteLine("(2) Update the value");
                Console.WriteLine("(3) Evaluate the tree");
                Console.WriteLine("(4) GoodBye");
                string userInput = Console.ReadLine().ToString();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Please enter a new expression: ");
                        expressionString = Console.ReadLine();
                        newExpressionTree = new ExpTree(expressionString);
                        break;
                    case "2":
                        Console.WriteLine("Enter a variable name: ");
                        varName = Console.ReadLine();
                        Console.WriteLine("Now please enter a value of that variable: ");
                        varValue = Console.ReadLine();
                        numValue = Convert.ToDouble(varValue); //need to make the value a double

                        newExpressionTree.SetVar(varName, numValue); //takes string and double
                        break;
                    case "3":
                        Console.WriteLine(newExpressionTree.Eval());
                        break;
                    case "4":
                        flag = 1; //exit flag
                        break;


                }
            }
        }

  
        static void Main(string[] args)
        {
            Program demo = new Program();
            demo.Menu();
        }
    }
}
