using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        Address usaAddress = new Address("123 main st ", "New York", "Ny", "USA");
        Address nonUsaAddress = new Address("456 main st ", "Toronto", "ontario", "Canada");


        Customer usaCustomer = new Customer("John Smith", "john.smith@example.com", "123-456-7890", usaAddress);
        Customer internationalCustomer = new Customer("Jane Doe", "jane.doe@example.com", "987-654-3210", nonUsaAddress);


        Product laptop = new Product("Laptop", "P001", 999.99,2); 
        Product headphones = new Product("Headphones", "P002", 199.99, 1);
        Product mouse = new Product("Mouse", "P003", 49.99, 3); 
        Product keyboard = new Product("Keyboard", "P004", 79.99, 1);
        Product monitor = new Product("Monitor", "P005", 299.99, 1);

        Order order1 = new Order(usaCustomer);
        order1.AddProduct(laptop);
        order1.AddProduct(headphones);
        order1.AddProduct(mouse);
        order1.AddProduct(keyboard);



        Console.WriteLine("order 1");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order1.CalculateTotalPrice():F2}");


        Order order2 = new Order(internationalCustomer);
        order2.AddProduct(monitor);
        order2.AddProduct(headphones);
        order2.AddProduct(mouse);
        order2.AddProduct(keyboard);


        Console.WriteLine("\norder 2");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Price: ${order2.CalculateTotalPrice():F2}");
    }
}