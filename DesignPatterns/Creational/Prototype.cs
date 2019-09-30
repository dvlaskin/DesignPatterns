using System;

namespace DesignPatterns.Creational
{
    
    /// <summary>
    /// Паттерн Прототип (Prototype) позволяет создавать объекты
    /// на основе уже ранее созданных объектов-прототипов.
    /// То есть по сути данный паттерн предлагает технику клонирования объектов.
    ///
    /// Когда использовать Прототип?
    ///
    /// Когда конкретный тип создаваемого объекта должен определяться динамически во время выполнения
    ///
    /// Когда нежелательно создание отдельной иерархии классов фабрик для создания объектов-продуктов
    /// из параллельной иерархии классов (как это делается, например,
    /// при использовании паттерна Абстрактная фабрика)
    ///
    /// Когда клонирование объекта является более предпочтительным вариантом
    /// нежели его создание и инициализация с помощью конструктора.
    /// Особенно когда известно, что объект может принимать небольшое
    /// ограниченное число возможных состояний.
    /// </summary>
    public class Prototype
    {
        public static void Run()
        {
            Console.WriteLine("\r\n\tPrototype\r\n");
            
            IFigure figure = new Rectangle(30,40);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();
 
            figure = new Circle(30);
            clonedFigure=figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();
        }
    }
 
    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }
 
    class Rectangle: IFigure
    {
        int width;
        int height;
        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
        }
 
        public IFigure Clone()
        {
            return new Rectangle(this.width, this.height);
        }
        
        public void GetInfo()
        {
            Console.WriteLine("Прямоугольник длиной {0} и шириной {1}", height, width);
        }
    }
 
    class Circle : IFigure
    {
        int radius;
        public Circle(int r)
        {
            radius = r;
        }
 
        public IFigure Clone()
        {
            return new Circle(this.radius);
        }
        public void GetInfo()
        {
            Console.WriteLine("Круг радиусом {0}", radius);
        }
    }
}