using System;

namespace DesignPatterns.Structural
{

    /// <summary>
    /// Декоратор (Decorator) представляет структурный шаблон проектирования,
    /// который позволяет динамически подключать к объекту дополнительную функциональность.
    ///
    /// Когда следует использовать декораторы?
    ///
    /// Когда надо динамически добавлять к объекту новые функциональные возможности.
    /// При этом данные возможности могут быть сняты с объекта
    ///
    /// Когда применение наследования неприемлемо. Например, если нам надо определить
    /// множество различных функциональностей и для каждой функциональности
    /// наследовать отдельный класс, то структура классов может очень сильно разрастись.
    /// Еще больше она может разрастись, если нам необходимо создать классы,
    /// реализующие все возможные сочетания добавляемых функциональностей.
    /// </summary>
    public class Decorator
    {
        public static void Run()
        {
            Console.WriteLine("\r\n\tDecorator\r\n");
            
            Pizza pizza1 = new ItalianPizza();
            pizza1 = new TomatoPizza(pizza1); // итальянская пицца с томатами
            Console.WriteLine("Название: {0}", pizza1.Name);
            Console.WriteLine("Цена: {0}", pizza1.GetCost());
 
            Pizza pizza2 = new ItalianPizza();
            pizza2 = new CheesePizza(pizza2);// итальянская пиццы с сыром
            Console.WriteLine("Название: {0}", pizza2.Name);
            Console.WriteLine("Цена: {0}", pizza2.GetCost());
 
            Pizza pizza3 = new BulgerianPizza();
            pizza3 = new TomatoPizza(pizza3);
            pizza3 = new CheesePizza(pizza3);// болгарская пиццы с томатами и сыром
            Console.WriteLine("Название: {0}", pizza3.Name);
            Console.WriteLine("Цена: {0}", pizza3.GetCost());
 
        }
    }
 
    abstract class Pizza
    {
        public Pizza(string n)
        {
            this.Name = n;
        }
        public string Name {get; protected set;}
        public abstract int GetCost();
    }
 
    class ItalianPizza : Pizza
    {
        public ItalianPizza() : base("Итальянская пицца")
        { }
        public override int GetCost()
        {
            return 10;
        }
    }
    class BulgerianPizza : Pizza
    {
        public BulgerianPizza()
            : base("Болгарская пицца")
        { }
        public override int GetCost()
        {
            return 8;
        }
    }
 
    abstract class PizzaDecorator : Pizza
    {
        protected Pizza pizza;
        public PizzaDecorator(string n, Pizza pizza) : base(n)
        {
            this.pizza = pizza;
        }
    }
 
    class TomatoPizza : PizzaDecorator
    {
        public TomatoPizza(Pizza p) 
            : base(p.Name + ", с томатами", p)
        { }
 
        public override int GetCost()
        {
            return pizza.GetCost() + 3;
        }
    }
 
    class CheesePizza : PizzaDecorator
    {
        public CheesePizza(Pizza p)
            : base(p.Name + ", с сыром", p)
        { }
 
        public override int GetCost()
        {
            return pizza.GetCost() + 5;
        }
    }
}