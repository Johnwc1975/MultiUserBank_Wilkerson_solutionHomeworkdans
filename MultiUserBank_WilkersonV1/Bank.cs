using Microsoft.VisualBasic;
using MultiUserBank_WilkersonV1;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace MultiUserBank_WilkersonV1
{
    public class Bank
    {
        private const decimal InitialBankBalance = 10000m;
        private decimal _bankBalance;
        private List<Customer> _customers;

        public Bank()
        {
            _bankBalance = InitialBankBalance;
            InitializeCustomers();
        }

        public decimal BankBalance => _bankBalance;

        private void InitializeCustomers()
        {
            _customers = new List<Customer>
            {
                new Customer("jlennon", "johnny", 1250m),
                new Customer("pmccartney", "pauly", 2500m),
                new Customer("gharrison", "georgy", 3000m),
                new Customer("rstarr", "ringoy", 1000m)
            };
        }

        public int Login(string username, string password)
        {
            for (int i = 0; i < _customers.Count; i++)
            {
                if (_customers[i].Username == username && _customers[i].Password == password)
                {
                    return i;
                }
            }
            return -1;
        }

        public string GetCustomerName(int customerId)
        {
            return _customers[customerId].Username;
        }

        public decimal GetCustomerBalance(int customerId)
        {
            return _customers[customerId].Balance;
        }

        public void Deposit(int customerId, decimal amount)
        {
            _customers[customerId].Deposit(amount);
            _bankBalance += amount;
        }

        public decimal Withdraw(int customerId, decimal amount)
        {
            decimal withdrawnAmount = _customers[customerId].Withdraw(amount);
            _bankBalance -= withdrawnAmount;
            return withdrawnAmount;
        }
    }
}



//My notes and explaintion

//This code is a class called `Bank` for the bank application, which keeps track of the bank's balance and manages the bank's customers. It allows customers to log in, deposit, withdraw, and retrieve the username and balance of a customer. Here's a step-by-step explanation:

//1. `private const decimal InitialBankBalance = 10000m;` -This is a private constant value that represents the initial balance of the bank, which is 10,000 in decimal format.

//2. `private decimal _bankBalance; private List<Customer> _customers;` -These are private fields for the bank's balance and a list of customers.

//3. `public Bank()` -This is the constructor of the `Bank` class. When a new instance of `Bank` is created, the bank's balance is set to the initial bank balance, and the `InitializeCustomers` method is called to create some customers.

//4. `public decimal BankBalance => _bankBalance;` -This is a read - only property that allows the bank's balance to be accessed from outside the class.

//5. `private void InitializeCustomers()` -This is a private method that initializes the `_customers` list with some `Customer` objects. Each `Customer` is created with a username, password, and initial balance.

//6. `public int Login(string username, string password)` -This is a method that allows a customer to log in. It checks each customer in the `_customers` list, and if the username and password match, it returns the index of the customer in the list (which acts as the customer's ID). If no match is found, it returns -1.

//7. `public string GetCustomerName(int customerId)` -This method returns the username of the customer with the given ID.

//8. `public decimal GetCustomerBalance(int customerId)` -This method returns the balance of the customer with the given ID.

//9. `public void Deposit(int customerId, decimal amount)` -This method allows a customer to deposit an amount of money. It adds the amount to both the customer's balance and the bank's balance.

//10. `public decimal Withdraw(int customerId, decimal amount)` -This method allows a customer to withdraw an amount of money. It subtracts the withdrawn amount from both the customer's balance and the bank's balance, and returns the amount that was actually withdrawn (as per the withdrawal rules in the `Customer` class).

//So, this `Bank` class manages a list of customers, keeps track of the bank's balance, and handles customer logins, deposits, and withdrawals.