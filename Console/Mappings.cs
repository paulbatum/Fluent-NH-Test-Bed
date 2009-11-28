using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using FluentNHibernate.Mapping;

namespace Console
{
    public class CashBalanceSheet_Map : ClassMap<CashBalanceSheet>
    {
        public CashBalanceSheet_Map()
        {
            Table("Claim");
            Id(x => x.ClaimId).GeneratedBy.Native();
            HasMany(x => x.Transactions).KeyColumn("ClaimId")
                .Cascade.AllDeleteOrphan().Not.LazyLoad();
        }
    }

    public class Transaction_Map : ClassMap<Transaction>
    {
        public Transaction_Map()
        {
            Id(x => x.TransactionId).GeneratedBy.Native();
            Map(x => x.DollarAmount);
            Map(x => x.TransactionDate).Not.Nullable();
        }
    }
}
