using System;

class Program
{
    public static void Main()
    {
        //we will integrate a 2-d mapping of number of ways a group of pence/pound type(s) may form a certain sum. The column that will determine the sum of 200 (pences) in this case will ultimately give us the final solution in its last row where all pence/pound types in the currency has been accounted for.  

				//the following are just for testing purposes with other simpler values:
        //int[] pence_pound_types = { 1, 2, 3 }; int sum = 6;  --> should return 7 mathematically.
        //int[] pence_pound_types = { 1, 2, 5, 10 }; int sum = 10;  --> should return 11 mathematically.
        //int[] pence_pound_types = { 2, 4, 8, 16 }; int sum = 16;  --> should return 10 mathematically. 
        
				  int[] pence_pound_types = { 1, 2, 5, 10, 20, 50, 100, 200 }; int sum = 200; //main problem values
        int[,] table = new int[pence_pound_types.Length, sum + 1];
        int with_type;
        int without_type;

        for (int i = 0; i < pence_pound_types.Length; i++)
        {
            table[i, 0] = 1; //there is only one way to get the sum of 0, thus set the first column elements to 1.
        }

        for (int j = 1; j <= sum; j++)
        {
            for (int k = 0; k < pence_pound_types.Length; k++)
            {
                with_type = (j - pence_pound_types[k] >= 0) ? table[k, j - pence_pound_types[k]] : 0; //counts the number of ways to create the corresponding sum if there is at least one instance of using this type of pence/pound.
                without_type = (k > 0) ? table[k - 1, j] : 0; //counts the number of ways to create the corresponding sum if there is no one instance of using this type of pence/pound.
                table[k, j] = with_type + without_type;
            }
        }
        Console.Write(table[pence_pound_types.Length - 1, sum]);
    }
}