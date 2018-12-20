namespace CptS321
{
    public class StandardCell : Cell
    {
        public StandardCell(int column, int row, string newText) :
            base(column, row) //delegates the base class constructor
        {
            this.newText = newText;
            newValue = newText;
        }
    }
}