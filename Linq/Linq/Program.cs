using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            XML();
            Upload();
        }

        static void XML()
        {
            XML xml = new XML();
            xml.readFile();
            xml.findYoungest();
            xml.findSenior();
            xml.findCount();
            xml.sortByAgeId();

        }
        static void Upload()
        {
            UploadHelper upload = new UploadHelper();
            UploadSchedule schedule = new UploadSchedule(upload);
            upload.UploadFile();
        }
    }
    public class Students
    {
        public Students()
        {
        }
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string dob;
        public string DOB
        {
            get { return dob; }
            set { dob = value; }
        }
       
    }
    public class XML
    {
        public List<Students> studentsList = new List<Students>();
        public XML()
        {

        }

        public void readFile()
        {
            XElement xe = XElement.Load(@"C:\Test\Students.xml");
            IEnumerable<XElement> elements = from ele in xe.Elements("Student")
                                             select ele;
            foreach (var ele in elements)
            {
                Students student = new Students();
                student.ID = Convert.ToInt32(ele.Element("Id").Value);
                student.Name = ele.Element("Name").Value;
                student.Age = Convert.ToInt32(ele.Element("Age").Value);
                student.Address = ele.Element("Address").Value;
                student.DOB = ele.Element("DOB").Value;
                studentsList.Add(student);
            }

        }
        public void showInfo(Students stu)
        {
         Console.WriteLine("ID:{0,-4} Name:{1,-10} Age:{2,-4} Address:{3,-13} DOB:{4}",stu.ID,stu.Name,stu.Age,stu.Address,stu.DOB);  
        }

        public void findYoungest()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("The younest student is ：");
            var Yongest = from student in studentsList
                          where  student.Age  ==  studentsList.Min(x=> x.Age)
                          select student;
            foreach(Students stu in Yongest)
            {
                showInfo(stu);
            }
          
        }
        public void findCount()
        {
            Console.WriteLine("-------------------------------");
           
            int count = 0;
            var target = from student in studentsList
                          where student.Age >18 &&student.Age< 20
                          select student;
            foreach (Students stu in target)
            {
                count++;
            }
            Console.WriteLine("count of students whose age is in range of 18-20:" + count);

        }
        public void findSenior()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("The student whose age is above 24 are ：");
            var senior = from student in studentsList
                          where student.Age > 24
                          select student;
            foreach (Students stu in senior)
            {
                Console.WriteLine("Name:" + stu.Name);
            }

        }
        public void sortByAgeId()

        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("students sorted by age then by  Id:");
            var target = from student in studentsList
                          orderby student.Age,student.ID
                          select student;
            foreach (Students stu in target)
            {
                showInfo(stu);
            }

        }
    }
    

    
    public class UploadEventArgs : EventArgs
    {
        public UploadEventArgs(string s)
        {
            message = s;
        }
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }

   
    class UploadHelper
    {
        public event EventHandler<UploadEventArgs> UploadEventProcess;
        public void UploadFile()
        {
            Console.WriteLine("File upload start!");

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(800);
                UploadEventProcess?.Invoke(this, new UploadEventArgs(String.Format("File upload {0}%",20*(i+1))));
            }
            Console.WriteLine("File upload complete!");
        }
    }

    class UploadSchedule
    {
        public UploadSchedule( UploadHelper pub)
        {
            try
            {
                Console.WriteLine("---------------File upload simulation----------------");
              
                Console.WriteLine("If you wanna notification,enter positive number;otherwise,enter nagetive number");
                int input = Convert.ToInt32(Console.ReadLine());

                if (input > 0)
                {
                   pub.UploadEventProcess += HandleUploadEventHandler;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Input invalid,default operation is not showing notification");
            }
           
        }

        void HandleUploadEventHandler(object sender, UploadEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }


}
