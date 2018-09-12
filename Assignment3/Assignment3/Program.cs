using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
   
        class StudentCollection
        {
            private string[] name = new string[10];
            private int[] age = new int[10];

            public StudentCollection()
            {
                for (int i = 0; i < 10; i++)
                {
                    name[i] = "null";
                }
                for (int i = 0; i < 10; i++)
                {
                    age[i] = 0;
                }
            }
            public string this[int index]
            {
                get
                {
                    string tem = "";
                    if (index >= 0 && index <= 9)
                    {
                        tem = string.Format("Name:{0},Age:{1}", name[index], age[index]);
                    }

                    return tem;
                }
                set
                {
                    if (index >= 0 && index <= 9)
                    {
                        string[] Array = value.Split(',');
                        name[index] = Array[0];
                        age[index] = int.Parse(Array[1]);
                    }
                }
            }


        }
        class MyProgram
        {
            static void Main(string[] args)
            {
                Assignment3();
            }
            static void Assignment3()
            {
                StudentCollection student = new StudentCollection();
                student[0] = "li,21";
                student[1] = "wu,30";
                student[2] = "cheng,22";
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(student[i]);
                }
            }
        }
    }

