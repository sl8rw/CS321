using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CptS321;

namespace Spreadsheet
{
    public partial class Form1 : Form
    {

        public CptS321.Spreadsheet ss;

        public Form1()
        {
            InitializeComponent();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView2.Columns.Clear();
            ss =new CptS321.Spreadsheet(26,50);
            ss.CellPropertyChanged += Form1CellPropertyChanged; //subscription
            dataGridView2.CellBeginEdit += editCell;
            dataGridView2.CellEndEdit += endEdit;
           
            for (int i = 65; i <= 90; i++) //ASCII codes for capital letters A - Z
            {
                dataGridView2.Columns.Add(Convert.ToChar(i).ToString(), Convert.ToChar(i).ToString());
            }

            for (int j = 1; j <= 50; j++) //makes 50 rows
            {
                DataGridViewRow row = new DataGridViewRow();
                row.HeaderCell.Value = j.ToString();
                dataGridView2.Rows.Add(row);
            }


            //CptS321.Spreadsheet ss = new CptS321.Spreadsheet(50, 26); create a local form


            //ss.triggerEvent();
            
            



        }

        private void editCell(object sender, DataGridViewCellCancelEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            
            dataGridView2.Rows[row].Cells[col].Value = (ss.GetCell(col, row)).Text;
            textBox1.Text = (ss.GetCell(col, row)).Text;
            textBox2.Text = dataGridView2.Columns[col].HeaderText;
            textBox2.AppendText((row+1).ToString());

        }

        private void endEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;
            string text = "";
            Cell tempCell = ss.GetCell(col, row);
            text = dataGridView2.Rows[row].Cells[col].Value.ToString();
            textBox1.Text = text;
            tempCell.Text = text;
            textBox1.Text = tempCell.Text;
        }

        void textBox1_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                dataGridView2.Focus();
            }
        }

        void textBox1_Exit(object sender, EventArgs e)
        {
            ss.GetCell(textBox2.Text).Text = textBox1.Text;
        }
        public void Form1CellPropertyChanged(object sender, PropertyChangedEventArgs e) //specific cell updated, now need to update specific grid view
        {

            Cell tempCell = (Cell) sender;
            if (tempCell != null && e.PropertyName == "Value")
            {
                dataGridView2.Rows[tempCell.RowIndex].Cells[tempCell.ColumnIndex].Value = tempCell.Value;
            }


        }

        private void Demo_Click(object sender, EventArgs e) //demo button
        {
            //need to set random cells
            Random rand = new Random();
            for (int i = 0; i < 50; i++)
            {
               //get cell is column, row
                Cell cell = ss.GetCell(rand.Next(0,26), rand.Next(0, 50));
                cell.Text = "Hello,World";
            }

            for (int i = 0; i < 50; i++) //make sure row starts at 1
            {
                Cell cell = ss.GetCell(1,i);
                cell.Text = "This is cell B" + (i+1).ToString();
            }

            for (int i = 0; i < 50; i++)
            {
                Cell cell = ss.GetCell(0,i);
                cell.Text="=B"+(i).ToString();
            }
        }

    }

        /*private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Cell cell = (Cell) sender;
            if (e.PropertyName == "Value")
            {
               
            }
        }

        
    }*/
    }

