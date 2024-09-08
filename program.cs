using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Account
{
    public class BankAccount
    {
        private int id;
        private string ownerName;
        private double balance;

        public int ID 
        {
            get {  return id; }
          set
          {
                if (id == 0 || id < 0)
                {
                    throw new ArithmeticException("ID must be Positive and Greater than 0");
                }
                else
                {
                    id = value;
                }
          }
        }
        public string OwnerName 
        {
            get { return ownerName; } 
            set
            {
                if (ownerName == value)
                {
                    ownerName = value;
                }
                else
                {
                    throw new NullReferenceException("Name cannot be Empty or Null");
                }
            } 
        }
        public double Balance
        {
            get { return balance; }
            set
            {
                if (balance == 0 || balance < 0)
                {
                    throw new ArithmeticException("Balance is not sufficient to make this transaction");
                }
                else
                {
                    balance = value;
                }

            }

        }
        public BankAccount(int id, string ownerName, double initialBalance) 
        {
            this.id = id;
            this.ownerName = ownerName;
            if (initialBalance < 0)
            {
                throw new ArithmeticException("Initial Balance must be greater than 0");
            }else
            {
                initialBalance = 0;
            }
        }
        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new ArithmeticException("\n!!! Amount must be greater than 0 !!!");
            }
            else
            {
                balance += amount;
                Console.WriteLine($"${amount} has been successfully deposited into your account. \nYour current balance is now ${balance}.\n");
            }
        }
        public void Withdraw(double amount)
        { 
            if (amount < 0 || amount > balance)
            {
                throw new ArithmeticException("\n!!! Amount must be greater than 0 and less than your current balance !!!");
            }
            else
            {
                balance -= amount;
                Console.WriteLine($"${amount} has been withdrawn from your account. \nYour current balance is now ${balance}.\n");
            }
        }
        public void TranferFunds(BankAccount recipient, double amount)
        {
            bool validInput = false;

            while (!validInput)
            {
                try
                {
                    Console.WriteLine("How much would you like to transfer?");
                    amount = (Convert.ToDouble(Console.ReadLine()));
                    if (amount <= 0)
                    {
                        Console.WriteLine("*** Enter an amount greater than 0 ***\n");
                    }
                    else if (amount > balance)
                    {
                        Console.WriteLine("*** Amount is greater than available balance ***\n");
                    }
                    else
                    {
                        Console.WriteLine($"\n${amount} has been tranfered to {recipient.ownerName}\n");
                        validInput = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("*** Please enter a valid number. ***\n");
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
                if (recipient != null)
                {
                    Withdraw(amount);
                    recipient.Deposit(amount);
                }
                else
                {
                    throw new Exception("Recipient can not be empty");
                }
            
        }
        public string DisplayAccountInfo()
        {
            return $"\nYour account info:\n ID: {id}\n Account Holder's Name: {ownerName}\n Current Balance: ${balance}. \n\n";
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount1 = new BankAccount(0001, "John Doe", 0.00);

            Console.WriteLine(bankAccount1.DisplayAccountInfo());
            bankAccount1.Deposit(10000.87);
            Console.WriteLine(bankAccount1.DisplayAccountInfo());
            bankAccount1.Withdraw(743.55);
            Console.WriteLine(bankAccount1.DisplayAccountInfo());
            BankAccount bankAccount2 = new BankAccount(0002, "Jane Smith", 0.00);
            bankAccount2.Deposit(400.85);
            Console.WriteLine(bankAccount2.DisplayAccountInfo());
            bankAccount1.TranferFunds(bankAccount2, 285.36);
            Console.WriteLine(bankAccount1.DisplayAccountInfo());
            Console.WriteLine(bankAccount2.DisplayAccountInfo());

        }
    }
}
