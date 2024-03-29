﻿using System;

namespace DesignPatterns.Behavioral
{

    /// <summary>
    /// Состояние (State) - шаблон проектирования, который позволяет объекту изменять
    /// свое поведение в зависимости от внутреннего состояния.
    ///
    /// Когда применяется данный паттерн?
    ///
    /// Когда поведение объекта должно зависеть от его состояния и
    /// может изменяться динамически во время выполнения
    ///
    /// Когда в коде методов объекта используются многочисленные условные конструкции,
    /// выбор которых зависит от текущего состояния объекта
    /// </summary>
    public class State
    {
        public static void Run()
        {
            Console.WriteLine("\r\n\tState\r\n");
            
            Water water = new Water(new LiquidWaterState());
            water.Heat();
            water.Frost();
            water.Frost();

        }
    }
    
    class Water
    {
        public IWaterState State { get; set; }
 
        public Water(IWaterState ws)
        {
            State = ws;
        }
 
        public void Heat()
        {
            State.Heat(this);
        }
        
        public void Frost()
        {
            State.Frost(this);
        }
    }
 
    interface IWaterState
    {
        void Heat(Water water);
        void Frost(Water water);
    }
 
    class SolidWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Превращаем лед в жидкость");
            water.State = new LiquidWaterState();
        }
 
        public void Frost(Water water)
        {
            Console.WriteLine("Продолжаем заморозку льда");
        }
    }
    
    class LiquidWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Превращаем жидкость в пар");
            water.State = new GasWaterState();
        }
 
        public void Frost(Water water)
        {
            Console.WriteLine("Превращаем жидкость в лед");
            water.State = new SolidWaterState();
        }
    }
    
    class GasWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Повышаем температуру водяного пара");
        }
 
        public void Frost(Water water)
        {
            Console.WriteLine("Превращаем водяной пар в жидкость");
            water.State = new LiquidWaterState();
        }
    }
}