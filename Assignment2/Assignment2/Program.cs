using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        private static object convert;

        static void Main(string[] args)
        {
            Assignment2();
        }
        public static void Assignment2()
        {
            double[,] testa = new double[2, 2] ;
            Console.WriteLine("please enter 4 numbers for array A");
            for(int i=0;i<2; i++)
            {
                for(int j = 0; j < 2; j++)
                {
                    testa[i,j] = Convert.ToDouble(Console.ReadLine());
                }
            }
            Matrix m_testa = new Matrix(testa);
            double[,] testb = new double[2, 2];
            Console.WriteLine("please enter 4 numbers for array B");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    testb[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }
            Matrix m_testb = new Matrix(testb);
            Console.WriteLine("matrix a is ");
            m_testa.Show();
            Console.WriteLine("matrix b is ");
            m_testb.Show();
            Matrix temp = new Matrix();
            temp = m_testa + m_testb;
            Console.WriteLine("matrix a add matrix b is ");
            temp.Show();
            temp = m_testa - m_testb;
            Console.WriteLine("matrix a sub matrix b is ");
            temp.Show();

        }
        class Matrix
        {
            private double[,] data = new double[2, 2];
            public Matrix()
            {
                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 2; j++)
                        this.data[i, j] = 0;
            }
            public Matrix(double[,] array)
            {
                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 2; j++)
                        this.data[i, j] = array[i, j];
            }
            public static Matrix operator +(Matrix a, Matrix b)
            {
                Matrix c = new Matrix();
                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 2; j++)
                        c.data[i, j] = a.data[i, j] + b.data[i, j];
                return c;
            }
            public static Matrix operator -(Matrix a, Matrix b)
            {
                Matrix c = new Matrix();
                for (int i = 0; i < 2; i++)
                    for (int j = 0; j < 2; j++)
                        c.data[i, j] = a.data[i, j] - b.data[i, j];
                return c;
            }
            public void Show()
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < 2; j++)
                        Console.Write(this.data[i, j] + " ");
                }
                Console.WriteLine();
            }


        }
    }
}