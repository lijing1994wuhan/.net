using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            problem1();
            problem2();
            problem3();

        }
        //  assignment1-problem 1 
        public static int sumOdd(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i += 2)
            {
                sum += i;
            }
            return sum;
        }
        public static int sumEven(int n)
        {
            int sum = 0;
            for (int i = 0; i <= n; i += 2)
            {
                sum += i;
            }
            return sum;
        }
        public static void problem1()
        {
            Console.WriteLine("problem 1  author: jing li");
            Console.WriteLine("when n is 5, the sum of first n even integers is ");
            Console.WriteLine(sumEven(5));
            Console.WriteLine("when n is 5, the sum of first n odd  integers  is ");
            Console.WriteLine(sumOdd(5));
        }
        public static void problem2()
        {
            Console.WriteLine();
            Console.WriteLine("problem 2 ");
            Console.WriteLine("when we creat engine, it will show  ");
            engine e = new engine(1, 2, 3, 4);

        }
        public static void problem3()
        {
            Console.WriteLine();
            Console.WriteLine("problem 3 ");
            stringhelper s1 = new stringhelper();
            stringhelper s2 = new stringhelper();
            s1.addstring();
            s2.deletestring();
            Console.WriteLine("the numbers of operations user performs is " + stringhelper.Counter);

        }
    }
    //  assignment1-problem2 
    class vehicle
    {
        private double weight;
        private double speed;

        public vehicle(double w, double s)
        {
            weight = w;
            speed = s;
            Console.WriteLine("this is vehicle!");
        }
        public double getSpeed()
        {
            return speed;
        }
        public double getWeight()
        {
            return weight;
        }
        public void Run()
        {
            Console.WriteLine("the vehicle start!");
        }
        public void Stop()
        {
            Console.WriteLine("the vehicle stop!");
        }
    }
    class car : vehicle
    {
        private double price;
        public car(double w, double s, double p) : base(w, s)
        {
            price = p;
            Console.WriteLine("this is car! belongs to vehicle!");
        }
    }
    class engine : car
    {
        private double e_speed;
        public engine(double w, double s, double p, double e) : base(w, s, p)
        {
            e_speed = e;
            Console.WriteLine("this is engine! belongs to car!");
        }
    }
    //  assignment1-problem 3
    class stringhelper
    {
        public static int Counter;
        public stringhelper()
        {
            Counter++;
        }
        public void addstring()
        {
            Counter++;
        }
        public void deletestring()
        {
            Counter++;
        }
    }
}
