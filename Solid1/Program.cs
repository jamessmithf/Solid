using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid1
{
    /* В поданому коді порушено Single Responsibility Principle. 
     * Кожен клас має відповідати лише за один тип задач */

    // Виправлений код:

    class Item
    {
        // Логіка для товару
    }

    // Клас для роботи із замовленням
    class Order
    {
        private List<Item> itemList = new List<Item>();

        public List<Item> ItemList => itemList;

        public void CalculateTotalSum() {/* Обчислення загальної суми */}
        public int GetItemCount() => itemList.Count;
        public void AddItem(Item item) => itemList.Add(item);
        public void DeleteItem(Item item) => itemList.Remove(item);
    }

    // Клас для відображення замовлення
    class OrderPrinter
    {
        public void PrintOrder(Order order)
        {
            // Логіка для друку замовлення
        }

        public void ShowOrder(Order order)
        {
            // Логіка для відображення замовлення
        }
    }

    // Клас для збереження та завантаження даних замовлення
    class OrderRepository
    {
        public void Save(Order order)
        {
            // Логіка для збереження замовлення
        }

        public Order Load(int orderId)
        {
            // Логіка для завантаження замовлення
            return new Order();
        }

        public void Update(Order order)
        {
            // Логіка для оновлення замовлення
        }

        public void Delete(int orderId)
        {
            // Логіка для видалення замовлення
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Order order = new Order();
            order.AddItem(new Item());
            Console.WriteLine($"Кількість товарів: {order.GetItemCount()}");

            OrderPrinter printer = new OrderPrinter();
            printer.ShowOrder(order);

            OrderRepository repository = new OrderRepository();
            repository.Save(order);
        }
    }
}
