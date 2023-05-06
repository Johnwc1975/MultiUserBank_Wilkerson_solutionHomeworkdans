using System;
using System.Collections.Generic;

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
