/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Creating a queue with less than 1 size and serving an empty queue
        // Expected Result: tc1._maxSize: 10, "The queue is empty"
        Console.WriteLine("Test 1");

        // Defect(s) Found: None for creating the queue, ServeCustomer wasn't coded for an empty queue
        var tc1 = new CustomerService(-9);

        Console.WriteLine("tc1._maxSize: " + tc1._maxSize);
        tc1.ServeCustomer();
        
        Console.WriteLine("=================");

        // Test 2
        // Scenario: adding 6 customers to a list with a _maxSize of 5 and then serving a Customer
        // Expected Result: "Maximum Number of Customers in Queue.", $"{Name} ({AccountId})  : {Problem}"
        Console.WriteLine("Test 2");
        var tc2 = new CustomerService(5);

        tc2.AddNewCustomer();
        tc2.AddNewCustomer();
        tc2.AddNewCustomer();
        tc2.AddNewCustomer();
        tc2.AddNewCustomer();
        tc2.AddNewCustomer();

        tc2.ServeCustomer();

        // Defect(s) Found: AddNewCustomer's if statement needed to be >= and ServeCustomer was removing the Customer before logging the Customer

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count >= 1) {
            Console.WriteLine(_queue[0]);
            _queue.RemoveAt(0);
        }
        else {
            Console.WriteLine("The queue is empty");
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}