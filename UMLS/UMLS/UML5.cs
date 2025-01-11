using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLS
{
    internal class UML5

    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.ReadLine();
        }

        // Araba kiralama sınıfı
        public class Transaction
        {
            protected int id { get; set; }
            public string name { get; set; }
            public string date { get; set; }
            public string address { get; set; }
            public Customer customer { get; set; }
            List<Reservation> reservations { get; set; }

            public void update(Transaction transaction)
            {
                this.name = transaction.name;
                this.date = transaction.date;
                this.address = transaction.address;
                this.customer = transaction.customer;
            }
        }

        // Rezervasyon sınıfı
        public class Reservation
        {
            protected int id;
            public string details;
            public string list;
            public Transaction transaction { get; set; }
            List<Transaction> transactions { get; set; }
            public void confirmation(RentingOwner rentingOwner)
            {
            }
        }

        // Müşteri sınıfı
        public class Customer
        {
            protected int id { get; set; }
            public string name { get; set; }
            public string contact { get; set; }
            public string address { get; set; }
            protected int payment { get; set; }

            protected void update(Customer customer)
            {
                this.name = customer.name;
                this.contact = customer.contact;
                this.address = customer.address;
                this.payment = customer.payment;
            }
        }

        // Araba sınıfı
        public class Car
        {
            protected int id { get; set; }
            public int details { get; set; }
            public string orderType { get; set; }
            public RentingOwner rentingOwner { get; set; }
            public void ProcessDebit()
            {
            }
        }

        // Kiralama sahibi sınıfı
        public class RentingOwner
        {
            protected int id { get; set; }
            public string name;
            public string age;
            public string contactnum;
            private string username;
            private string password;
            public List<Rentals> rentals { get; set; }
            public void verifyAccount(string username, string password)
            {
                if (this.username == username && this.password == password)
                {
                    Console.WriteLine("Giriş Başarılı");
                }
                else
                {
                    Console.WriteLine("Giriş Başarısız");
                }
            }
        }

        // Ödeme sınıfı
        public class Payment
        {
            public int id { get; set; }
            public int cardNumber { get; set; }
            public string amount { get; set; }
            public Customer customer { get; set; }
            public void add(Payment Payment)
            {
                cardNumber = Payment.cardNumber;
                amount = Payment.amount;
                customer = Payment.customer;
            }

            public void update(Payment payment)
            {
                cardNumber = payment.cardNumber;
                amount = payment.amount;
                customer = payment.customer;
            }
        }

        // Kiralama sınıfı
        public class Rentals
        {
            protected int id { get; set; }
            public string names { get; set; }
            public string price { get; set; }
            public Car car { get; set; }

            // Kiralama Add Metodu 
            public void add(Rentals rentals)
            {
                names = rentals.names;
                price = rentals.price;
                car = rentals.car;
            }

            public void update(Rentals rentals)
            {
                names = rentals.names;
                price = rentals.price;
                car = rentals.car;
            }
        }
    }
}
