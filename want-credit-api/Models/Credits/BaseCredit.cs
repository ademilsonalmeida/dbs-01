using System;
using System.Collections.Generic;

namespace want_credit_api.Models.Credits
{
    public abstract class BaseCredit
    {
        protected const int MAXIMUM_VALUE = 1000000;
        protected const int MINIMUM_NUMBER_OF_DAYS_FROM_THE_FIRST_MATURITY = 15;
        protected const int MAXIMUM_NUMBER_OF_DAYS_FROM_THE_FIRST_MATURITY = 40;
        protected const int MINIMUM_AMOUNT_OF_PARCELS = 5;
        protected const int MAXIMUM_QUANTITY_OF_PARCELS = 72;

        public abstract double PercentageRate { get; }        
        
        public double CreditAmount { get; private set; }
        public int NumberOfParcels { get; private set; }
        public DateTime DateOfFirstMaturity { get; private set; }        

        public IList<string> Errors { get; private set; }
        public bool HasErrors { get => Errors?.Count > 0; }

        public BaseCredit(double creditAmount, int numberOfParcels, DateTime dateOfFirstMaturity)
        {
            Errors = new List<string>();

            CreditAmount = creditAmount;
            NumberOfParcels = numberOfParcels;
            DateOfFirstMaturity = dateOfFirstMaturity;

            Validate();
        }

        public abstract double CalculateTotalAmountWithInterest();

        public abstract double CalculateInterestValue();        

        protected void AddErrors(string error)
        {
            Errors.Add(error);
        }        

        private void Validate()
        {
            if (NumberOfParcels < MINIMUM_AMOUNT_OF_PARCELS)
                AddErrors($"A quantidade mínima de parcelas é de {MINIMUM_AMOUNT_OF_PARCELS}x.");

            if (NumberOfParcels > MAXIMUM_QUANTITY_OF_PARCELS)
                AddErrors($"A quantidade máxima de parcelas é de {MAXIMUM_QUANTITY_OF_PARCELS}x.");

            if (CreditAmount > MAXIMUM_VALUE)
                AddErrors($"O valor máximo a ser liberado para qualquer tipo de empréstimo é de {MAXIMUM_VALUE}.");

            if (DateOfFirstMaturity < DateTime.Now.AddDays(MINIMUM_NUMBER_OF_DAYS_FROM_THE_FIRST_MATURITY))
                AddErrors($"A data do primeiro vencimento sempre será no mínimo {MINIMUM_NUMBER_OF_DAYS_FROM_THE_FIRST_MATURITY} dias.");

            if (DateOfFirstMaturity > DateTime.Now.AddDays(MAXIMUM_NUMBER_OF_DAYS_FROM_THE_FIRST_MATURITY))
                AddErrors($"A data do primeiro vencimento sempre será no máximo {MAXIMUM_NUMBER_OF_DAYS_FROM_THE_FIRST_MATURITY} dias.");
        }
    }
}
