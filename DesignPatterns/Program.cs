using System;
using DesignPatterns.Behavioral;
using DesignPatterns.Creational;
using DesignPatterns.Structural;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            
            // Creational Patterns
            FactoryMethod.Run();
            AbstractFactory.Run();
            Prototype.Run();
            Builder.Run();
            Singleton.Run();
            
            // Behavioral Patterns
            Strategy.Run();
            Observer.Run();
            Command.Run();
            TemplateMethod.Run();
            Iterator.Run();
            State.Run();
            //ChainOfResponsibility.Run();
            //Interpreter.Run();
            MediatorExample.Run();
            Memento.Run();
            Visitor.Run();
            
            // Structural
            Decorator.Run();
            Adapter.Run();
            Facade.Run();
            Composite.Run();
            Bridge.Run();
            Flyweight.Run();
            
            Console.WriteLine("\r\nFinish");
        }
    }
}