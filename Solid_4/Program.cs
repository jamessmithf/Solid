using System;
using System.Text;

/* Очевидно, що було порушено Interface Segregation Principle
 * Принцип ISP стверджує, що клієнти не повинні бути змушені залежати від методів, 
 * які вони не використовують */

// Виправлений код:

namespace Solid_4
{
    // Інтерфейс для роботи з ціною
    interface IPricedItem { void SetPrice(double price); }

    // Інтерфейс для роботи зі знижками
    interface IDiscountable { void ApplyDiscount(string discount); void ApplyPromocode(string promocode); }

    // Інтерфейс для кольору
    interface IColorable { void SetColor(string color); }

    // Інтерфейс для розміру
    interface ISized { void SetSize(double size); }

    // Клас для книги
    class Book : IPricedItem, IDiscountable
    {
        private double _price;
        private string _discount;
        private string _promocode;

        public void SetPrice(double price)
        {
            _price = price;
            Console.WriteLine($"Ціна книги: {price}");
        }

        public void ApplyDiscount(string discount)
        {
            _discount = discount;
            Console.WriteLine($"На книгу діє знижка: {discount}");
        }

        public void ApplyPromocode(string promocode)
        {
            _promocode = promocode;
            Console.WriteLine($"Для книги застосовано промокод: {promocode}");
        }
    }

    // Клас для верхнього одягу
    class Outerwear : IPricedItem, IDiscountable, IColorable, ISized
    {
        private double _price;
        private string _discount;
        private string _promocode;
        private string _color;
        private double _size;

        public void SetPrice(double price)
        {
            _price = price;
            Console.WriteLine($"Ціна верхнього одягу: {price}");
        }

        public void ApplyDiscount(string discount)
        {
            _discount = discount;
            Console.WriteLine($"На верхній одяг діє знижка: {discount}");
        }

        public void ApplyPromocode(string promocode)
        {
            _promocode = promocode;
            Console.WriteLine($"Для верхнього одягу застосовано такий промокод: {promocode}");
        }

        public void SetColor(string color)
        {
            _color = color;
            Console.WriteLine($"Колір верхнього одягу: {color}");
        }

        public void SetSize(double size)
        {
            _size = size;
            Console.WriteLine($"Розмір верхнього одягу: {size}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Приклад роботи з книгою
            Book book = new Book();
            book.SetPrice(200);
            book.ApplyDiscount("10%");
            book.ApplyPromocode("КУБІК_2024");

            Console.WriteLine();

            // Приклад роботи з верхнім одягом
            Outerwear jacket = new Outerwear();
            jacket.SetPrice(1500);
            jacket.ApplyDiscount("20%");
            jacket.SetColor("Бузковий");
            jacket.SetSize(58);

            Console.ReadKey();
        }
    }
}
