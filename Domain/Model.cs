using System;
using System.Collections.Generic;

namespace Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }
    }

    public abstract class Debt : Entity
    {        
        public decimal Balance { get; set; }
    }

    public class CarLoan : Debt
    {
        
    }

    public class CreditCard : Debt
    {
        
    }

    public class LoanApplication : Entity
    {
        public IList<Debt> ExistingDebts { get; set; }

        public LoanApplication()
        {
            ExistingDebts = new List<Debt>();
        }
    }


}