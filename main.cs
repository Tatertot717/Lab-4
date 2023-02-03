using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World");
        //Account a = new Account();
        Checking c = new Checking();
      Savings s = new Savings();
        
        while (true)
        {
            Console.WriteLine("1. Withdraw from Checking\n2. Withdraw from Savings\n3. Deposit to Checking\n4. Deposit to Savings\n5. Balance of Checking\n6. Balance of Savings\n7. Award Interest to Savings now\n8. Quit");
            int choice = Convert.ToInt16(Console.ReadLine());
            switch (choice)
            {
                default:
                    System.Environment.Exit(0);
                    break;

                case 1:
                    Console.WriteLine("How much would you like to withdrawl from Checking?");
                    c.withdrawl(Convert.ToDouble(Console.ReadLine()));
              Console.WriteLine("Balance is now "+c.getBalance());
                    break;

                case 2:
                    Console.WriteLine("How much would you like to withdrawl from Savings?");
                    s.withdrawl(Convert.ToDouble(Console.ReadLine()));
              Console.WriteLine("Balance is now "+s.getBalance());
                    break;

                case 3:
                    Console.WriteLine("How much would you like to deposit into Checking?");
                    c.deposit(Convert.ToDouble(Console.ReadLine()));
              Console.WriteLine("Doing default deposit, balance is now "+c.getBalance());
              break;

                case 4:
                    Console.WriteLine("How much would you like to deposit into Savings?");
                    s.deposit(Convert.ToDouble(Console.ReadLine()));
              Console.WriteLine("Doing savings deposit, balance is now "+s.getBalance());
                    break;

                case 5:
                    Console.WriteLine("Your balance for checking "+c.getBalance()+" is "+c.getBalance());
                    break;

                case 6:
                    Console.WriteLine("Your balance for Savings "+s.getBalance()+" is "+s.getBalance());
                    break;

                case 7:
                    s.addInterest();
              Console.WriteLine("Savings instrest added, balance is now "+s.getBalance());
                    break;
  

            }
          Console.WriteLine();
        }
    }
}

class Account
{
    private static int accounts = 10001;
    private int accountid;
    private double balance;

    public double getBalance(){
      return(balance);
    }
  public double getID(){
      return(accountid);
    }
  public void setBalance(double b){
    balance = b;
  }
  
  public Account()
    {
        accountid = accounts++;
        balance = 0;
    }

    public Account(double initalBal)
    {
        accountid = accounts++;
        balance = initalBal;


    }

    public virtual void deposit(double add)
    {
        balance = balance + add;
    }

    public virtual void withdrawl(double remove)
    {
        balance = balance - remove;
    }
}

class Checking : Account
{
    public Checking(double initalBal)
    {
        setBalance(initalBal);
    }

    public Checking()
    {
        setBalance(0);
    }

    public override void withdrawl(double remove)
    {
        setBalance(getBalance()-remove);
        if (getBalance() < 0)
        {
            Console.WriteLine("Charging an overdraft fee of $20 because account is below $0");
            setBalance(getBalance()-20);
        }
    }
}

class Savings : Account
{
    int amtDeposits = 0;
    public Savings(double initalBal)
    {
        setBalance(initalBal);
    }

    public Savings()
    {
        setBalance(0);
    }

    public override void deposit(double add)
    {
        setBalance(getBalance()+add);
        amtDeposits++;
        Console.WriteLine("This is deposit " + amtDeposits + " to this account");
        if (amtDeposits > 5)
        {
            Console.WriteLine("Charging a fee of $10, deposits over 6");
            setBalance(getBalance()-10);
        }
    }


    public override void withdrawl(double remove)
    {
        setBalance(getBalance()-remove);
        if (getBalance() < 500)
        {
            Console.WriteLine("Charging a fee of $10 because account is below $500");
            setBalance(getBalance()-10);
        }
    }
    public void addInterest()
    {
        Console.WriteLine("Customer earned " + getBalance() * 0.015 + " in interest");
        setBalance(getBalance()*1.015);
    }
}