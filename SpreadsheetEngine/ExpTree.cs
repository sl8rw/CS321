using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

        Dictionary<string, int> precedenceDictionary = new Dictionary<string, int>()
        {
            {"*", 2}, {"/", 2}, {"+", 1}, {"-", 1}, {"(", 0}, {")", 0}
        };

        private Node mRoot;
        private static Dictionary<string, double> mDict = new Dictionary<string, double>();
        public List<string> varNameList = new List<string>();
        private Stack<string> oStack = new Stack<string>();
        public string tempExp { get; private set; }

        private class OperationNode : Node
        {
            private string mOp;
            public Node mLeft, mRight;

            public OperationNode(string nOp)
            {
                mOp = nOp;
                mLeft = null;
                mRight = null;
            }

            public override double Eval()
            {
                var result = 0.0;
                if (mOp == "+") //addition
                {
                    result = mLeft.Eval() + mRight.Eval();
                }
                else if (mOp == "-") //subtraction
                {
                    result = mLeft.Eval() - mRight.Eval();
                }
                else if (mOp == "*") //multiplication
                {
                    result = mLeft.Eval() * mRight.Eval();
                }
                else if (mOp == "/") //division
                {
                    if (mRight.Eval() != 0)
                    {
                        result = mLeft.Eval() / mRight.Eval();
                    }

                    else
                    {
                        //tree can't handle the exception, but the node might be able to, if you go to Node, then data corruption
                        //up in the spreadsheet, put try catch in the spreadsheet around the evaluate.
                        //#Div/0! in excel is an example of exception handling
                        //add to unit tests that tests for divide by 0 and catch the exception
                        result = double.NaN; //exception is thrown when you divide by 0 ->expanded return set
                        //Console.WriteLine("Error: You attempted to divide by 0...\n");
                    }
                }

                return result;
            }
        }

        //redo evaluation using the shunting yard algorithm-->WIKI pseudocode
        private void shuntingYardAlgorithm()
        {
            Stack<string> opStack = new Stack<string>();
            //make regex
            var regExPattern = @"([-/\+\*\(\)])";
            var token = Regex.Split(tempExp, regExPattern).Where(str => str != string.Empty).ToList();
            foreach (var t in token)
                if (!precedenceDictionary.ContainsKey(t))
                {
                    oStack.Push(t);
                }
                else if (t == "(")
                {
                    opStack.Push(t);
                }
                else if (t == ")")
                {
                    //neeed to remove parentheses from R to L
                    while (opStack.Count != 0 && opStack.Peek() != "(") oStack.Push(opStack.Pop());

                    if (opStack.Peek() == "(") opStack.Pop();
                }
                else if (precedenceDictionary.ContainsKey(t) && (opStack.Count() == 0 || opStack.Peek() == "("))
                {
                    opStack.Push(t);
                }
                else if (precedenceDictionary.ContainsKey(t) &&
                         precedenceDictionary[t] >= precedenceDictionary[opStack.Peek()])
                {
                    opStack.Push(t);
                }
                else if (precedenceDictionary.ContainsKey(t) &&
                         (precedenceDictionary[t] <= precedenceDictionary[opStack.Peek()]))
                {
                    while (opStack.Count() != 0 &&
                           (precedenceDictionary[t] <= precedenceDictionary[opStack.Peek()]))
                        oStack.Push(opStack.Pop());

                    opStack.Push(t);
                }

            while (opStack.Count != 0) oStack.Push(opStack.Pop());

            Stack<string> final = new Stack<string>();
            while (oStack.Count() != 0) final.Push(oStack.Pop());

            oStack = final;
        }


        private class VariableNode : Node //this is in case the user inserts a variable
        {
            public string mVar;
            private double val;

            public VariableNode(string nVar)
            {
                mVar = nVar;
                val = 0.0;
            }

            public override double Eval()
            {
                //we have a variable, so we need to assign the value to the variable

                try
                {
                    val = mDict[mVar];
                    return val;
                }

                catch (KeyNotFoundException)
                {
                    return double.NaN;
                }
            }
        }

        private class NumberNode : Node
        {
            private double mVal;

            public NumberNode(double nVal)
            {
                mVal = nVal;
            }

            public override double Eval()
            {
                return mVal;
            }
        }
    

    public void SetVar(string varName, double varValue)
        {
            try
            {
                mDict.Add(varName, varValue);
            }
            catch
            {
                mDict[varName] = varValue;
            }
        }


        public double Eval()
        {
            try
            {
                return mRoot.Eval();
            }
            catch (NullReferenceException)

            {
                return double.NaN;
            }
        }

        private void BuildTree()
        {
            shuntingYardAlgorithm();
            var newStack = new Stack<Node>();
            while (oStack.Count() != 0)
            {
                if (precedenceDictionary.ContainsKey(oStack.Peek()))
                {
                    var newOp = new OperationNode(oStack.Pop());
                    try
                    {
                        newOp.mRight = newStack.Pop();
                    }
                    catch

                    {
                        newOp.mRight = null;
                    }

                    try
                    {
                        newOp.mLeft = newStack.Pop();
                    }
                    catch
                    {
                        newOp.mLeft = null;
                    }

                    newStack.Push(newOp);
                }
                else
                {
                    if (Double.TryParse(oStack.Peek(), out var value))
                    {
                        var tempNum = new NumberNode(value);
                        newStack.Push(tempNum);
                        oStack.Pop();
                    }
                    else
                    {
                        var tempVar = new VariableNode(oStack.Pop());
                        varNameList.Add(tempVar.mVar);
                        newStack.Push(tempVar);
                    }
                }
            }

            mRoot = newStack.Pop();
        }

        public ExpTree(string expression)
        {
            mDict.Clear();
            tempExp = expression;
            varNameList.Clear();
            BuildTree();
        }
    }
}