using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs321_hw2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_load(object sender, EventArgs e)
        {
            RandomNumberClass randomfunction=new RandomNumberClass(); //initializes it
            textBox1.Text = "The number of entries into the dictionary is: ";
            textBox1.AppendText(randomfunction.useDictionary().ToString());
            textBox1.AppendText("The number of distinct items is: ");
            textBox1.AppendText(randomfunction.checkDuplicates().ToString());
            textBox1.AppendText("The time complexity of the is O(n^2) as there are two nested for statements");
            textBox1.AppendText("With sorting the list, the number of items is: ");
            textBox1.AppendText(randomfunction.sortedDuplicates().ToString());


        }
    }
}

