using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BSTtree
{
    class BSTtree<T> : BinTree<T> where T : IComparable //allows T to be compared
    {
        int inserts;
        int duplicates;
        public BSTnode<T> pRoot;


        public BSTtree()
        {
            pRoot = null; //public constructor
            inserts = 0;
            duplicates = 0;

        }

        public BSTnode<T> rootNode()
        {
            return pRoot;
        }


        private int InsertHelper(BSTnode<T> pCur, BSTnode<T> newNode)
        {
            if (pCur > newNode)
            {
                if (pCur.left != null)
                {
                    return InsertHelper(pCur.left, newNode);
                }
                else
                {
                     pCur.left = newNode;

                }
                

            }
            else if (pCur < newNode)
            {
                if (pCur.right != null)
                {
          
                    return InsertHelper(pCur.right, newNode);

                }
                else
                {
                    pCur.right = newNode;
                }
            }
            return 0;
        }

        public override void Insert(T data)
        {
            BSTnode<T> newNode = new BSTnode<T>(data);
            //int number = 0;


            if (inserts > 0)
            {
                InsertHelper(pRoot, newNode);
                inserts++;
            }

            else
            {
                pRoot = newNode;
                inserts++;
            }
        }

        public override bool Contains(T val)
        {
            BSTnode<T> newNode = new BSTnode<T>(val);
            return ContainsHelper(pRoot,newNode);

        }

         private bool ContainsHelper(BSTnode<T> pRoot, BSTnode<T> newNode)
        {
            if (pRoot == null)
            {
                return false;
            }

           
            else if (newNode < pRoot)
                {
                    return ContainsHelper(pRoot.left, newNode);
                }
             else if (newNode > pRoot) 
                {
                    return ContainsHelper(pRoot.right, newNode);
                }

            else
            {
                
                    return true;
            }

        }



        //use in order traversal to display from smallest to largest
        private void InOrderHelper(BSTnode<T> pRoot)
        {
            if (pRoot != null)
            {

                InOrderHelper(pRoot.left);
                Console.Write(pRoot.data + " ");
                InOrderHelper(pRoot.right);

            }
           
        }

        private void PreOrderHelper(BSTnode<T> pRoot)
        {
            if (pRoot != null)
            {
                Console.Write(pRoot.data + " ");
                InOrderHelper(pRoot.left);
                InOrderHelper(pRoot.right);



            }

        }

        private void PostOrderHelper(BSTnode<T> pRoot)
        {
            if (pRoot != null)
            {
                InOrderHelper(pRoot.left);
                InOrderHelper(pRoot.right);
                Console.Write(pRoot.data + " ");


            }

        }

        public override void InOrder()
        {
            InOrderHelper(pRoot);
        }

        public override void PreOrder()
        {
            PreOrderHelper(pRoot);
        }


        public override void PostOrder()
        {
            PostOrderHelper(pRoot);
        }




        public int Count()
        {
            return (inserts - duplicates);
        }

        public int Depth()
        {
            return Depth(pRoot);
        }

        private int Depth(BSTnode<T> pRoot)
        {
            if (pRoot == null)
            {
                return 0;
            }
            else
            {
                int depthRight = Depth(pRoot.right);
                int depthLeft = Depth(pRoot.left);

                if (depthRight > depthLeft) //right
                {
                    return (depthRight + 1);
                }

                else if (depthRight == depthLeft) //doesn't matter which your return
                {
                    return (depthRight + 1);
                }

                else //left
                {
                    return (depthLeft + 1);
                }
            }
        }





    }
}
