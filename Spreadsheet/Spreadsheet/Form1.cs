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
        public Form1()
        {
            InitializeComponent();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 65; i <= 90; i++) //ASCII codes for capital letters A - Z
            {
                dataGridView2.Columns.Add(new DataGridViewTextBoxColumn() {HeaderText = Convert.ToChar(i).ToString()});
            }

            /* dataGridView2.Rows.Add(50);
             int rowNumber = 1;
 
             foreach (DataGridViewRow row in dataGridView2.Rows)
             {
                 if (row.IsNewRow) continue;
                 row.HeaderCell.Value = rowNumber;
                 rowNumber = rowNumber + 1;
             }
 
             dataGridView2.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
 
     */

            for (int j = 0; j < 50; j++) //makes 50 rows
            {
                DataGridViewRow row = new DataGridViewRow();
                row.HeaderCell.Value = (j + 1).ToString();
                dataGridView2.Rows.Add(row);
            }


            CptS321.Spreadsheet ss;




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
}
