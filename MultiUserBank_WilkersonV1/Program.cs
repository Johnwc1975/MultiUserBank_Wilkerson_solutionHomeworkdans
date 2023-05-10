using System;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;
using System.Buffers.Text;

namespace MultiUserBank_WilkersonV1
{
    class Program
    {
        static void Main(string[] args)
        {
            // John Wilkerson

            // IT112


            // NOTES: MultiUserBank   


            //This code is a simple console - based banking application, where users can log in, check their balance, deposit, withdraw, and log out. The bank also keeps track of its balance. I'll break down this code step by step 

            //1. `Bank bank = new Bank();` -Here, an instance of the Bank class is being created.This represents the bank where all transactions will be performed.

            //2. `Console.WriteLine($"Bank initial balance: {bank.BankBalance:C}");` - This prints the initial balance of the bank to the console.We don't see the BankBalance property or the Bank class in this code, but we can infer that it's a property within the Bank class that keeps track of the total amount of money in the bank.

            //3. `int choice; int loggedInUserId = -1;` - Two integer variables are declared. `choice` will be used to store the user's choices in the application, while `loggedInUserId` will store the ID of the currently logged in user. It's initially set to -1, indicating no user is logged in.

            //4. The outer `while (true)` loop keeps the application running indefinitely until the user chooses to exit.

            //5. `if (loggedInUserId == -1)` - This checks if a user is currently logged in. If `loggedInUserId` is -1, no user is logged in.

            //6. If no user is logged in, the application displays two options: 1) Login, and 2) Exit.The user's choice is read from the console and stored in the `choice` variable.

            //7. If the user chooses to log in (`choice == 1`), they're prompted to enter their username and password. These are then passed to the `Login` method of the `Bank` class, which presumably checks the credentials and returns the ID of the logged user. If the username and password are incorrect, the `Login` method likely returns -1.

            //8. If a user successfully logs in, a welcome message is displayed.If not, an error message is shown.

            //9. If the user chooses to exit(`choice == 2`), the `break` statement exits the `while (true)` loop, effectively ending the application.

            //10. If a user is logged in (`loggedInUserId != -1`), the application displays four options: 1) Check balance, 2) Deposit, 3) Withdraw, and 4) Logout.

            //11. Depending on the user's choice, different actions are performed:

            //    - `Check balance` - The user's balance is displayed by calling `GetCustomerBalance` with the logged in user's ID.

            //    - `Deposit` - The user is prompted to enter the amount to deposit.This amount is then passed to the `Deposit` method of the `Bank` class along with the logged in user's ID. After the deposit, the new balance is displayed.

            //    - `Withdraw` - The user is prompted to enter the amount to withdraw.This amount is passed to the `Withdraw` method of the `Bank` class along with the logged in user's ID. The amount actually withdrawn is then displayed, as well as the new balance.

            //    - `Logout` - The user is logged out by setting `loggedInUserId` to -1, and the bank balance after logout is displayed.

            //Note: This explanation assumes the `Bank` class and its methods(`Login`, `GetCustomerName`, `GetCustomerBalance`, `Deposit`, `Withdraw`) are implemented correctly.These methods are not visible in the provided code, so their exact behavior is inferred based on their names and usage.


            // BEHAVIORS NOT IMPLEMENTED AND WHY: 


            // Feature: Money transfer between users
            // Reason: Not implemented due to time constraints and lower priority compared to other features.

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
