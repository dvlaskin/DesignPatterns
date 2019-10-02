using System;

namespace DesignPatterns.Behavioral
{
    /// <summary>
    /// Шаблонный метод (Template Method) определяет общий алгоритм поведения подклассов,
    /// позволяя им переопределить отдельные шаги этого алгоритма без изменения его структуры.
    ///
    /// Когда использовать шаблонный метод?
    ///
    /// Когда планируется, что в будущем подклассы должны будут переопределять
    /// различные этапы алгоритма без изменения его структуры
    ///
    /// Когда в классах, реализующим схожий алгоритм, происходит дублирование кода.
    /// Вынесение общего кода в шаблонный метод уменьшит его дублирование в подклассах.
    /// </summary>
    public class TemplateMethod
    {
        public static void Run()
        {
            Console.WriteLine("\r\n\tTemplateMethod\r\n");
            
            School school = new School();
            University university = new University();
 
            school.Learn();
            Console.WriteLine("");
            university.Learn();
 
        }
    }
    
    abstract class Education
    {
        public void Learn()
        {
            Enter();
            Study();
            PassExams();
            GetDocument();
        }
        public abstract void Enter();
        public abstract void Study();
        public virtual void PassExams()
        {
            Console.WriteLine("Сдаем выпускные экзамены");
        }
        public abstract void GetDocument();
    }
     
    class School : Education
    {
        public override void Enter()
        {
            Console.WriteLine("Идем в первый класс");
        }
 
        public override void Study()
        {
            Console.WriteLine("Посещаем уроки, делаем домашние задания");
        }
 
        public override void GetDocument()
        {
            Console.WriteLine("Получаем аттестат о среднем образовании");
        }
    }
 
    class University : Education
    {
        public override void Enter()
        {
            Console.WriteLine("Сдаем вступительные экзамены и поступаем в ВУЗ");
        }
 
        public override void Study()
        {
            Console.WriteLine("Посещаем лекции");
            Console.WriteLine("Проходим практику");
        }
 
        public override void PassExams()
        {
            Console.WriteLine("Сдаем экзамен по специальности");
        }
 
        public override void GetDocument()
        {
            Console.WriteLine("Получаем диплом о высшем образовании");
        }
    }
}