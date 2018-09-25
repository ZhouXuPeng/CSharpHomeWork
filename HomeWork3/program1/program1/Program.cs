using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    //创建接口
    interface Sharp
    {
        double Area();
    }
    //创建产品类
    //三角形
    class Triangle : Sharp
    {
        double a, area;
        //构造函数
        public Triangle(double a)
        {
            this.a = a;
        }
        //面积
        public double Area()
        {
            area = 0.5 * a * a * Math.Sin(Math.PI * 60 / 180);
            Console.WriteLine("三角形的面积为：" + area);
            return area;
        }
    }
    //圆形
    class Circular : Sharp
    {
        double a, area;
        //构造函数
        public Circular(double a)
        {
            this.a = a;
        }
        //面积
        public double Area()
        {
            area = Math.PI * a * a;
            Console.WriteLine("圆形的面积为：" + area);
            return area;  
        }
    }
    //正方形
    class Square : Sharp
    {
        double a, area;
        //构造函数
        public Square(double a)
        {
            this.a = a;
        }
        //面积
        public double Area()
        {
            area = a * a;
            Console.WriteLine("正方形的面积为：" + area);
            return area;
           
        }
    }
    //长方形
    class Rectangle : Sharp
    {
        double a, b, area;
        //构造函数
        public Rectangle(double a,double b)
        {
            this.a = a;
            this.b = b;
        }
        //面积
        public double Area()
        {
            area = a * b;
            Console.WriteLine("长方形的面积为：" + area);
            return area;
            
        }
    }

    //创建工厂类
    class SharpFactory
    {
        //静态工厂方法
        public static Sharp GetSharp(String type,double a, double b)
        {
            Sharp sharp = null;
            if (type.Equals("三角形"))
            {
                sharp = new Triangle(a);
            }
            else if (type.Equals("圆形"))
            {
                sharp = new Circular(a);
            }
            else if (type.Equals("正方形"))
            {
                sharp = new Square(a);
            }
            else if (type.Equals("长方形"))
            {
                sharp = new Rectangle(a, b);
            }
            return sharp;
        }  
    }





    class Program
    {
        static void Main(string[] args)
        {
            Sharp sharp;
            sharp = SharpFactory.GetSharp("长方形",2.0,3.0);
            sharp.Area();
        }
    }
}
