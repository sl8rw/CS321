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
using CptS321;


namespace CptS321
{
    public class StandardCell : Cell
    {
        public StandardCell(int column, int row) : base(column, row) //delegates the base class constructor
        {

        }
    }
}
