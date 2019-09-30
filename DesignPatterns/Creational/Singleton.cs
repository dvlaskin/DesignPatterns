using System;

namespace DesignPatterns.Creational
{
    /// <summary>
    /// Одиночка (Singleton, Синглтон) - порождающий паттерн, который гарантирует,
    /// что для определенного класса будет создан только один объект,
    /// а также предоставит к этому объекту точку доступа.
    ///
    /// Когда надо использовать Синглтон?
    ///
    /// Когда необходимо, чтобы для класса существовал только один экземпляр
    /// </summary>
    public class Singleton
    {
        public static void Run()
        {
            Console.WriteLine("\r\n\tSingleton\r\n");
            
            var obj1 = SingletonTypical.getInstance();
            Console.WriteLine($"obj1 id = {obj1.Name}");
            
            var obj2 = SingletonTypical.getInstance();
            Console.WriteLine($"obj2 id = {obj2.Name}");
            
            var obj3 = SingletonLazy.GetInstance();
            Console.WriteLine($"obj3 id = {obj3.Name}");
            
            var obj4 = SingletonLazy.GetInstance();
            Console.WriteLine($"obj4 id = {obj4.Name}");
        }
    }
    
    public class SingletonTypical
    {
        private static SingletonTypical instance;
        
        public string Name { get; private set; }

        private SingletonTypical()
        {
            Name = System.Guid.NewGuid().ToString();
        }
 
        public static SingletonTypical getInstance()
        {
            if (instance == null)
                instance = new SingletonTypical();
            return instance;
        }
    }
    
    public class SingletonLazy
    {
        private static readonly Lazy<SingletonLazy> lazy = 
            new Lazy<SingletonLazy>(() => new SingletonLazy());
 
        public string Name { get; private set; }
         
        private SingletonLazy()
        {
            Name = System.Guid.NewGuid().ToString();
        }
     
        public static SingletonLazy GetInstance()
        {
            return lazy.Value;
        }
    }
}