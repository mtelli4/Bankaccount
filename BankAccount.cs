using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace Classes;

public class BankAccount
{
  private static int s_accountNumberSeed = 1234567890;
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance { 
      get{
        decimal balance = 0;
        foreach(var items in _allTransactions)
        {
          balance += items.Amount;
        }
        return balance;
      } 
    }

    public BankAccount(string name, decimal initialBalance)
    {
      this.Number = s_accountNumberSeed.ToString();
      this.Owner = name;
      MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
      s_accountNumberSeed++;
    }
    private List<Transaction> _allTransactions = new List<Transaction>();
    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
      if(amount <= 0)
      {
        throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
      }
      var deposit = new Transaction(amount, date, note);
      _allTransactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
      if (amount <= 0)
      {
        throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
      }
      if (Balance - amount < 0)
      {
        throw new InvalidOperationException("Not sufficient fund for this withdrawal");
      }
      var withdrawal = new Transaction(-amount, date, note);
      _allTransactions.Add(withdrawal);
    }

    public string GetAccountHistory(){
      var report = new System.Text.StringBuilder();
      
      decimal balance = 0;
      report.AppendLine("Date\t\tAmount\tBalance\tNote");
      foreach(var item in _allTransactions){
        balance += item.Amount;
        report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
      }
      return report.ToString();
    }

    public virtual void PerformMonthEndTransactions()
    {

    }
}
