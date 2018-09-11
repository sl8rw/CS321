using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace cs321_hw2
{
 
    class RandomNumberClass
    {

        Random randomNumber = new Random();

        List<int> randomNumberList = new List<int>();


        public int useDictionary()
        {


            var randomNumberDictionary = new Dictionary<int, int>();
            for (var i = 0; i < 10000; i++)
            {
                randomNumberList.Add(randomNumber.Next(20000));
            }

            foreach (int i in randomNumberList) //i is the actual element, int because its a list of int
            {
                if (!randomNumberDictionary.Keys.Contains(i))
                {
                    randomNumberDictionary.Add(i, i);
                }
            }


            int countOfItems = randomNumberDictionary.Count; //counts number of keys
            return countOfItems;

        }
        //display countOfItems

        //need to use for each 

        /*
         */
        public int checkDuplicates()
        {
            int duplicates = 0;
            int actualDuplicates = 0;

            for (int x = 0; x <= 20000; x++)
            {

                duplicates = 0;
                for (int i = 0; i < 10000; i++)
                {
                   
                    if (randomNumberList[i] == x)
                    {
                        duplicates++;
                    }

                }

                if (duplicates > 1)
                {
                    actualDuplicates += (duplicates - 1);
                }

               
                

            }

            return randomNumberList.Count - actualDuplicates;
        }


       

        public int sortedDuplicates()
        {
            int compare1 = 0;
            int compare2 = 1;
            int duplicates = 0;
            randomNumberList.Sort();
            while (compare2 < 10000)
            {

                if ((randomNumberList[compare1]) == (randomNumberList[compare2]))
                {
                    duplicates++;
                }

                compare1++;
                compare2++;
            }

            return randomNumberList.Count - duplicates;
            
        }



    }
}
