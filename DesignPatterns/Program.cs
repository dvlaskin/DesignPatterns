using System;
using DesignPatterns.Behavioral;
using DesignPatterns.Creational;

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
            
            
            Console.WriteLine("\r\nFinish");
        }
    }
}