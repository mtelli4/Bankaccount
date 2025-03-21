namespace Classes;

public class LineOfCreditAccount : BankAccount
{
  public LineOfCreditAccount(string name, decimal initialBalance) : base(name, initialBalance)
  {
    
  }
    public override void PerformMonthEndTransactions()
    {
      decimal interest;
        if (Balance < 0)
        {
          interest = -Balance * 0.07m;
          MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
        }
    }
}
