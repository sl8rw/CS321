using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Numerics;


namespace shw_hw3_cs321
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class FibonacciTextReader : TextReader //inherits from text reader
    {
        
        private int maxNum;
        private BigInteger fPrev;
        private BigInteger fPrevPrev;
        private int readLineNumber;




        public FibonacciTextReader(int maxNumLines) //constructor
        {
            maxNum = maxNumLines;
            fPrevPrev = 1;
            fPrev = 0;
            readLineNumber = 1; //want to be one to start reading first line


            //F1+CV=1;
            //F1+F2=2
            //3,5,8,13,21,34,55,89



        }

        private BigInteger FibonacciCalculation() //how  many times its called
        {


                    BigInteger result; //accounts for big number
                    result = fPrevPrev + fPrev;
                    fPrevPrev = fPrev; //increments fPrevPrev
                    fPrev = result; //increments fPrev
                    return result;

        }
        //a function is a method, a method is not necessarily a function
        //procedures do not have return values, functions do------->not in C#
        

        public override string ReadLine()
        {
            string str;
            if (readLineNumber == 1)
            {
                str=readLineNumber + ":\t" + 0.ToString();
                
            }
            else
            {
                str = $"{readLineNumber}:\t{FibonacciCalculation().ToString()}\n";
                //str=readLineNumber+FibonacciCalculation().ToString(); //appending readLineNumber to Fib Calc
            }

            readLineNumber++; //need to increment to which line otherwise read 0 nonstop
            return str;
        }

        public override string ReadToEnd()
        {
            string str=""; //empty string could string.empty
            while (readLineNumber <= maxNum)
            {
                str+=(ReadLine() + "\r\n"); //appends the string
            }

            return str;
        }
    }
}

//nouns are classes
//verbs are methods/functions
