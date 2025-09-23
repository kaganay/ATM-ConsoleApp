using System;

class ATM
{
    private double balance;

    public ATM(double initialBalance)
    {
        balance = initialBalance;
    }

    public void ShowBalance()
    {
        Console.WriteLine($"Your balance is: {balance} TL");
    }

    public void Deposit()
    {
        double amount;
        Console.Write("Enter amount to deposit: ");
        while (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
        {
            Console.WriteLine("Invalid amount! Enter a positive number.");
            Console.Write("Enter amount to deposit: ");
        }

        balance += amount;
        Console.WriteLine($"New balance: {balance} TL");
    }

    public void Withdraw()
    {
        double amount;
        Console.Write("Enter amount to withdraw: ");
        while (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0 || amount > balance)
        {
            Console.WriteLine("Invalid amount or insufficient balance! Try again.");
            Console.Write("Enter amount to withdraw: ");
        }

        balance -= amount;
        Console.WriteLine($"New balance: {balance} TL");
    }
}

class Program
{
    static void Main()
    {
        ATM atm = new ATM(1000); // Başlangıç bakiyesi
        int choice;

        do
        {
            DisplayMenu();
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input! Please enter a number.");
                Console.Write("Your choice: ");
            }

            switch (choice)
            {
                case 1: atm.ShowBalance(); break;
                case 2: atm.Deposit(); break;
                case 3: atm.Withdraw(); break;
                case 0: Console.WriteLine("Exiting..."); break;
                default: Console.WriteLine("Invalid choice!"); break;
            }

            if (choice != 0)
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }

        } while (choice != 0);
    }

    static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("=== ATM Simulator ===");
        Console.WriteLine("1- Check Balance");
        Console.WriteLine("2- Deposit Money");
        Console.WriteLine("3- Withdraw Money");
        Console.WriteLine("0- Exit");
        Console.Write("Your choice: ");
    }
}
