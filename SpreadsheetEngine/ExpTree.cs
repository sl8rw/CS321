using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CptS321
{
    public class ExpTree
    {
        //need a node
        //we are going to have nodes for what we are operating on, and we are going to have the operation nodes too


        private abstract class Node
        {
            public abstract double Eval();
        }

        private Node mRoot;
        private static Dictionary<string, double> mDict;

        private class OperationNode : Node
        {
            private char mOp;
            private Node mLeft, mRight;

            public OperationNode(char nOp, Node nL, Node nR)
            {
                this.mOp = nOp;
                this.mLeft = nL;
                this.mRight = nR;
            }

            public override double Eval() //overwrites from Node abstract class
            {
                double leftExp = mLeft.Eval(); //save evaluation from left side to leftExp var
                double rightExp = mRight.Eval(); //save evaluation from right side to rightExp var
                double result = 0.0;

                if (mOp == '+') //addition
                {
                    result = leftExp + rightExp;
                }
                else if (mOp == '-') //subtraction
                {
                    result = leftExp - rightExp;
                }
                else if (mOp == '*') //multiplication
                {
                    result = leftExp * rightExp;
                }
                else if (mOp == '/') //division
                {
                    result = (leftExp) / (rightExp);
                }

                return result;

            }


        }

        private class VariableNode : Node //this is in case the user inserts a variable
        {
            private string mVar;

            public VariableNode(string nVar)
            {
                this.mVar = nVar;
            }

            public override double Eval()
            {
                //we have a variable, so we need to assign the value to the variable

                if (!mDict.ContainsKey(mVar))
                {
                    mDict[mVar] = 0.0; //if the variable does not exist, than the variable needs to be initialized
                }

                return mDict[mVar];
            }
        }

        private class NumberNode : Node
        {
            private double mVal;

            public NumberNode(double nVal)
            {
                this.mVal = nVal;
            }

            public override double Eval()
            {
                return mVal;
            }
        }
        private Node BuildNodes(string expression)
        {
            double mVal;
            
            if (double.TryParse(expression, out mVal))
            {
                return new NumberNode(mVal);
            }
            else
            {
                return new VariableNode(expression); //if not a number, it's a variable
            }
        }

        private int BuildTreeHelper(string expression) //gets an index value
        {
            int p = 0;
            int length = expression.Length;
            //int i = length - 1;
            int j = -1;
            for (int i=expression.Length-1; i >= 0; i--)
            {
                switch (expression[i]) //need to now update so that it accepts ()s
                {  //just when we hit an expression we have to build tree, empty cases allowed in c#
                    case '(': 
                        p++;
                        break;
                    case ')':
                        p--; 
                        break;
                    case '+':
                    case '-':
                        if (p == 0) 
                        {
                            return i;
                        }

                        break;
                    case '*':
                    case '/':
                        if ((p == 0) && (j == -1)) 
                        {
                            j = i;
                        }

                        break;
                }
            }

            return j;
        }

        private static int ParenthesesCheck(string expression) //returns 1 if the parentheses are enclosed, 0 o.w.
        {
            int p = 0;
            //int length = expression.Length - 1;
            int flag = 0;

                if (expression[0]=='(' && expression[expression.Length-1]==')')
                {
                    for (int i=1; i < expression.Length-1; i++)
                    {
                        switch (expression[i])
                        {
                            case '(': //start
                                p++;
                                break;
                            case ')': //end parentheses, ensures they are closed
                                if (p == 0)
                                {
                                    flag = 0; //false
                                }

                                p--;
                                break;

                            default:
                                //Console.WriteLine("Error in parentheses");
                                break;
                        }
                    }

                    if (p == 0)
                    {
                        flag = 1; //parentheses are enclosed
                    }

                    
            
            }

            

            return flag;
        }


        private Node BuildTree(string expression)
        {
            int flag = ParenthesesCheck(expression); //if one they are enclosed, 0 o.w.
            int i = 0;
            while (flag == 1) //1 means enclosed
            {
                expression = expression.Substring(1, expression.Length - 2);
                flag = ParenthesesCheck(expression);

            }

            i = BuildTreeHelper(expression);

            if (i != -1)
            {
                return new OperationNode(expression[i], BuildTree(expression.Substring(0, i)),
                    BuildTree(expression.Substring(i+1)));
            }

            return BuildNodes(expression);


        }

        
       public ExpTree(string expression)
        {
            mDict = new Dictionary<string, double>();
            this.mRoot = BuildTree(expression);
            mDict.Clear(); //just clears the values when I close out

        }

        

        public void SetVar(string varName, double varValue)
        {
            mDict[varName] = varValue;
        }

        public double Eval()
        {
           if (mRoot != null)//not done
            {
                return mRoot.Eval();
            }
           else
           {
               {
                   return double.NaN;
               }
           }

        }

      
    }
}
