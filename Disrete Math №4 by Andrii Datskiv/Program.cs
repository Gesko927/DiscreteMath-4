using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Disrete_Math__4_by_Andrii_Datskiv
{
    class Program
    {
        public static int size;
        public static int[,] matrix;
        static void Main(string[] args)
        {
            IntroMenu();

            Console.Write("Result: ");
            Console.WriteLine(AmountOfCounters(matrix, size));
        }

        /**Call menu method
         */ 
        public static void IntroMenu()
        {
            Console.WriteLine("\tMenu:");
            Console.WriteLine("1. Random matrix with N size.");
            Console.WriteLine("2. Matrix from file.");

            string choose = Console.ReadLine();

            switch (choose)
            {
                case "1":
                    {
                        Console.Clear();
                        Console.Write("Please, input size: ");
                        size = Convert.ToInt32(Console.ReadLine());
                        matrix = CreateMatrix(size);
                        PrintMatrix(matrix, size);

                    }
                    break;
                case "2":
                    {
                        Console.Clear();
                        matrix = MatrixFromFile("test.txt");
                        PrintMatrix(matrix, size);

                    }
                    break;

                default:
                    {
                        Console.Clear();
                        IntroMenu();
                    }
                    break;
            }
        }

        /**Unfinished method
         * 
         */ 
        public static int[,] CreateMatrix(int size)
        {
            int[,] a = new int[size,size];

            return a;
        }

        /**Amount of Counters in Graph
         * 
         * 
         */ 
        public static double AmountOfCounters(int[,] a, int n)
        {
            double result = 0.0;
            int[] r = new int[n];
            int sum = 0;

            for(int i = 0; i < n; ++i)
            {
                for(int j = 0; j < n; ++j)
                {
                    r[i] += a[i, j];
                }

                sum += (int)Math.Pow(r[i], 2);
            }

            result = Math.Abs(((n * (n - 1) * (2 * n - 1)) / 12) - (sum / 2));
            return result;
        }

        /**Initialisation from file
         * Init matrix from file
         * <filePath>
         */ 
        public static int[,] MatrixFromFile(string filePath)
        {
            #region Size

            StreamReader beg = new StreamReader(filePath);
            String[] len = (beg.ReadLine()).Split(' ');

            size = len.Length;

            beg.Close();

            #endregion

            StreamReader sr = null;

            int[,] R = new int[size, size];

            try
            {
                sr = new StreamReader(filePath);

                for (int i = 0; i < size; i++)
                {
                    string s = sr.ReadLine();
                    string[] sa = s.Split(' ');

                    for (int j = 0; j < size; j++)
                    {
                        R[i, j] = Convert.ToInt32(sa[j]);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                sr.Close();
            }
           

            return R;
        }

        /**Print matrix
         * Method for printing matrix
         * in console
         */ 
        public static void PrintMatrix(int[,] matrix, int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write("\t| ");
                for (int j = 0; j < size; j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine("|");
            }
        }
    }
}
