using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdwcrzHW
{
    public class Diagonals
    {
        #region Exceptions
        public class NegativeSizeException : Exception { };
        public class ReferenceToNullPartException : Exception { };
        public class DifferentSizeException : Exception { };
        #endregion


        public List<double> vector = new List<double>();

        public Diagonals(int size)
        {
            if (size % 2 == 0)
            {
                if (size <= 0) throw new NegativeSizeException();
                else
                {
                    for (int i = 0; i < size * 2; i++)
                    {
                        vector.Add(0);
                    }

                }
            }
            else
            {
                if (size < 0) throw new NegativeSizeException();
                else
                {
                    for (int i = 0; i < size * 2 - 1; i++)
                    {
                        vector.Add(0);
                    }

                }
            }

        }
        public Diagonals(Diagonals d)
        {
            for (int i = 0; i < d.vector.Count; ++i)
            {
                vector.Add(d.vector[i]);
            }
        }

        public int Size // Property for getting the size of the matrix
        {
            get { return vector.Count; }
        }
        public double this[int i, int j]
        {
            
            get
            {
                
                if (Size % 2 == 0)
                {
                    if (i < 0 || i >= (Size) / 2 || j < 0 | j >= (Size) / 2)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    if (i == j)
                    {
                        return vector[i];
                    }
                    else if (i + j + 1 == Size / 2)
                    {
                        return vector[Size / 2 + i];
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                  
                    if (i < 0 || i >= (Size) / 2 + 1 || j < 0 | j >= (Size) / 2 + 1)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    if (i == j)
                    {
                        return vector[i];
                        
                    }
                    else if (i + j == Size / 2 && i != j)
                    {
                        
                        if (i > j)
                        {
                            return vector[Size / 2 + i];
                        }
                        else if(i < j)
                        {
                            return vector[Size / 2 + 1 + i];
                        }
                    }
                    
                    return 0;
                }

            }
            set
            {
                if (Size % 2 == 0)
                {
                    if (i < 0 || i >= (Size) / 2 || j < 0 | j >= (Size) / 2)
                    {   
                        throw new IndexOutOfRangeException();
                    }
                    if (i == j)
                    {
                        vector[i] = value;
                    }
                    else if (i + j + 1 == Size / 2)
                    {
                        vector[Size / 2 + i] = value;
                    }
                    else
                    {
                        throw new ReferenceToNullPartException();
                    }
                    
                }
                else
                {
                    if (i < 0 || i >= (Size) / 2 + 1 || j < 0 | j >= (Size) / 2 + 1)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    if (i == j)
                    {
                        vector[i] = value;
                    }
                    else if (i + j == Size / 2 && i != j)
                    {

                        if (i > j)
                        {
                            vector[Size / 2 + i] = value ;
                        }
                        else if (i < j)
                        {
                             vector[Size / 2 + 1 + i] = value;
                        }
                    }
                    


                }

            }
        }

        public void Set(in List<double> x)
        {
            if (this.Size != x.Count) throw new DifferentSizeException();
            for (int i = 0; i < Size; i++)
            {
                this.vector[i] = x[i];
            }
        }


        public override bool Equals(Object obj)
        {
            if (obj == null || !(obj is Diagonals))
                return false;
            else
            {
                Diagonals diag = obj as Diagonals;
                if (diag.Size != this.Size) return false;
                for (int i = 0; i < vector.Count; i++)
                {
                    if (vector[i] != diag.vector[i]) return false;
                }
                return true;
            }
        }

        public static Diagonals operator +(Diagonals a, Diagonals b)
        {
            if (a.Size != b.Size) throw new DifferentSizeException();
            Diagonals c = new Diagonals(a);
            for (int i = 0; i < c.Size; ++i)
            {
                c.vector[i] = a.vector[i] + b.vector[i];
            }
            return c;
        }
        public static Diagonals operator *(Diagonals a, Diagonals b)
        {
            
            if (a.Size != b.Size) throw new DifferentSizeException();
            Diagonals c = new Diagonals(a);
            if (a.Size % 2 == 0)
            {
                double res;
                for (int i = 0; i < a.Size / 2; ++i)
                {
                    
                    for (int j = 0; j < a.Size / 2; ++j)
                    {
                        res = 0;
                        for (int k = 0; k < a.Size / 2; ++k)
                        {
                            res += a[i, k] * b[k, j];
                        }
                        c[i, j] = res;
                    }
                    
                   

                    
                }
                return c;
            }
            else
            {


                double res;
                for (int i = 0; i < a.Size / 2 + 1; ++i)
                {
                    
                    for (int j = 0; j < a.Size / 2 + 1; ++j)
                    {
                        res = 0;
                        for (int k = 0; k < a.Size / 2 + 1; ++k)
                        {
                            res += a[i, k] * b[k, j];

                        }
                        c[i, j] = res;

                    }
                    
                }
                
                return c;
            }


            
        }

        public void Print()
        {

            if (Size % 2 == 0)
            {
                for (int i = 0; i < Size / 2; i++)
                {
                    for (int j = 0; j < Size / 2; j++)
                    {
                        Console.Write($"{this[i, j]} ");


                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = 0; i < Size / 2 + 1; i++)
                {
                    for (int j = 0; j < Size / 2 + 1; j++)
                    {
                        Console.Write($"{this[i, j]} ");

                    }
                    Console.WriteLine();
                }
            }

        }
    }
}
