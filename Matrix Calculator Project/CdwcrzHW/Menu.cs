using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdwcrzHW
{
    public class Menu
    {
        private List<Diagonals> vec = new List<Diagonals>();

        public Menu() { }

        public void Run()
        {
            int n;
            do
            {
                PrintMenu();
                try
                {
                    n = int.Parse(Console.ReadLine()); // there was !
                }
                catch (System.FormatException)
                {
                    n = -1;
                    Console.WriteLine("Enter a digit between 1 and 6.");
                }
                switch (n)
                {
                    case 1:
                        GetElement();
                        break;
                    case 2:
                        PrintMatrix();
                        break;
                    case 3:
                        AddMatrix();
                        break;
                    case 4:
                        Sum();
                        break;
                    case 5:
                        Mul();
                        break;
                }

            } while (n != 0);

        }

        #region Menu operations

        static private void PrintMenu()
        {
            Console.WriteLine("\n\n 0. - Quit");
            Console.WriteLine(" 1. - Get an element");
            Console.WriteLine(" 2. - Print a matrix");
            Console.WriteLine(" 3. - Set a matrix");
            Console.WriteLine(" 4. - Add matrices");
            Console.WriteLine(" 5. - Multiply matrices");
            Console.Write(" Choose: ");
        }

        private int GetIndex()
        {
            if (vec.Count == 0) return -1;
            int n = 0;
            bool ok;
            
            do
            {
                Console.Write("Give a matrix index: ");
                ok = false;
                try
                {
                    n = int.Parse(Console.ReadLine()); // there was a !
                    ok = true;
                    if (n <= 0 || n > vec.Count)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Integer is expected!");
                }

                catch(ArgumentOutOfRangeException)
                {
                    ok = false;
                    Console.WriteLine("No such matrix!");
                }
            } while (!ok);
            return n - 1;
        }

        private void GetElement()
        {
            if (vec.Count == 0)
            {
                Console.WriteLine("Set a matrix first!");
                return;
            }
            int ind = GetIndex();
            do
            {
                try
                {
                    Console.WriteLine("Give the index of the row: ");
                    int i = int.Parse(Console.ReadLine());  // there was !
                    Console.WriteLine("Give the index of the column: ");
                    int j = int.Parse(Console.ReadLine());  // there was !
                    Console.WriteLine($"a[{i},{j}]={vec[ind][i - 1, j - 1]}");
                    break;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine($"Index must be between 1 and {vec[ind].Size / 2}");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine($"Index must be between 1 and {vec[ind].Size / 2}");
                }
            } while (true);
        }


        private void PrintMatrix()
        {
            if (vec.Count == 0)
            {
                Console.WriteLine("Set a matrix first!");
                return;
            }
            int ind = GetIndex();
            vec[ind].Print();
        }
        private void AddMatrix()
        {
            int ind = vec.Count;
            int n = -1;
            bool ok = false;

            do
            {
                Console.Write("Give size:");

                try
                {
                    n = int.Parse(Console.ReadLine());
                    ok = n > 0;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("The size must be greater than 0.");
                }
            } while (!ok);


            Diagonals d = new Diagonals(n);
            ok = true;
            List<double> elements = new List<double>();
            if (n % 2 == 0)
            {
                for (int i = 0; i < n * 2; i++)
                {
                    Console.Write("Element: ");
                    try
                    {
                        double elem = double.Parse(Console.ReadLine()); // ! expected
                        elements.Add(elem);
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Number is expected!");
                        ok = false;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < n * 2 - 1; i++)
                {
                    Console.Write("Element: ");
                    try
                    {
                        double elem = double.Parse(Console.ReadLine()); // ! expected
                        elements.Add(elem);
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Number is expected!");
                        ok = false;
                        break;
                    }
                }
            }


            if (ok)
            {
                d.Set(elements);
                vec.Add(d);
            }
        }


        private void Sum()
        {

            if (vec.Count == 0)
            {
                Console.WriteLine("Set a matrix first!");
                return;
            }

            Console.WriteLine("Please give the 1st matrix");
            int ind1 = GetIndex();
            Console.WriteLine("Please give the 2nd matrix");
            int ind2 = GetIndex();

            try
            {
                (vec[ind1] + vec[ind2]).Print();
            }
            catch (Diagonals.DifferentSizeException)
            {
                Console.WriteLine("Matrices must be the same size");
            }
        }
        private void Mul()
        {
            if (vec.Count == 0)
            {
                Console.WriteLine("Set a matrix first!");
                return;
            }

            Console.WriteLine("Please give the 1st matrix");
            int ind1 = GetIndex();
            Console.WriteLine("Please give the 2nd matrix");
            int ind2 = GetIndex();

            try
            {
                (vec[ind1] * vec[ind2]).Print();

            }
            catch (Diagonals.DifferentSizeException)
            {
                Console.WriteLine("Matrices must be the same size");
            }
        }
        #endregion
    }
}
