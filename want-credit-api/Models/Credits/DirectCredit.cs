using System;

namespace want_credit_api.Models.Credits
{
    public class DirectCredit : BaseCredit
    {
        public DirectCredit(double creditAmount, int numberOfParcels, DateTime dateOfFirstMaturity) : base (creditAmount, numberOfParcels, dateOfFirstMaturity) { }

        public override double PercentageRate => 2;

        public override double CalculateInterestValue()
        {
            return (CreditAmount * PercentageRate) / 100;
        }

        public override double CalculateTotalAmountWithInterest()
        {
            return CreditAmount + CalculateInterestValue();
        }
    }
}
