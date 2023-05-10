using MultiUserBank_WilkersonV1;
using static System.Net.Mime.MediaTypeNames;

namespace MultiUserBank_WilkersonV1
{
    public class Customer
    {
        public string Username { get; }
        public string Password { get; }
        public decimal Balance { get; private set; }

        public Customer(string username, string password, decimal initialBalance)
        {
            Username = username;
            Password = password;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public decimal Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                amount = Balance;
            }

            if (amount > 500)
            {
                amount = 500;
            }
            Balance -= amount;
            return amount;
        }
    }
}


  

//my notes and explaintions


//This code defines a `Customer` class for the bank application.This class represents a customer of the bank, who has a username, password, and a balance. Here's a step-by-step explanation:

//1. `public string Username { get; }` and `public string Password { get; }` -These are properties that store the customer's username and password. They are read-only outside of the class, meaning that they can only be set from within the `Customer` class and not modified afterwards.

//2. `public decimal Balance { get; private set; }` -This is the property that stores the customer's balance. It can be accessed (read) from outside the class, but it can only be modified (set) from within the `Customer` class.

//3. `public Customer(string username, string password, decimal initialBalance)` -This is the constructor of the `Customer` class. It's called when a new instance of `Customer` is created. It takes three parameters: the username, password, and initial balance of the customer, and assigns them to the corresponding properties.

//4. `public void Deposit(decimal amount)` -This is a method that allows the customer to deposit a certain amount of money into their account. The amount to deposit is passed as a parameter, and it's added to the customer's balance.

//5. `public decimal Withdraw(decimal amount)` -This is a method that allows the customer to withdraw a certain amount of money from their account. The amount to withdraw is passed as a parameter. Two checks are made before the withdrawal:

//   -If the amount to withdraw is greater than the customer's balance, the amount to withdraw is set to the customer's balance. This means the customer can't withdraw more money than they have in their account.
   
//   - If the amount to withdraw is more than 500, the amount to withdraw is set to 500. This sets a maximum limit on the withdrawal amount.
   
//   The chosen amount is then subtracted from the customer's balance and returned by the method. This means the method will tell the caller how much money was actually withdrawn.
   
//So, this `Customer` class represents a customer at the bank with the ability to deposit money into their account and withdraw money from their account with certain restrictions.