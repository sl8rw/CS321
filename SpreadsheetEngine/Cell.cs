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
    public abstract class Cell : INotifyPropertyChanged //must be abstract class
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int newRowI;
        private int newColI;
        private string newText;
        protected internal string newValue; //inheriting classes can now see this

        public Cell(int cIndex, int rIndex)
        {
            RowIndex = rIndex;
            ColumnIndex = cIndex;
        }

        public int RowIndex { get; protected set; }

        public int ColumnIndex { get; protected set; }

        public string Value { get; set; }


        public string Text
        {
            get { return newText; } //returns protected property

            set
            {
                if (value == this.newText)
                {
                    return;
                }
                else if (value != this.newText) //new text is different
                {
                    this.newText = value;
                    onPropertyChanged("Text");

                }
            }
        }

      
        protected void onPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name)); //creating an event
            }
        }
    }

}






       