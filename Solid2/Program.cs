using System;
using System.Collections.Generic;

/* У цьому коді порушено Single Responsibility Principle. 
 * Логування не є основною відповідальністю EmailSender */

// Виправлений код:
namespace Solid_2
{
    class Email
    {
        public string Theme { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }

    interface ILogger
    {
        void log(string message);
    }

    class ConsoleLogger : ILogger
    {
        public void log(string message)
        {
            Console.WriteLine(message);
        }
    }

    class EmailSender
    {
        private readonly ILogger _logger;
        public EmailSender(ILogger logger)
        {
            _logger = logger;
        }
        public void Send(Email email)
        {
            // ... sending...
            _logger.log($"Email from \'{email.From}\' to \'{email.To}\' was send");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Email> chatting = new List<Email>{
           new Email() { From = "Me", To = "Vasya", Theme = "Who are you?" },
           new Email() { From = "Vasya", To = "Me", Theme = "vacuum cleaners!" },
           new Email() { From = "Kolya", To = "Vasya", Theme = "No! Thanks!" },
           new Email() { From = "Vasya", To = "Me", Theme = "washing machines!" },
           new Email() { From = "Me", To = "Vasya", Theme = "Yes" },
           new Email() { From = "Vasya", To = "Petya", Theme = "+2" },
        };

            ILogger logger = new ConsoleLogger();
            EmailSender es = new EmailSender(logger);

            foreach (Email email in chatting)
            {
                es.Send(email);
            }

            Console.ReadKey();
        }
    }
}
