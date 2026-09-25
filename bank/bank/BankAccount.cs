namespace bank;

internal class BankAccount
{
    private List<Transaction> _alltransactions = new List<Transaction>();
    public string Owner { get; private set; }
    public string Number { get; }
    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var transaction in _alltransactions)
            {
                balance = transaction.Amount;
            }
            return balance;

        }
    }
    public static int s_accountNumberSeed = 1000000000;
    public BankAccount(string name, decimal initialBalance)
    {
        MakeDeposite(initialBalance, DateTime.UtcNow, "initial balance");///this.Balance = initialBalance;
        Owner = name;
        Number = s_accountNumberSeed.ToString();
        s_accountNumberSeed++;
    }

    public void MakeDeposite(decimal amout, DateTime data, string nota)
    {
        if (amout <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amout), "Amount must be positive");
        }
        var deposite = new Transaction(amout, data, nota);
        _alltransactions.Add(deposite);
    }
    public void MakeWithdrawal(decimal amout, DateTime data, string nota)
    {
        if (amout <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amout), "Amount must be positive");
        }
        var Withfrawal = new Transaction(-amout, data, nota);
        _alltransactions.Add(Withfrawal);





    }
}
