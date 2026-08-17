namespace Exercise11;

// Base Class
public class BankAccount
{
    // public: Accessible anywhere
    public string AccountHolder;

    // private: Accessible ONLY within this class
    private decimal _balance;

    // protected: Accessible within this class and derived classes
    protected string AccountType;

    // internal: Accessible anywhere within this assembly
    internal string BranchCode;

    public BankAccount(string holder, decimal initialBalance, string accountType, string branch)
    {
        AccountHolder = holder;
        _balance = initialBalance;
        AccountType = accountType;
        BranchCode = branch;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            _balance += amount;
            Console.WriteLine($"Deposited ${amount}. New balance: ${_balance}");
        }
    }

    // Public method to expose private balance safely
    public decimal GetBalance() => _balance;
}

// Derived Class
public class SavingsAccount : BankAccount
{
    private decimal _interestRate;

    public SavingsAccount(string holder, decimal initialBalance, decimal interestRate, string branch)
        : base(holder, initialBalance, "High-Yield Savings", branch)
    {
        _interestRate = interestRate;
    }

    public void DisplaySavingsInfo()
    {
        // Can access 'public' AccountHolder
        Console.WriteLine($"Holder       : {AccountHolder}");
        
        // Can access 'protected' AccountType from base class
        Console.WriteLine($"Account Type : {AccountType}");

        // Can access 'internal' BranchCode within same project
        Console.WriteLine($"Branch Code  : {BranchCode}");

        // CANNOT access '_balance' directly (it is private to BankAccount)
        // Must use public method GetBalance()
        Console.WriteLine($"Balance      : ${GetBalance():F2}");
        Console.WriteLine($"Interest Rate: {_interestRate}%");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=================================================");
        Console.WriteLine("  Exercise 11: Access Modifiers Demonstration");
        Console.WriteLine("=================================================\n");

        SavingsAccount account = new("Elena Rostova", 5000.00m, 4.5m, "BRANCH-TX-101");
        
        account.DisplaySavingsInfo();
        Console.WriteLine();

        account.Deposit(1200.00m);
        Console.WriteLine($"Updated Balance via GetBalance(): ${account.GetBalance():F2}");

        Console.WriteLine("\nAccess Modifiers Rules Demonstrated:");
        Console.WriteLine(" • public    : Accessible by anyone (AccountHolder)");
        Console.WriteLine(" • private   : Encapsulated strictly in BankAccount (_balance)");
        Console.WriteLine(" • protected : Inherited and accessible by SavingsAccount (AccountType)");
        Console.WriteLine(" • internal  : Accessible across the current assembly (BranchCode)");
        Console.WriteLine("=================================================");
    }
}
