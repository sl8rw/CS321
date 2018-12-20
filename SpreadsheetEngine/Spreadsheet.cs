using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Xml;

namespace CptS321
{
    public class Spreadsheet
    {
        //private StandardCell[,] ssCells;
        private int rowCount, columnCount;
        private readonly Cell[,] baseCells; //abstract cell 2d array
        private Dictionary<Cell, List<Cell>> cellDependency= new Dictionary<Cell, List<Cell>>(); //SLATER YOURE DUMB DONT FORGET THE DICTIONARY INITIALIZATION THIS IS WHY THE NULL POINTER PROBLEM <3 <3 DEBUGGER
        public List<Cell> changedCells = new List<Cell>();
        public event PropertyChangedEventHandler CellPropertyChanged; //property changed event

        public Spreadsheet(int columns, int rows) //constructor
        {
            baseCells = new StandardCell[columns, rows]; //2d array implementation standard cell is base cell
            //we need to check both the row and column
            

            for (var i = 0; i < 26; i++)
            for (var j = 0; j < 50; j++)
            {
                baseCells[i, j] = new StandardCell(i, j, "");
                baseCells[i, j].PropertyChanged += Spreadsheet_PropertyChanged; //subscription
            }
        }

        public Cell GetCell(int colIndex, int rowIndex) //maybe this is a problem????? IDK
        {
            return baseCells[colIndex, rowIndex]; //or returns null if no cell
        }

        public Cell GetCell(string name) //overriden
        {
            var col = name[0] - 'A';
            var row = Convert.ToInt32(name.Substring(1)) - 1;
            return GetCell(col, row);
        }


        private void rmDep(Cell cellCheck) //this was taken from stackoverflow and MSDN C# guide
        {
            foreach (var depCell in cellDependency.Values)
                if (depCell.Contains(cellCheck))
                    depCell.Remove(cellCheck);
        }

        //linr 69/115/Cell 91/Cell 63/Form 1 83
        private void addDep(Cell referenceCell, List<string> temp)
        {
            foreach (string i in temp)
            {
                Cell tempCell = GetCell(i);
                if (!cellDependency.ContainsKey(tempCell)) cellDependency[tempCell] = new List<Cell>();
                cellDependency[tempCell].Add(referenceCell);
            }
        }

        private void updateDep(Cell tempCell)
        {
            foreach (Cell depCell in cellDependency[tempCell].ToList<Cell>())
                //Updating the cell here
                Spreadsheet_PropertyChanged(depCell, new PropertyChangedEventArgs("Text"));
        }

        private void DefineVars(ExpTree newTree)
        {
            foreach (var name in newTree.varNameList)
            {
                var col = name[0] - 'A';
                var row = Convert.ToInt32(name.Substring(1)) - 1;
                var tempCell = GetCell(col, row);
                try
                {
                    newTree.SetVar(name, Convert.ToDouble(tempCell.Value));
                }
                catch (FormatException)
                {
                    
                }
                
            }
        }

        private void Spreadsheet_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //from crandall

            rmDep((Cell) sender);
            if (e.PropertyName == "Text")
            {
                changedCells.Add((Cell) sender);

                if (!((Cell) sender).Text.StartsWith("="))
                {
                    ((Cell) sender).Value = ((Cell) sender).Text;
                }
                else
                {
                    var expression = ((Cell) sender).Text; //this will get the expression
                    try
                    {
                        var subExp = expression.Substring(1);
                        ExpTree ssExpression = new ExpTree(subExp);
                        DefineVars(ssExpression);
                        ((Cell) sender).Value = ssExpression.Eval().ToString();
                        if (((Cell) sender).Value == "NaN")
                        {
                            ((Cell) sender).Value = expression;
                            ((Cell) sender).Value = GetCell(expression.Substring(1)).Value;
                            CellPropertyChanged.Invoke(sender,
                                new PropertyChangedEventArgs("Value"));
                        }

                        addDep((Cell) sender, ssExpression.varNameList);
                    }
                    catch

                    {
                        //we are concerned with #REF
                        try
                        {
                            var ssExpression = new ExpTree(((Cell) sender).Text.Substring(1).ToUpper());
                            ((Cell) sender).Value = "#REF";
                            CellPropertyChanged.Invoke(sender,
                                new PropertyChangedEventArgs("Value"));
                            addDep((Cell) sender, ssExpression.varNameList);
                        }
                        catch
                        {
                            //need to check if there is an = operator without any following
                            ((Cell) sender).Value = "#REF";
                            CellPropertyChanged.Invoke(sender,
                                new PropertyChangedEventArgs("Value"));
                        }

                        ((Cell) sender).Value = "#REF";
                        CellPropertyChanged.Invoke(sender,
                            new PropertyChangedEventArgs("Value"));
                    }
                }
            }

            if (cellDependency.ContainsKey((Cell) sender)) updateDep((Cell) sender);
            CellPropertyChanged.Invoke(sender,
                new PropertyChangedEventArgs("Value"));
        }


        /*public void triggerEvent()
        {
            baseCells[4, 10].Value = "50";
            baseCells[6, 12].Text = "=E10"; //It's G because 0,1,2,3   -->10/09/2018 
        }*/

        public void SaveXML(Stream ssXML) //saves cells that have been changed
        {
            XmlWriterSettings xmlSettings=new XmlWriterSettings();
            //need to write elements on new lines with proper indentation
            xmlSettings.Indent = true;
            using (XmlWriter writer = XmlWriter.Create(ssXML, xmlSettings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Spreadsheet");
                foreach (Cell cell in changedCells)
                {
                    writer.WriteStartElement("Cell");
                    writer.WriteElementString("Column", cell.ColumnIndex.ToString());
                    writer.WriteElementString("Row", cell.RowIndex.ToString());
                    writer.WriteElementString("Text", cell.Text);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Dispose(); //releases all resources by text writer
            }
        }

        public void LoadXML(Stream ssXML)
        {
            foreach (Cell cell in baseCells)
            {
                cell.Text = "";
            }

            XmlReader reader = XmlReader.Create(ssXML);
            changedCells.Clear();
            while (reader.Read())
            {
                if (reader.Name == "Cell")
                {
                    string cText = null;
                    int row=0 , column = 0;
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            if (reader.Name == "Row")
                            {
                                reader.Read();
                                row = Convert.ToInt32(reader.Value);
                            }
                            else if (reader.Name == "Column")
                            {
                                reader.Read();
                                column = Convert.ToInt32(reader.Value);
                            }
                            else if (reader.Name == "Text")
                            {
                                reader.Read();
                                cText = reader.Value;
                                
                            }
                        }
                        else if (reader.Name == "Cell")
                        {
                            break;
                        }
                    }

                    if (cText != null)
                    {
                        this.baseCells[column, row].Text = cText;
                    }
                }
            }

            reader.Dispose();
        }
        
    }
}