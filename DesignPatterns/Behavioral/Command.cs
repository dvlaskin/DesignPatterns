using System;

namespace DesignPatterns.Behavioral
{

    /// <summary>
    /// Паттерн "Команда" (Command) позволяет инкапсулировать запрос
    /// на выполнение определенного действия в виде отдельного объекта.
    /// Этот объект запроса на действие и называется командой.
    /// При этом объекты, инициирующие запросы на выполнение действия,
    /// отделяются от объектов, которые выполняют это действие.
    ///
    /// Когда использовать команды?
    ///
    /// Когда надо передавать в качестве параметров определенные действия,
    /// вызываемые в ответ на другие действия. То есть когда необходимы функции
    /// обратного действия в ответ на определенные действия.
    ///
    /// Когда необходимо обеспечить выполнение очереди запросов, а также их возможную отмену.
    ///
    /// Когда надо поддерживать логгирование изменений в результате запросов.
    /// Использование логов может помочь восстановить состояние системы
    /// - для этого необходимо будет использовать последовательность запротоколированных команд.
    /// </summary>
    public class Command
    {
        public static void Run()
        {
            Console.WriteLine("\r\n\tCommand\r\n");
            
            Pult pult = new Pult();
            TV tv = new TV();
            pult.SetCommand(new TVOnCommand(tv));
            pult.PressButton();
            pult.PressUndo();
         
        }
    }
 
    interface ICommand
    {
        void Execute();
        void Undo();
    }
 
    // Receiver - Получатель
    class TV
    { 
        public void On()
        {
            Console.WriteLine("Телевизор включен!");
        }
 
        public void Off()
        {
            Console.WriteLine("Телевизор выключен...");
        }
    }
 
    class TVOnCommand : ICommand
    {
        TV tv;
        public TVOnCommand(TV tvSet)
        {
            tv = tvSet;
        }
        public void Execute()
        {
            tv.On();
        }
        public void Undo()
        {
            tv.Off();
        }
    }
 
    // Invoker - инициатор
    class Pult
    {
        ICommand command;
 
        public Pult() { }
 
        public void SetCommand(ICommand com)
        {
            command = com;
        }
 
        public void PressButton()
        {
            command.Execute();
        }
        public void PressUndo()
        {
            command.Undo();
        }
    }
}