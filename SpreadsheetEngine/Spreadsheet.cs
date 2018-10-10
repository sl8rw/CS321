using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace CptS321
{
    public class Spreadsheet
    {


        //private StandardCell[,] ssCells;
        private Cell[,] baseCells;
        public event PropertyChangedEventHandler CellPropertyChanged; //property changed event

        public Spreadsheet(int columns, int rows) //constructor
        {
            baseCells = new StandardCell[columns, rows]; //2d array implementation standard cell is base cell
            //we need to check both the row and column

            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j <50; j++)
                {
                    baseCells[i, j]=new StandardCell(i,j);
                    baseCells[i, j].PropertyChanged += Spreadsheet_PropertyChanged; //subscription

                }
            }



        }

        public Cell GetCell(int colIndex, int rowIndex)
        {
            return baseCells[colIndex, rowIndex]; //or returns null if no cell
        }

        public int RowCount //remember newCell(0,1) indexed
        {
            get { return baseCells.GetLength(0); }
        }

        public int ColumnCount //this needs to be 1 then
        {
            get { return baseCells.GetLength(1); }
        }

        private void Spreadsheet_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //from crandall
            int row = 0;
            int column = 0;
            Cell localCell = ((Cell) sender);
            if (e.PropertyName == "Text")
            {
                if (!((Cell) sender).Text.StartsWith("="))
                {
                    ((Cell) sender).Value = ((Cell) sender).Text;
                }
                else if (((Cell) sender).Text.StartsWith("="))
                {
                    string str = ((Cell) sender).Text.Substring(1); //starts at position 1 if there is
                    column = Convert.ToInt32((str[0]) - 'A');
                    Int32.TryParse(str.Substring(1), out row);
                    ((Cell) sender).Value = (GetCell(column, row)).Value;
                }
            }

            

            CellPropertyChanged?.Invoke(((Cell)sender), new PropertyChangedEventArgs("Value")); //invoking method for cell being changed

        }


        public void triggerEvent()
        {
            baseCells[4, 10].Value = "50";
            baseCells[6, 12].Text = "=E10"; //It's G because 0,1,2,3   -->10/09/2018 
        }

    }
}

