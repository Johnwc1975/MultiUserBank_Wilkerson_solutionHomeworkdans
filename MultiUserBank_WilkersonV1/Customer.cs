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
