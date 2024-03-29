﻿using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral
{
    
    /// <summary>
    /// Паттерн Посетитель (Visitor) позволяет определить операцию
    /// для объектов других классов без изменения этих классов.
    /// 
    /// При использовании паттерна Посетитель определяются две иерархии классов:
    /// одна для элементов, для которых надо определить новую операцию,
    /// и вторая иерархия для посетителей, описывающих данную операцию.
    ///
    /// Когда использовать данный паттерн?
    ///
    /// Когда имеется много объектов разнородных классов с разными интерфейсами,
    /// и требуется выполнить ряд операций над каждым из этих объектов
    ///
    /// Когда классам необходимо добавить одинаковый набор операций без изменения этих классов
    ///
    /// Когда часто добавляются новые операции к классам,
    /// при этом общая структура классов стабильна и практически не изменяется
    /// </summary>
    public class Visitor
    {
        public static void Run()
        {
            Console.WriteLine("\r\n\tVisitor\r\n");
            
            var structure = new TheBank();
            structure.Add(new Person {Name = "Иван Алексеев", Number = "82184931"});
            structure.Add(new Company {Name = "Microsoft", RegNumber = "ewuir32141324", Number = "3424131445"});
            structure.Accept(new HtmlVisitor());
            structure.Accept(new XmlVisitor());
        }
    }

    /// <summary>
    /// Интерфейс посетителя, который определяет метод Visit() для каждого объекта Element
    /// </summary>
    interface IVisitor
    {
        void VisitPersonAcc(Person acc);
        void VisitCompanyAc(Company acc);
    }

    /// <summary>
    /// сериализатор в HTML
    /// </summary>
    class HtmlVisitor : IVisitor
    {
        public void VisitPersonAcc(Person acc)
        {
            string result = "<table><tr><td>Свойство<td><td>Значение</td></tr>";
            result += "<tr><td>Name<td><td>" + acc.Name + "</td></tr>";
            result += "<tr><td>Number<td><td>" + acc.Number + "</td></tr></table>";
            Console.WriteLine(result);
        }

        public void VisitCompanyAc(Company acc)
        {
            string result = "<table><tr><td>Свойство<td><td>Значение</td></tr>";
            result += "<tr><td>Name<td><td>" + acc.Name + "</td></tr>";
            result += "<tr><td>RegNumber<td><td>" + acc.RegNumber + "</td></tr>";
            result += "<tr><td>Number<td><td>" + acc.Number + "</td></tr></table>";
            Console.WriteLine(result);
        }
    }

    /// <summary>
    /// сериализатор в XML
    /// </summary>
    class XmlVisitor : IVisitor
    {
        public void VisitPersonAcc(Person acc)
        {
            string result = "<Person><Name>" + acc.Name + "</Name>" + "<Number>" + acc.Number + "</Number><Person>";
            Console.WriteLine(result);
        }

        public void VisitCompanyAc(Company acc)
        {
            string result = "<Company><Name>" + acc.Name + "</Name>" + "<RegNumber>" + acc.RegNumber + "</RegNumber>" +
                            "<Number>" + acc.Number + "</Number><Company>";
            Console.WriteLine(result);
        }
    }

    class TheBank
    {
        List<IAccount> accounts = new List<IAccount>();

        public void Add(IAccount acc)
        {
            accounts.Add(acc);
        }

        public void Remove(IAccount acc)
        {
            accounts.Remove(acc);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (IAccount acc in accounts) acc.Accept(visitor);
        }
    }

    interface IAccount
    {
        void Accept(IVisitor visitor);
    }

    class Person : IAccount
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitPersonAcc(this);
        }
    }

    class Company : IAccount
    {
        public string Name { get; set; }
        public string RegNumber { get; set; }
        public string Number { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitCompanyAc(this);
        }
    }
}