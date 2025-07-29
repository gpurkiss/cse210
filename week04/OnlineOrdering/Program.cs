using System;

class Program
{
    static void Main(string[] args)
    {
        // First Order (USA)
        Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("Alice Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Notebook", "A101", 2.50m, 4));
        order1.AddProduct(new Product("Pen", "B205", 1.00m, 10));

        Console.WriteLine("Order 1:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}");
        Console.WriteLine();

        // Second Order (International)
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Bob Johnson", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Sketchbook", "S303", 5.00m, 2));
        order2.AddProduct(new Product("Marker Set", "M404", 8.75m, 1));

        Console.WriteLine("Order 2:");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}");
    }
}
