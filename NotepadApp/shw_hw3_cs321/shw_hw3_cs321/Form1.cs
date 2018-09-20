using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace shw_hw3_cs321
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
        private void LoadFromFile(object sender, System.EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog(); //taken from msdn
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                textBox1.Text = sr.ReadToEnd();
                sr.Close();
            }
        }





        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e) //registers event dont know yet...
        {

        }

        private void SaveButton_Click(object sender, EventArgs e) //stream writer
        {
            StreamWriter strwrite;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) //ok or cancel
            {
                strwrite = new StreamWriter(saveFileDialog1.FileName); //type in .txt
                strwrite.Write(textBox1.Text);
                strwrite.Close(); //have to close stream

            }

        }

        private void InsertNumberButton_Click(object sender, EventArgs e)
        {
            InputBox.Visible = true;

        }

        private void InputBoxCancel_Click(object sender, EventArgs e)
        {
            InputBox.Visible = false;
        }

        private void InputBoxSubmit_Click(object sender, EventArgs e)
        {
            
            int x = 0;
            
            Int32.TryParse(textBox2.Text, out x);

            FibonacciTextReader textRead=new FibonacciTextReader(x);

            textBox1.Text=textRead.ReadToEnd(); //writes to text box
            textRead.Close();
            InputBox.Visible = false;
        }
    }
}

    