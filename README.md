# # Bank Account Management System

## Overview
This is a simple console-based C# project that simulates basic bank account operations. The project demonstrates fundamental object-oriented programming concepts such as encapsulation, exception handling, and method interaction between different `BankAccount` instances.

## Features
- Create a bank account with an ID, owner name, and balance.
- Deposit money into a bank account.
- Withdraw money from a bank account with validation to ensure sufficient balance.
- Transfer funds between two different bank accounts.
- Display account details including ID, owner's name, and balance.

## How It Works
1. **Create Accounts**: The program allows creating bank accounts with initial details such as ID, account holder name, and balance.
2. **Deposit and Withdraw**: Users can deposit and withdraw money while ensuring that withdrawals don’t exceed the available balance.
3. **Transfer Funds**: You can transfer money between two accounts, with the program performing validation checks to ensure the amount is valid and within the balance limit.
4. **Error Handling**: The system handles various errors such as invalid input, insufficient balance, and invalid operations.

## Code Explanation
The project is built around a `BankAccount` class with the following key methods:
- `Deposit()`: Adds money to the account balance.
- `Withdraw()`: Removes money from the account balance.
- `TransferFunds()`: Transfers money from one account to another.
- `DisplayAccountInfo()`: Displays the account’s ID, owner, and current balance.

## Example
```csharp
// Creating two bank accounts
BankAccount bankAccount1 = new BankAccount(0001, "John Doe", 0.00);
BankAccount bankAccount2 = new BankAccount(0002, "Jane Smith", 0.00);

// Depositing and transferring funds
bankAccount1.Deposit(10000.87);
bankAccount1.Withdraw(743.55);
bankAccount1.TranferFunds(bankAccount2, 285.36);

// Displaying account information
Console.WriteLine(bankAccount1.DisplayAccountInfo());
Console.WriteLine(bankAccount2.DisplayAccountInfo());
