using System;

namespace MultiUserBank_WilkersonV1
{
    class Program
    {
        static void Main(string[] args)
        {
            // First or Nickname Lastname
            // IT112
            // NOTES: MultiUserBank
            // BEHAVIORS NOT IMPLEMENTED AND WHY:

            Bank bank = new Bank();
            Console.WriteLine($"Bank initial balance: {bank.BankBalance:C}");
            int choice;
            int loggedInUserId = -1;

            while (true)
            {
                if (loggedInUserId == -1)
                {
                    Console.WriteLine("\n1. Login\n2. Exit");
                    choice = int.Parse(Console.ReadLine());

                    if (choice == 1)
                    {
                        Console.Write("Username: ");
                        string username = Console.ReadLine();
                        Console.Write("Password: ");
                        string password = Console.ReadLine();
                        loggedInUserId = bank.Login(username, password);

                        if (loggedInUserId != -1)
                        {
                            Console.WriteLine($"\nWelcome, {bank.GetCustomerName(loggedInUserId)}!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid username or password.");
                        }
                    }
                    else if (choice == 2)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine($"\nWelcome {bank.GetCustomerName(loggedInUserId)}!");
                    Console.WriteLine("1. Check balance\n2. Deposit\n3. Withdraw\n4. Logout");
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"Your balance: {bank.GetCustomerBalance(loggedInUserId):C}");
                            break;
                        case 2:
                            Console.Write("Deposit amount: ");
                            decimal depositAmount = decimal.Parse(Console.ReadLine());
                            bank.Deposit(loggedInUserId, depositAmount);
                            Console.WriteLine($"Your new balance: {bank.GetCustomerBalance(loggedInUserId):C}");
                            break;
                        case 3:
                            Console.Write("Withdraw amount: ");
                            decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                            decimal amountWithdrawn = bank.Withdraw(loggedInUserId, withdrawAmount);
                            Console.WriteLine($"Amount withdrawn: {amountWithdrawn:C}");
                            Console.WriteLine($"Your new balance: {bank.GetCustomerBalance(loggedInUserId):C}");
                            break;
                        case 4:
                            Console.WriteLine($"Logging out {bank.GetCustomerName(loggedInUserId)}...");
                            loggedInUserId = -1;
                            Console.WriteLine($"Bank balance after logout: {bank.BankBalance:C}");
                            break;
                    }
                }
            }
        }
    }
}
