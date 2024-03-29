﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Structural
{

    /// <summary>
    /// Паттерн Заместитель (Proxy) предоставляет объект-заместитель,
    /// который управляет доступом к другому объекту.
    /// То есть создается объект-суррогат, который может выступать
    /// в роли другого объекта и замещать его.
    ///
    /// Когда использовать прокси?
    ///
    /// Когда надо осуществлять взаимодействие по сети, а объект-проси должен
    /// имитировать поведения объекта в другом адресном пространстве.
    /// Использование прокси позволяет снизить накладные издержки
    /// при передачи данных через сеть. Подобная ситуация еще называется
    /// удалённый заместитель (remote proxies)
    ///
    /// Когда нужно управлять доступом к ресурсу, создание которого требует больших затрат.
    /// Реальный объект создается только тогда, когда он действительно может понадобится,
    /// а до этого все запросы к нему обрабатывает прокси-объект.
    /// Подобная ситуация еще называется виртуальный заместитель (virtual proxies)
    ///
    /// Когда необходимо разграничить доступ к вызываемому объекту в зависимости
    /// от прав вызывающего объекта. Подобная ситуация еще называется
    /// защищающий заместитель (protection proxies)
    ///
    /// Когда нужно вести подсчет ссылок на объект или обеспечить
    /// потокобезопасную работу с реальным объектом. Подобная ситуация
    /// называется "умные ссылки" (smart reference)
    /// </summary>
    public class ProxyPatten
    {
        public static void Run()
        {
            Console.WriteLine("\r\n\tProxyPatten\r\n");
            
            using(IBook book = new BookStoreProxy())
            {
                // читаем первую страницу
                Page page1 = book.GetPage(1);
                Console.WriteLine(page1.Text);
                // читаем вторую страницу
                Page page2 = book.GetPage(2);
                Console.WriteLine(page2.Text);
                // возвращаемся на первую страницу    
                page1 = book.GetPage(1);
                Console.WriteLine(page1.Text);
            }
             
        }
    }
    class Page
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
    }
    class PageContext
    {
        public List<Page> Pages { get; set; }
    }
 
    interface IBook : IDisposable
    {
        Page GetPage(int number);
    }
 
    class BookStore : IBook
    {
        PageContext db;
        public BookStore()
        {
            db = new PageContext();
        }
        public Page GetPage(int number)
        {
            return db.Pages.FirstOrDefault(p => p.Number == number);
        }
 
        public void Dispose()
        {
            //db.Dispose();
        }
    }
 
    class BookStoreProxy : IBook
    {
        List<Page> pages;
        BookStore bookStore;
        public BookStoreProxy()
        {
            pages=new List<Page>();
        }
        public Page GetPage(int number)
        {
            Page page = pages.FirstOrDefault(p=>p.Number==number);
            if (page == null)
            {
                if (bookStore == null)
                    bookStore = new BookStore();
                page= bookStore.GetPage(number);
                pages.Add(page);
            }
            return page;
        }
 
        public void Dispose()
        {
            if(bookStore!=null)
                bookStore.Dispose();
        }
    }
}