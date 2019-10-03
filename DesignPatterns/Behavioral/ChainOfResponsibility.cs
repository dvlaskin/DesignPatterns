using System;

namespace DesignPatterns.Behavioral
{

    /// <summary>
    /// Цепочка Обязанностей (Chain of responsibility) - поведенческий шаблон проектирования,
    /// который позволяет избежать жесткой привязки отправителя запроса к получателю,
    /// позволяя нескольким объектам обработать запрос.
    /// Все возможные обработчики запроса образуют цепочку,
    /// а сам запрос перемещается по этой цепочке, пока один из ее объектов не обработает запрос.
    /// Каждый объект при получении запроса выбирает, либо обработать запрос,
    /// либо передать выполнение запроса следующему по цепочке.
    ///
    /// Когда применяется цепочка обязанностей?
    ///
    /// Когда имеется более одного объекта, который может обработать определенный запрос
    ///
    /// Когда надо передать запрос на выполнение одному из нескольких объектов,
    /// точно не определяя, какому именно объекту
    ///
    /// Когда набор объектов задается динамически
    /// </summary>
    public class ChainOfResponsibility
    {
        public static void Run()
        {
            Console.WriteLine("\r\n\tChainOfResponsibility\r\n");
            
            Receiver receiver = new Receiver(false, true, true);
             
            PaymentHandler bankPaymentHandler = new BankPaymentHandler();
            PaymentHandler moneyPaymentHnadler = new MoneyPaymentHandler();
            PaymentHandler paypalPaymentHandler = new PayPalPaymentHandler();
            bankPaymentHandler.Successor = paypalPaymentHandler;
            paypalPaymentHandler.Successor = moneyPaymentHnadler;
     
            bankPaymentHandler.Handle(receiver);

        }
    }
     
    class Receiver
    {
        // банковские переводы
        public bool BankTransfer { get; set; }
        // денежные переводы - WesternUnion, Unistream
        public bool MoneyTransfer { get; set; }
        // перевод через PayPal
        public bool PayPalTransfer { get; set; }
        public Receiver(bool bt, bool mt, bool ppt)
        {
            BankTransfer = bt;
            MoneyTransfer = mt;
            PayPalTransfer = ppt;
        }
    }
    
    abstract class PaymentHandler
    {
        public PaymentHandler Successor { get; set; }
        public abstract void Handle(Receiver receiver);
    }
     
    class BankPaymentHandler : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.BankTransfer == true)
                Console.WriteLine("Выполняем банковский перевод");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }
     
    class PayPalPaymentHandler : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.PayPalTransfer == true)
                Console.WriteLine("Выполняем перевод через PayPal");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }
    
    // переводы с помощью системы денежных переводов
    class MoneyPaymentHandler : PaymentHandler
    {
        public override void Handle(Receiver receiver)
        {
            if (receiver.MoneyTransfer == true)
                Console.WriteLine("Выполняем перевод через системы денежных переводов");
            else if (Successor != null)
                Successor.Handle(receiver);
        }
    }
}