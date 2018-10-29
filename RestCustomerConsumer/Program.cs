using ClassLibraryForCustomer.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace RestCustomerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (Customer c in GetCustomers())
            {
                Console.WriteLine(c);
            }

           
            DeleteCustomer(1);
            Console.ReadLine();

            foreach (Customer c in GetCustomers())
            {
                Console.WriteLine(c);
            }

            Console.ReadLine();

            Customer c4 = new Customer(05, "Lærke", "Eriksen", 1982);

            UpdateCustomer(c4, 02);
            Console.WriteLine("updated customer 02");
            Console.WriteLine("list after update is:");

            Console.ReadLine();

            foreach (Customer c in GetCustomers())
            {
                Console.WriteLine(c);
            }


            Console.ReadLine();
        }

        private static string uri = "http://localhost:51010/api/Customer/";

        public static IList<Customer> GetCustomers()
        {
            using (HttpClient client = new HttpClient())
            {
                string content = client.GetStringAsync(uri + "All").Result;
                IList<Customer> cList = JsonConvert.DeserializeObject<IList<Customer>>(content);
                return cList;
            }
        }

        public static async void DeleteCustomer(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = await client.DeleteAsync(uri + id);
               
            }
        }

        public static async void UpdateCustomer(Customer customer, int id)
        {
            string jsonstr = JsonConvert.SerializeObject(customer);
            StringContent content = new StringContent(jsonstr, Encoding.UTF8,"application/json");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = await client.PutAsync(uri + id, content);
            }
        }

        public static async void AddCustomer(Customer customer)
        {
            string jsonstr = JsonConvert.SerializeObject(customer);
            StringContent content = new StringContent(jsonstr, Encoding.UTF8,"application/json");
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage message = await client.PostAsync(uri, content);
            }
        }
    }
}
