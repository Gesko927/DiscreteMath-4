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
        public static int[,] graph;
        public static Random random;
        static void Main(string[] args)
        {
            IntroMenu();

            Console.Write("Result: ");
            Console.WriteLine(AmountOfCounters(graph, size));
        }

        /**Call menu method
         */ 
        public static void IntroMenu()
        {
            Console.WriteLine("\tMenu:");
            Console.WriteLine("1. Random graph with N size.");
            Console.WriteLine("2. graph from file.");

            string choose = Console.ReadLine();

            switch (choose)
            {
                case "1":
                    {
                        Console.Clear();
                        Console.Write("Please, input size: ");
                        size = Convert.ToInt32(Console.ReadLine());
                        graph = CreateGraph(size);
                        Printgraph(graph, size);

                    }
                    break;
                case "2":
                    {
                        Console.Clear();
                        graph = graphFromFile("test.txt");
                        Printgraph(graph, size);

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
        public static int[,] CreateGraph(int size)
        {
            random = new Random();
            int[,] a = new int[size,size];

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    a[i, j] = random.Next(0, 10);
                }
            }

            for (int i = 0; i < size; ++i)
            {
                for(int j = 0; j <  size; ++j)
                {
                    if(i == j)
                    {
                        a[i, j] = 0;
                    }

                    a[i, j] = -a[j, i];
                    a[j, i] += a[i, j];
                }
            }

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
         * Init graph from file
         * <filePath>
         */ 
        public static int[,] graphFromFile(string filePath)
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

        /**Print graph
         * Method for printing graph
         * in console
         */ 
        public static void Printgraph(int[,] graph, int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write("\t| ");
                for (int j = 0; j < size; j++)
                {
                    Console.Write("{0} ", graph[i, j]);
                }
                Console.WriteLine("|");
            }
        }
    }
}
