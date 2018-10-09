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


        private StandardCell[,] ssCells;
        private Cell[,] baseCells;
        public event PropertyChangedEventHandler CellPropertyChanged; //property changed event

        public Spreadsheet(int rows, int columns) //constructor
        {
            ssCells = new StandardCell[columns, rows]; //2d array implementation
            //we need to check both the row and column

            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    ssCells[i, j].PropertyChanged += Spreadsheet_PropertyChanged;
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

            if (e.PropertyName == "Text")
            {
                if (!((Cell) sender).Text.StartsWith("="))
                {
                    ((Cell) sender).Value = ((Cell) sender).Text;
                }
                else if (((Cell) sender).Text.StartsWith("="))
                {
                    string str = ((Cell) sender).Text.Substring(1); //starts at position 1 if there is
                    int column = Convert.ToInt16(str[0]) - 'A';
                    Int32.TryParse(((Cell) sender).Text.Substring(1), out int row);
                    ((Cell) sender).Value = (GetCell(column, row)).Value;
                }
            }

            CellPropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("Value"));

        }


        public void triggerEvent()
        {

        }

    }
}

