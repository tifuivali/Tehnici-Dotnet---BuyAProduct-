using System;
using System.Collections.Generic;
using System.Linq;
using Store.Database.Models;
using Store.Domain.CustomerManagement;
using Store.Domain.OrderManagement;
using Store.Domain.ProductCategoryManagement;
using Store.Domain.ProductManagement;
using Customer = Store.Domain.CustomerManagement.Customer;
using Order = Store.Domain.OrderManagement.Order;
using Product = Store.Domain.ProductManagement.Product;
using ProductCategory = Store.Domain.ProductCategoryManagement.ProductCategory;

namespace Store.Console
{
    public class ConsoleInterface
    {
        private readonly IProductRepository productRepository;
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;

        public ConsoleInterface(IProductRepository productRepository, 
            IProductCategoryRepository productCategoryRepository,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository)
        {
            this.productRepository = productRepository;
            this.productCategoryRepository = productCategoryRepository;
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
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
            System.Console.WriteLine("Insert fields for customer:");
            System.Console.WriteLine("Fist Name:");
            var fisrstName = System.Console.ReadLine();
            System.Console.WriteLine("Last Name:");
            var lastName = System.Console.ReadLine();
            System.Console.WriteLine("Email:");
            var email = System.Console.ReadLine();
            System.Console.WriteLine("Adress:");
            var adress = System.Console.ReadLine();
            System.Console.WriteLine("Phone:");
            var phone = System.Console.ReadLine();
            var customer = new Customer
            {
                Address = adress,
                Email = email,
                FirstName = fisrstName,
                LastName = lastName,
                Phone = phone
            };
            customerRepository.AddCustomer(customer);
            System.Console.WriteLine("Done.");
        }


        private void ShowAllProductCategories()
        {
            System.Console.WriteLine("Product category list:");
            var productCategories = productCategoryRepository.GetAllProductCategories();
            foreach (var productCategory in productCategories)
            {
                WritePrductCategory(productCategory);
            }
        }

        private void ShowAllCustomers()
        {
            System.Console.WriteLine("Customer list:");
            var customers = customerRepository.GetAllCutCustomers();
            foreach (var customer in customers)
            {
                WriteCustomer(customer);
            }
        }

        private void ShowAllProducts()
        {
            System.Console.WriteLine("Product list:");
            var products = productRepository.GetAllProducts();
            foreach (var product in products)
            {
                WritePrduct(product);
            }
        }

        private int GetMenuOptionMenu()
        {
            System.Console.WriteLine("Menu:"); ;
            System.Console.WriteLine("1.Insert a product category");
            System.Console.WriteLine("2.Show all product categories");
            System.Console.WriteLine("3.Insert a product");
            System.Console.WriteLine("4.Show all products");
            System.Console.WriteLine("5.Insert a customer");
            System.Console.WriteLine("6.Show all customers");
            System.Console.WriteLine("7.AddOrder");
            System.Console.WriteLine("8.Show all orders");
            System.Console.WriteLine("9.Show orders for customer");
            System.Console.WriteLine("---------------------------------\n");
            System.Console.WriteLine("Choose an option:");
            var strResponse = System.Console.ReadLine();
            var response = 0;
            try
            {
                if (strResponse != null) response = int.Parse(strResponse);
            }
            catch (Exception exc)
            {
                // ignored
            }
            System.Console.WriteLine();
            return response;

        }

        private void ShowAllOrders()
        {
            System.Console.WriteLine("Orders:");
            foreach (var order in orderRepository.GetAllOrders())
            {
                WriteOrder(order);
            }
        }

        private void ShowOrdersForCustomer()
        {
            System.Console.WriteLine("First name:");
            var firstName = System.Console.ReadLine();
            System.Console.WriteLine("Last name:");
            var lastName = System.Console.ReadLine();
            var orders = customerRepository.GetOrdersForCustomers(firstName, lastName);
            foreach (var order in orders)
            {
                WriteOrder(order);
            }
        }

        private void AddProductCategory()
        {
            System.Console.WriteLine("Insert fields for product category:");
            System.Console.WriteLine("Name:");
            var name = System.Console.ReadLine();
            System.Console.WriteLine("Description");
            var description = System.Console.ReadLine();
            var productCategory = new ProductCategory { Description = description, Name = name };
            productCategoryRepository.AddProductCategory(productCategory);
            System.Console.WriteLine("Done.");
        }

        private void AddOrder()
        {
            System.Console.WriteLine("Insert fields for order:");
            System.Console.WriteLine("Date");
            var date = DateTime.Parse(System.Console.ReadLine());
            foreach (var customer in customerRepository.GetAllCutCustomers())
            {
                WriteCustomer(customer);
            }
            System.Console.WriteLine("\nChoose an customer id:");
            var customerId = int.Parse(System.Console.ReadLine());
            var selectedCustomer = customerRepository.GetCustomerById(customerId);

            foreach (var product in productRepository.GetAllProducts())
            {
                WritePrduct(product);
            }
            var selectedProducts = new List<Product>();
            System.Console.WriteLine("\nChoose a list of products(Ex: 1,2,3,4):");
            var ids = System.Console.ReadLine();
            var selectedProductIds = ids.Split(',').Select(int.Parse);
            foreach (var productId in selectedProductIds)
            {
                selectedProducts.Add(productRepository.GetProductById(productId));
            }

            var order = new Order
            {
                Customer = selectedCustomer,
                Date = date,
                Products = selectedProducts
            };
            orderRepository.AddOrder(order);
            System.Console.WriteLine("Done.");
        }

        private void AddProduct()
        {
            System.Console.WriteLine("Insert fields for product:");
            System.Console.WriteLine("Name:");
            var name = System.Console.ReadLine();
            System.Console.WriteLine("Specification:");
            var specification = System.Console.ReadLine();
            System.Console.WriteLine("Price:");
            var price = double.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Alegeti o categorie:");
            foreach (var prodCategory in productCategoryRepository.GetAllProductCategories())
            {
                System.Console.WriteLine($"{prodCategory.Id}-{prodCategory.Name}");
            }
            System.Console.WriteLine("Introduceti o valoare pentru categorie:");
            var category = productCategoryRepository.GetProductCategoryById(int.Parse(System.Console.ReadLine()));
            var product = new Product()
            {
                Price = price,
                Category = category,
                Name = name,
                Specification = specification
            };
            productRepository.AddProduct(product);
            System.Console.WriteLine("Done.");
        }

        public void WritePrductCategory(ProductCategory productCategory)
        {
            System.Console.WriteLine("-------------------------------");
            System.Console.WriteLine("Product Category:");
            System.Console.WriteLine($"Name: {productCategory.Name} Description:{productCategory.Description}");
            System.Console.WriteLine("-------------------------------");
        }

        public void WritePrduct(Product product)
        {
            System.Console.WriteLine("-------------------------------");
            System.Console.WriteLine("Product:");

            System.Console.WriteLine($"Id:{product.Id}");
            System.Console.WriteLine($"Name: {product.Name} \n Specifications:{product.Specification}");
            System.Console.WriteLine($"Category Name:{product.Category.Name}");
            System.Console.WriteLine($"Price:{product.Price}");
            System.Console.WriteLine("-------------------------------");
        }

        public void WriteCustomer(Customer customer)
        {
            System.Console.WriteLine("-------------------------------");
            System.Console.WriteLine("Customer:");
            System.Console.WriteLine($"Id:{customer.Id}");
            System.Console.WriteLine($"First Name: {customer.FirstName} \n Last Name:{customer.LastName}");
            System.Console.WriteLine($"Email:{customer.Email}");
            System.Console.WriteLine($"Adress:{customer.Address}");
            System.Console.WriteLine($"Phone:{customer.Phone}");
            System.Console.WriteLine("-------------------------------");
        }

        public void WriteOrder(Order order)
        {
            System.Console.WriteLine("-------------------------------");
            System.Console.WriteLine("Order:");
            System.Console.WriteLine($"Date: {order.Date}");
            WriteCustomer(order.Customer);
            System.Console.WriteLine("\nProducts");
            foreach (var product in order.Products)
            {
                WritePrduct(product);
            }
            System.Console.WriteLine("-------------------------------");
        }

    }
}
