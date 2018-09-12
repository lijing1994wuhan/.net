using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Delegate
{
    public class Heater
    {
        private int temperature;
        public string type = "RealFire 001";        // 添加型号作为演示
        public string area = "China Xian";          // 添加产地作为演示



        public class BoliedEventArgs : EventArgs    /*定义事件参数类*/
        {
            public readonly int temperature;
            public BoliedEventArgs(int temperature)
            {
                this.temperature = temperature;
            }
        }

        public delegate void BoiledEventHandler(Object sender, BoliedEventArgs e);  //声明委托
        public event BoiledEventHandler Boiled; //声明事件

        protected virtual void OnBolied(BoliedEventArgs e)
        {
            if (Boiled != null)
            {  //如果有对象注册
                Boiled(this, e);        //调用所有注册对象的方法
            }
        }

        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;
                if (temperature > 95)
                {
                    BoliedEventArgs e = new BoliedEventArgs(temperature);
                    OnBolied(e);  //触发事件。
                                  //被触发的事件一般是On开头，后面加事件名称。
                }
            }
        }
    }

    public class Alarm
    {
        public void MakeAlert(Object sender, Heater.BoliedEventArgs e)
        {
            Heater heater = (Heater)sender;
            Console.WriteLine("Alarm：{0} - {1}: ", heater.area, heater.type);
            Console.WriteLine("Alarm: 嘀嘀嘀，水已经 {0} 度了：\n", e.temperature);
        }
    }

    public class Display
    {
        public static void ShowMsg(Object sender, Heater.BoliedEventArgs e)
        {   //静态方法
            Heater heater = (Heater)sender;
            Console.WriteLine("Display：{0} - {1}: ", heater.area, heater.type);
            Console.WriteLine("Display：水快烧开了，当前温度：{0}度。\n", e.temperature);
        }
    }

    class Program
    {
        static void Main()
        {
            Heater heater = new Heater();
            Alarm alarm = new Alarm();

            heater.Boiled += alarm.MakeAlert;           //注册方法
            heater.Boiled += (new Alarm()).MakeAlert;     //给匿名对象注册方法
            heater.Boiled += new Heater.BoiledEventHandler(alarm.MakeAlert);  //也可以这么注册
            heater.Boiled += Display.ShowMsg;             //注册静态方法

            heater.BoilWater();
        }
    }
}