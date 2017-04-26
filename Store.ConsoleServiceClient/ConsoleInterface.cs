using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Store.ConsoleServiceClient.CustomerService;
using Store.ConsoleServiceClient.OrderService;
using Store.ConsoleServiceClient.ProductService;
using Store.ConsoleServiceClient.Service;
using Customer = Store.ConsoleServiceClient.CustomerService.Customer;
using Order = Store.ConsoleServiceClient.OrderService.Order;
using Product = Store.ConsoleServiceClient.CustomerService.Product;

namespace Store.ConsoleServiceClient
{
    public class ConsoleInterface
    {
        private readonly CustomerServiceClient customerServiceClient;
        private readonly ServiceClient serviceClient;
        private readonly OrderServiceClient orderServiceClient;
        private readonly ProductServiceClient productServiceClient;

        public ConsoleInterface(
            OrderServiceClient orderServiceClient,
            ProductServiceClient productServiceClient,
            CustomerServiceClient customerServiceClient,
            ServiceClient serviceClient
        )
        {
            this.orderServiceClient = orderServiceClient;
            this.productServiceClient = productServiceClient;
            this.customerServiceClient = customerServiceClient;
            this.serviceClient = serviceClient;
        }

        public void Run()
        {
            while (true)
            {
                var option = GetMenuOptionMenu();
                ParseMenuOptions(option);
            }
        }

        private void ParseMenuOptions(int menuOption)
        {
            switch (menuOption)
            {
                case 1:
                {
                    AddProductCategory();
                    break;
                }
                case 2:
                {
                    ShowAllProductCategories();
                    break;
                }
                case 3:
                {
                    AddProduct();
                    break;
                }
                case 4:
                {
                    ShowAllProducts();
                    break;
                }
                case 5:
                {
                    AddCustomer();
                    break;
                }
                case 6:
                {
                    ShowAllCustomers();
                    break;
                }
                case 7:
                {
                    AddOrder();
                    break;
                }
                case 8:
                {
                    ShowAllOrders();
                    break;
                }
                case 9:
                {
                    ShowOrdersForCustomer();
                    break;
                }
            }
        }

        private void AddCustomer()
        {
            Console.WriteLine("Insert fields for customer:");
            Console.WriteLine("Fist Name:");
            var fisrstName = Console.ReadLine();
            Console.WriteLine("Last Name:");
            var lastName = Console.ReadLine();
            Console.WriteLine("Email:");
            var email = Console.ReadLine();
            Console.WriteLine("Adress:");
            var adress = Console.ReadLine();
            Console.WriteLine("Phone:");
            var phone = Console.ReadLine();
            var customer = new Customer
            {
                Address = adress,
                Email = email,
                FirstName = fisrstName,
                LastName = lastName,
                Phone = phone
            };
            customerServiceClient.AddCustomer(customer);
            Console.WriteLine("Done.");
        }


        private void ShowAllProductCategories()
        {
            Console.WriteLine("Product category list:");
            var productCategories = productServiceClient.GetAllProductCategories();
            foreach (var productCategory in productCategories)
                WritePrductCategory(productCategory);
        }

        private void ShowAllCustomers()
        {
            Console.WriteLine("Customer list:");
            var customers = customerServiceClient.GetAllCustomers();
            foreach (var customer in customers)
                WriteCustomer(customer);
        }

        private void ShowAllProducts()
        {
            Console.WriteLine("Product list:");
            var products = productServiceClient.GetAllProducts();
            foreach (var product in products)
                WritePrduct(product);
        }

        private int GetMenuOptionMenu()
        {
            Console.WriteLine("Menu:");
            ;
            Console.WriteLine("1.Insert a product category");
            Console.WriteLine("2.Show all product categories");
            Console.WriteLine("3.Insert a product");
            Console.WriteLine("4.Show all products");
            Console.WriteLine("5.Insert a customer");
            Console.WriteLine("6.Show all customers");
            Console.WriteLine("7.AddOrder");
            Console.WriteLine("8.Show all orders");
            Console.WriteLine("9.Show orders for customer");
            Console.WriteLine("---------------------------------\n");
            Console.WriteLine("Choose an option:");
            var strResponse = Console.ReadLine();
            var response = 0;
            try
            {
                if (strResponse != null) response = int.Parse(strResponse);
            }
            catch (Exception exc)
            {
                // ignored
            }
            Console.WriteLine();
            return response;
        }

        private void ShowAllOrders()
        {
            Console.WriteLine("Orders:");
            foreach (var order in orderServiceClient.GetAllOrders())
                WriteOrder(order);
        }

        private void ShowOrdersForCustomer()
        {
            Console.WriteLine("First name:");
            var firstName = Console.ReadLine();
            Console.WriteLine("Last name:");
            var lastName = Console.ReadLine();
            var orders = customerServiceClient.GetOrdersForCustomer(firstName, lastName);
            foreach (var order in orders)
                WriteOrder(order);
        }

        private void AddProductCategory()
        {
            Console.WriteLine("Insert fields for product category:");
            Console.WriteLine("Name:");
            var name = Console.ReadLine();
            Console.WriteLine("Description");
            var description = Console.ReadLine();
            var productCategory = new ProductService.ProductCategory {Description = description, Name = name};
            productServiceClient.AddProductCategory(productCategory);
            Console.WriteLine("Done.");
        }

        private void AddOrder()
        {
            Console.WriteLine("Insert fields for order:");
            Console.WriteLine("Date");
            var date = DateTime.Parse(Console.ReadLine());
            foreach (var customer in customerServiceClient.GetAllCustomers())
                WriteCustomer(customer);
            Console.WriteLine("\nChoose an customer id:");
            var customerId = int.Parse(Console.ReadLine());
            var selectedCustomer = customerServiceClient.GetCustomerById(customerId);

            foreach (var product in productServiceClient.GetAllProducts())
                WritePrduct(product);
            var selectedProducts = new List<OrderService.Product>();
            Console.WriteLine("\nChoose a list of products(Ex: 1,2,3,4):");
            var ids = Console.ReadLine();
            var selectedProductIds = ids.Split(',').Select(int.Parse);
            foreach (var productId in selectedProductIds)
                selectedProducts.Add(
                    Mapper.Map<OrderService.Product>(productServiceClient.GetProductById(productId)));

            var order = new Order
            {
                Customer = Mapper.Map<OrderService.Customer>(selectedCustomer),
                Date = date,
                Products = selectedProducts.ToArray()
            };

            orderServiceClient.AddOrder(order);
            Console.WriteLine("Done.");
        }

        private void AddProduct()
        {
            Console.WriteLine("Insert fields for product:");
            Console.WriteLine("Name:");
            var name = Console.ReadLine();
            Console.WriteLine("Specification:");
            var specification = Console.ReadLine();
            Console.WriteLine("Price:");
            var price = double.Parse(Console.ReadLine());
            Console.WriteLine("Alegeti o categorie:");
            foreach (var prodCategory in productServiceClient.GetAllProductCategories())
                Console.WriteLine($"{prodCategory.Id}-{prodCategory.Name}");
            Console.WriteLine("Introduceti o valoare pentru categorie:");
            var category = productServiceClient.GetProductCategoryById(int.Parse(Console.ReadLine()));
            var product = new ProductService.Product
            {
                Price = price,
                Category = category,
                Name = name,
                Specification = specification
            };

            productServiceClient.AddProduct(product);
            Console.WriteLine("Done.");
        }

        public void WritePrductCategory(ProductService.ProductCategory productCategory)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Product Category:");
            Console.WriteLine($"Name: {productCategory.Name} Description:{productCategory.Description}");
            Console.WriteLine("-------------------------------");
        }

        public void WritePrduct(OrderService.Product product)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Product:");

            Console.WriteLine($"Id:{product.Id}");
            Console.WriteLine($"Name: {product.Name} \n Specifications:{product.Specification}");
            Console.WriteLine($"Category Name:{product.Category.Name}");
            Console.WriteLine($"Price:{product.Price}");
            Console.WriteLine("-------------------------------");
        }


        public void WritePrduct(ProductService.Product product)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Product:");

            Console.WriteLine($"Id:{product.Id}");
            Console.WriteLine($"Name: {product.Name} \n Specifications:{product.Specification}");
            Console.WriteLine($"Category Name:{product.Category.Name}");
            Console.WriteLine($"Price:{product.Price}");
            Console.WriteLine("-------------------------------");
        }

        public void WritePrduct(Product product)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Product:");

            Console.WriteLine($"Id:{product.Id}");
            Console.WriteLine($"Name: {product.Name} \n Specifications:{product.Specification}");
            Console.WriteLine($"Category Name:{product.Category.Name}");
            Console.WriteLine($"Price:{product.Price}");
            Console.WriteLine("-------------------------------");
        }

        public void WriteCustomer(Customer customer)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Customer:");
            Console.WriteLine($"Id:{customer.Id}");
            Console.WriteLine($"First Name: {customer.FirstName} \n Last Name:{customer.LastName}");

            Console.WriteLine($"Email:{customer.Email}");
            Console.WriteLine($"Adress:{customer.Address}");
            Console.WriteLine($"Phone:{customer.Phone}");
            Console.WriteLine("-------------------------------");
        }

        public void WriteCustomer(OrderService.Customer customer)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Customer:");
            Console.WriteLine($"Id:{customer.Id}");
            Console.WriteLine($"First Name: {customer.FirstName} \n Last Name:{customer.LastName}");
            Console.WriteLine($"Email:{customer.Email}");
            Console.WriteLine($"Adress:{customer.Address}");
            Console.WriteLine($"Phone:{customer.Phone}");
            Console.WriteLine("-------------------------------");
        }

        public void WriteOrder(Order order)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Order:");
            Console.WriteLine($"Date: {order.Date}");
            WriteCustomer(order.Customer);
            Console.WriteLine("\nProducts");
            foreach (var product in order.Products)
                WritePrduct(product);
            Console.WriteLine("-------------------------------");
        }

        public void WriteOrder(CustomerService.Order order)
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Order:");
            Console.WriteLine($"Date: {order.Date}");
            WriteCustomer(order.Customer);
            Console.WriteLine("\nProducts");
            foreach (var product in order.Products)
                WritePrduct(product);
            Console.WriteLine("-------------------------------");
        }
    }
}