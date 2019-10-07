using System;

namespace DesignPatterns.Structural
{

    /// <summary>
    /// Мост (Bridge) - структурный шаблон проектирования, который позволяет
    /// отделить абстракцию от реализации таким образом, чтобы и абстракцию,
    /// и реализацию можно было изменять независимо друг от друга.
    ///
    /// Когда использовать данный паттерн?
    ///
    /// Когда надо избежать постоянной привязки абстракции к реализации
    ///
    /// Когда наряду с реализацией надо изменять и абстракцию независимо друг от друга.
    /// То есть изменения в абстракции не должно привести к изменениям в реализации
    /// </summary>
    public class Bridge
    {
        public static void Run()
        {
            Console.WriteLine("\r\n\tBridge\r\n");
            
            // создаем нового программиста, он работает с с++
            ProgrammerSample freelancer = new FreelanceProgrammer(new CPPLanguage());
            freelancer.DoWork();
            freelancer.EarnMoney();
            // пришел новый заказ, но теперь нужен c#
            freelancer.Language = new CSharpLanguage();
            freelancer.DoWork();
            freelancer.EarnMoney();
 
        }
    }
 
    interface ILanguage
    {
        void Build();
        void Execute();
    }
 
    class CPPLanguage : ILanguage
    {
        public void Build()
        {
            Console.WriteLine("С помощью компилятора C++ компилируем программу в бинарный код");
        }
 
        public void Execute()
        {
            Console.WriteLine("Запускаем исполняемый файл программы");
        }
    }
 
    class CSharpLanguage : ILanguage
    {
        public void Build()
        {
            Console.WriteLine("С помощью компилятора Roslyn компилируем исходный код в файл exe");
        }
 
        public void Execute()
        {
            Console.WriteLine("JIT компилирует программу бинарный код");
            Console.WriteLine("CLR выполняет скомпилированный бинарный код");
        }
    }
 
    abstract class ProgrammerSample
    {
        protected ILanguage language;
        public ILanguage Language
        {
            set { language = value; }
        }
        public ProgrammerSample (ILanguage lang)
        {
            language = lang;
        }
        public virtual void DoWork()
        {
            language.Build();
            language.Execute();
        }
        public abstract void EarnMoney();
    }
 
    class FreelanceProgrammer : ProgrammerSample
    {
        public FreelanceProgrammer(ILanguage lang) : base(lang)
        {
        }
        public override void EarnMoney()
        {
            Console.WriteLine("Получаем оплату за выполненный заказ");
        }
    }
    class CorporateProgrammer : ProgrammerSample
    {
        public CorporateProgrammer(ILanguage lang)
            : base(lang)
        {
        }
        public override void EarnMoney()
        {
            Console.WriteLine("Получаем в конце месяца зарплату");
        }
    }
}