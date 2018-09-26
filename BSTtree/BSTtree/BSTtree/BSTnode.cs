using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTtree
{
    class BSTnode<T> where T : IComparable //allowed to use icomparable
    {
        public T data;
        public BSTnode<T> left;
        public BSTnode<T> right;
        public void display()
        {
            Console.Write(data);
        }

        public BSTnode(T newData)
        {
            this.data = newData;
        }
        //must implement ==, !=, >=, <=, <, >
        public static bool operator >=(BSTnode<T> lhs, BSTnode<T> rhs)
        {
            return lhs.data.CompareTo(rhs.data) >= 0;
        }

        public static bool operator <=(BSTnode<T> lhs, BSTnode<T> rhs)
        {
            return lhs.data.CompareTo(rhs.data) <= 0;
        }

        public static bool operator <(BSTnode<T> lhs, BSTnode<T> rhs)
        {
            return lhs.data.CompareTo(rhs.data) < 0;
        }

        public static bool operator >(BSTnode<T> lhs, BSTnode<T> rhs)
        {
            return lhs.data.CompareTo(rhs.data) > 0;
        }

       /* public static bool operator !=(BSTnode<T> lhs, BSTnode<T> rhs)
        {
        
        
            return lhs.data.CompareTo(rhs.data) != 0;
        }

        public static bool operator ==(BSTnode<T> lhs, BSTnode<T> rhs)
        {
            return lhs.data.CompareTo(rhs.data) == 0;
        }
        */

    }
}
