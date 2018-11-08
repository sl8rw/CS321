using System.ComponentModel;

namespace CptS321
{
    public abstract class Cell : INotifyPropertyChanged //must be abstract class
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected int rowI;
        protected int colI;
        protected string newText;
        protected string newValue; //inheriting classes can now see this

        public Cell(int cIndex, int rIndex)
        {
            rowI = rIndex;
            colI = cIndex;
        }

        public int RowIndex
        {
            get { return rowI; }
        }

        public int ColumnIndex
        {
            get { return colI; }
        }

        public string Value
        {
            get => newValue;
            protected internal set
            {
                if (value != this.newValue)
                {
                    this.newValue = value;
                    onPropertyChanged("Value");
                }
                else
                {
                    
                }
            }
        }


        public string Text
        {
            get => newText;
//returns protected property

            set
            {
                if (value != newText) //new text is different
                {
                    newText = value;
                    onPropertyChanged("Text");
                }
                else
                {
                    try
                    {
                        if (newText[0] == '=')
                        {
                            newText = value;
                            onPropertyChanged("Text");
                        }
                    }
                    catch
                    {
                        return;
                    }
                }
            }
        }


        protected void onPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name)); //creating an event
            else
                return;
        }
    }
}