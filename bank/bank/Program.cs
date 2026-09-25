namespace bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount("Dima", 1337);
            BankAccount account2 = new BankAccount("Danil", 147);

            Console.WriteLine($"{account1.Owner} {account1.Balance} {account1.Number}");
            Console.WriteLine($"{account2.Owner} {account2.Balance} {account2.Number}");

            account1.MakeDeposite(12000, DateTime.UtcNow, ";)");
            Console.WriteLine($"Balance: {account1.Balance}");

            account1.MakeWithdrawal(10000, DateTime.UtcNow, ";)");
            Console.WriteLine($"Balance: {account1.Balance}");

            try
            {
                account2.MakeWithdrawal(1000, DateTime.UtcNow, "T_T");
                Console.WriteLine(account2.Balance);
            }
            catch(InvalidOperationException e)
            { 
                Console.WriteLine(e.Message); 
            }


        }
    }
}
