using System.Runtime.CompilerServices;
using Classes;

var account = new BankAccount("Telli", 1000);
Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");
account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
Console.WriteLine(account.Balance);
account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
Console.WriteLine(account.Balance);

Console.WriteLine(account.GetAccountHistory());

var giftCard = new GiftCardAccount("gift card", 100, 50);
giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
giftCard.PerformMonthEndTransactions();
giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
Console.WriteLine(giftCard.GetAccountHistory());

var savings = new InterestEarningAccount("savings account", 10000);
savings.MakeDeposit(750, DateTime.Now, "save some money");
savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
savings.PerformMonthEndTransactions();
Console.WriteLine(savings.GetAccountHistory());

var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
// How much is too much to borrow?
lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
lineOfCredit.PerformMonthEndTransactions();
Console.WriteLine(lineOfCredit.GetAccountHistory());

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

