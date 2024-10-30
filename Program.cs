using System;
using CRMApp.Models;
using CRMApp.Repositories;

namespace CRMApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new CustomerRepository();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== CRM Application ===");
                Console.WriteLine("1. List Customers");
                Console.WriteLine("2. Add Customer");
                Console.WriteLine("3. Update Customer");
                Console.WriteLine("4. Delete Customer");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ListCustomers(repository);
                        break;
                    case "2":
                        AddCustomer(repository);
                        break;
                    case "3":
                        UpdateCustomer(repository);
                        break;
                    case "4":
                        DeleteCustomer(repository);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid selection.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ListCustomers(CustomerRepository repository)
        {
            Console.Clear();
            Console.WriteLine("=== Customer List ===");
            foreach (var customer in repository.GetAll())
            {
                Console.WriteLine($"{customer.Id}: {customer.FirstName} {customer.LastName} - {customer.Email} - {customer.Phone}");
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void AddCustomer(CustomerRepository repository)
        {
            Console.Clear();
            Console.WriteLine("=== Add Customer ===");
            var customer = new Customer();

            Console.Write("First Name: ");
            customer.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            customer.LastName = Console.ReadLine();

            Console.Write("Email: ");
            customer.Email = Console.ReadLine();

            Console.Write("Phone: ");
            customer.Phone = Console.ReadLine();

            repository.Add(customer);
            Console.WriteLine("Customer added successfully!");
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void UpdateCustomer(CustomerRepository repository)
        {
            Console.Clear();
            Console.WriteLine("=== Update Customer ===");

            Console.Write("Enter Customer ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var customer = repository.GetById(id);
                if (customer != null)
                {
                    Console.Write($"First Name ({customer.FirstName}): ");
                    var firstName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(firstName))
                        customer.FirstName = firstName;

                    Console.Write($"Last Name ({customer.LastName}): ");
                    var lastName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(lastName))
                        customer.LastName = lastName;

                    Console.Write($"Email ({customer.Email}): ");
                    var email = Console.ReadLine();
                    if (!string.IsNullOrEmpty(email))
                        customer.Email = email;

                    Console.Write($"Phone ({customer.Phone}): ");
                    var phone = Console.ReadLine();
                    if (!string.IsNullOrEmpty(phone))
                        customer.Phone = phone;

                    repository.Update(customer);
                    Console.WriteLine("Customer updated successfully!");
                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }

        static void DeleteCustomer(CustomerRepository repository)
        {
            Console.Clear();
            Console.WriteLine("=== Delete Customer ===");

            Console.Write("Enter Customer ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                repository.Delete(id);
                Console.WriteLine("Customer deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}

