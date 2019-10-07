using System;

namespace DesignPatterns.Structural
{

    /// <summary>
    /// Паттерн Адаптер (Adapter) предназначен для преобразования интерфейса
    /// одного класса в интерфейс другого. Благодаря реализации данного паттерна
    /// мы можем использовать вместе классы с несовместимыми интерфейсами.
    ///
    /// Когда надо использовать Адаптер?
    ///
    /// Когда необходимо использовать имеющийся класс, но его интерфейс не соответствует потребностям
    ///
    /// Когда надо использовать уже существующий класс совместно с другими классами,
    /// интерфейсы которых не совместимы
    /// </summary>
    public class Adapter
    {
        public static void Run()
        {
            Console.WriteLine("\r\n\tAdapter\r\n");
            
            // путешественник
            Driver driver = new Driver();
            // машина
            Auto auto = new Auto();
            // отправляемся в путешествие
            driver.Travel(auto);
            // встретились пески, надо использовать верблюда
            Camel camel = new Camel();
            // используем адаптер
            ITransport camelTransport = new CamelToTransportAdapter(camel);
            // продолжаем путь по пескам пустыни
            driver.Travel(camelTransport);
 
        }
    }
    
    interface ITransport
    {
        void Drive();
    }
    
    // класс машины
    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Машина едет по дороге");
        }
    }
    
    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }
    
    // интерфейс животного
    interface IAnimal
    {
        void Move();
    }
    
    // класс верблюда
    class Camel : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Верблюд идет по пескам пустыни");
        }
    }
    
    // Адаптер от Camel к ITransport
    class CamelToTransportAdapter : ITransport
    {
        Camel camel;
        public CamelToTransportAdapter(Camel c)
        {
            camel = c;
        }
 
        public void Drive()
        {
            camel.Move();
        }
    }
}