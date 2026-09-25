using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Notebook", "P100", 3.00, 5));
        order1.AddProduct(new Product("Pen", "P101", 1.50, 10));
        order1.AddProduct(new Product("Backpack", "P102", 25.00, 1));

        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Emma Jones", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Wireless Mouse", "P200", 20.00, 2));
        order2.AddProduct(new Product("Keyboard", "P201", 45.00, 1));

        DisplayOrder(order1);
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("PACKING LABEL");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("SHIPPING LABEL");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"TOTAL PRICE: ${order.CalculateTotalCost():0.00}\n");
        Console.WriteLine("--------------");
    }
}