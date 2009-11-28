using System;
using System.Collections.Generic;

namespace Domain
{
    public class CashBalanceSheet
    {
        public virtual int ClaimId { get; set; }
        public virtual IList<Transaction> Transactions { get; set; }

        public CashBalanceSheet()
        {
            Transactions = new List<Transaction>();
        }
    }

    public class Transaction
    {
        public virtual int? TransactionId { get; set; }
        public virtual DateTime TransactionDate { get; set; }
        public virtual decimal DollarAmount { get; set; }
    }

}