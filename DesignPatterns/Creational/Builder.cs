﻿using System;
using System.Text;

namespace DesignPatterns.Creational
{
    
    /// <summary>
    /// Строитель (Builder) - шаблон проектирования, который инкапсулирует
    /// создание объекта и позволяет разделить его на различные этапы.
    ///
    /// Когда использовать паттерн Строитель?
    ///
    /// Когда процесс создания нового объекта не должен зависеть от того,
    /// из каких частей этот объект состоит и как эти части связаны между собой
    ///
    /// Когда необходимо обеспечить получение различных вариаций объекта в процессе его создания
    /// </summary>
    public class Builder
    {
        public static void Run()
        {
            Console.WriteLine("\r\n\tBuilder\r\n");
            
            // содаем объект пекаря
            Baker baker = new Baker();
            // создаем билдер для ржаного хлеба
            BreadBuilder builder = new RyeBreadBuilder();
            // выпекаем
            Bread ryeBread = baker.Bake(builder);
            Console.WriteLine(ryeBread.ToString());
            // оздаем билдер для пшеничного хлеба
            builder = new WheatBreadBuilder();
            Bread wheatBread = baker.Bake(builder);
            Console.WriteLine(wheatBread.ToString());
 
        }
    }
    
    //мука
    class Flour
    {
        // какого сорта мука
        public string Sort { get; set; }
    }
    // соль
    class Salt
    {}
    // пищевые добавки
    class Additives
    {
        public string Name { get; set; }
    }
 
    class Bread
    {
        // мука
        public Flour Flour { get; set; }
        // соль
        public Salt Salt { get; set; }
        // пищевые добавки
        public Additives Additives { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
 
            if (Flour != null)
                sb.Append(Flour.Sort + "\n");
            if (Salt != null)
                sb.Append("Соль \n");
            if (Additives != null)
                sb.Append("Добавки: "+Additives.Name+" \n");
            return sb.ToString();
        }
    }
    
    // абстрактный класс строителя
    abstract class BreadBuilder
    {
        public Bread Bread { get; private set; }
        public void CreateBread()
        {
            Bread = new Bread();
        }
        public abstract void SetFlour();
        public abstract void SetSalt();
        public abstract void SetAdditives();
    }
    // пекарь
    class Baker
    {
        public Bread Bake(BreadBuilder breadBuilder)
        {
            breadBuilder.CreateBread();
            breadBuilder.SetFlour();
            breadBuilder.SetSalt();
            breadBuilder.SetAdditives();
            return breadBuilder.Bread;
        }
    }
    // строитель для ржаного хлеба
    class RyeBreadBuilder : BreadBuilder
    {
        public override void SetFlour()
        {
            this.Bread.Flour = new Flour { Sort = "Ржаная мука 1 сорт" };
        }
 
        public override void SetSalt()
        {
            this.Bread.Salt = new Salt();
        }
 
        public override void SetAdditives()
        {
            // не используется
        }
    }
    // строитель для пшеничного хлеба
    class WheatBreadBuilder : BreadBuilder
    {
        public override void SetFlour()
        {
            this.Bread.Flour = new Flour { Sort = "Пшеничная мука высший сорт" };
        }
 
        public override void SetSalt()
        {
            this.Bread.Salt = new Salt();
        }
 
        public override void SetAdditives()
        {
            this.Bread.Additives = new Additives { Name = "улучшитель хлебопекарный" };
        }
    }
}