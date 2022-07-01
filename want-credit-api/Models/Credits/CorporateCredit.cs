using System;

namespace want_credit_api.Models.Credits
{
    public class CorporateCredit : BaseCredit
    {
        protected const int MINIMUM_VALUE = 15000;

        public CorporateCredit(double creditAmount, int numberOfParcels, DateTime dateOfFirstMaturity) : base(creditAmount, numberOfParcels, dateOfFirstMaturity)
        {            
            Validate();
        }

        public override double PercentageRate => 5;

        public override double CalculateInterestValue()
        {
            return (CreditAmount * PercentageRate) / 100;
        }

        public override double CalculateTotalAmountWithInterest()
        {
            return CreditAmount + CalculateInterestValue();
        }

        private void Validate()
        {
            if (CreditAmount < MINIMUM_VALUE)
                AddErrors($"Para o crédito de pessoa jurídica, o valor mínimo a ser liberado é de {MINIMUM_VALUE}.");
        }        
    }
}
