using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodukuSolutionValidatorCodeWars
{
    class Program
    {
        static void Main(string[] args)  //tests
        {
            int[][] test9 = new int[][]
        {
          new int[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
          new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
          new int[] {1, 9, 8, 3, 4, 2, 5, 6, 7},
          new int[] {8, 5, 9, 7, 6, 1, 4, 2, 3},
          new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
          new int[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
          new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
          new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
          new int[] {3, 4, 5, 2, 8, 6, 1, 7, 9},
        };
            int[][] test9_3by3 = TurnTo3by3GridArray(test9);
            Console.WriteLine(ValidateSolution(test9));
            Console.ReadLine();
        }

        public static bool ValidateSolution(int[][] input)
        {
            int[][] flipped9 = FlipThat9Array(input);
            int[][] grid3 = TurnTo3by3GridArray(input);
            bool inputRowsNonRepeat = true;
            bool inputColumnsNonRepeat = true;
            bool inputRowsCorrectRange = true;
            bool inputColumnsCorrectRange = true;
            bool threeByThreeNonRepeat = true;
            bool threeByThreeCorrectRange = true;

            for (int i = 0; i < 9; i++)  ///checks for duplicates in rows and columns
            {
                if (input[i].Length != input[i].Distinct().Count())  //rows
                {
                    inputRowsNonRepeat = false;
                    break;
                }
                if (flipped9[i].Length != flipped9[i].Distinct().Count())  //columns
                {
                    inputColumnsNonRepeat = false;
                    break;
                }
                if (grid3[i].Length != grid3[i].Distinct().Count())  //columns
                {
                    threeByThreeNonRepeat = false;
                    break;
                }
            }

            for (int i = 0; i < 9; i++)  //checks for correct range 1-9 in rows and columns
            {
                if (input[i].Max() != 9)  //checks row max
                {
                    inputRowsCorrectRange = false;
                    break;
                }
                if (input[i].Min() != 1)  //checks row min
                {
                    inputRowsCorrectRange = false;
                    break;
                }
                if (flipped9[i].Max() != 9)  //checks columns max
                {
                    inputColumnsCorrectRange = false;
                    break;
                }
                if (flipped9[i].Min() != 1)  //checks columns min
                {
                    inputColumnsCorrectRange = false;
                    break;
                }

                if (grid3[i].Max() != 9)  //checks 3x3 grid max
                {
                    threeByThreeCorrectRange = false;
                    break;
                }
                if (grid3[i].Min() != 1)  //checks 3x3 grid min
                {
                    threeByThreeCorrectRange = false;
                    break;
                }
            }
            return (inputColumnsNonRepeat && inputRowsNonRepeat && inputColumnsCorrectRange && inputRowsCorrectRange && threeByThreeCorrectRange && threeByThreeNonRepeat);
        }

            public static int[][] FlipThat9Array(int[][] input)
        {
            int[][] flippedArray = new int[9][];
            flippedArray[0] = new int[9];
            flippedArray[1] = new int[9];
            flippedArray[2] = new int[9];
            flippedArray[3] = new int[9];
            flippedArray[4] = new int[9];
            flippedArray[5] = new int[9];
            flippedArray[6] = new int[9];
            flippedArray[7] = new int[9];
            flippedArray[8] = new int[9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    flippedArray[j][i] = input[i][j];
                }
            }
            return flippedArray;
        }

        public static int[][] TurnTo3by3GridArray(int[][] input)
        {
            int[][] Grid3by3Array = new int[9][];
            Grid3by3Array[0] = new int[9];
            Grid3by3Array[1] = new int[9];
            Grid3by3Array[2] = new int[9];
            Grid3by3Array[3] = new int[9];
            Grid3by3Array[4] = new int[9];
            Grid3by3Array[5] = new int[9];
            Grid3by3Array[6] = new int[9];
            Grid3by3Array[7] = new int[9];
            Grid3by3Array[8] = new int[9];

            int m = 0;   //keeps track of input row
            int k = 0;   //keeps track of input place in row

            for (int i = 0; i < 3; i++)   //indexes through output rows
            {
                for (int j = 0; j < 9; j++)   //indexes through place in row of output
                {
                    Grid3by3Array[i][j] = input[m][k];
                    k++;
                    if (k == 3)
                    {
                            k = 0;
                            m++;
                    }
                }
            }
            m = 0;
            k = 3;
            for (int i = 3; i < 6; i++)   //indexes through output rows
            {
                for (int j = 0; j < 9; j++)   //indexes through place in row of output
                {
                    Grid3by3Array[i][j] = input[m][k];
                    k++;
                    if (k == 6)
                    {
                        k = 3;
                        m++;
                    }
                }
            }
            m = 0;
            k = 6;
            for (int i = 6; i < 9; i++)   //indexes through output rows
            {
                for (int j = 0; j < 9; j++)   //indexes through place in row of output
                {
                    Grid3by3Array[i][j] = input[m][k];
                    k++;
                    if (k == 9)
                    {
                        k = 6;
                        m++;
                    }
                }
            }
            return Grid3by3Array;
        }
    }
}
