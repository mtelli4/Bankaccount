using System.Runtime.CompilerServices;
using Classes;

var account = new BankAccount("Telli", 1000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
Console.WriteLine(account.Balance);
account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
Console.WriteLine(account.Balance);

Console.WriteLine(account.GetAccountHistory());

// Test for amount of withdrawal higher than balance
try{
  account.MakeWithdrawal(1000, DateTime.Now, "Invalid Withdrawal");
}
catch(InvalidOperationException e){
  Console.WriteLine("Withdrawal can't be higher than balance");
  Console.WriteLine(e.ToString());
  return;
}

// Test for negative withdrawal amount
try{
  account.MakeWithdrawal(-500, DateTime.Now, "Invalid Withdrawal");
}
catch (ArgumentOutOfRangeException e) {
  Console.WriteLine("Withdrawal amount must be positive");
  Console.WriteLine(e.ToString());
  return;
}


// Test for negative deposit amount
try{
  account.MakeDeposit(-51, DateTime.Now, "Invalid deposit");
}
catch(ArgumentOutOfRangeException e)
{
  Console.WriteLine("Deposit amount must be positive");
  Console.WriteLine(e.ToString());
  return;
}

// Test for negative initial balance when creating an account
BankAccount invalidAccount;
try {
  invalidAccount = new BankAccount("invalid", -500);
}
catch (ArgumentOutOfRangeException e) {
  Console.WriteLine("Exception caught creating account with negative initial balance");
  Console.WriteLine(e.ToString());
  return;
}

