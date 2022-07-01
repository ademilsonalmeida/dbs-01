using System.Collections.Generic;

namespace want_credit_api.ViewModels
{
    public class ResponseEvaluationResult
    {
        /// <summary>
        /// Status do crédito [1 = Aprovado | 0 = recusado]
        /// </summary>        
        public int CreditStatus { get; set; }

        /// <summary>
        /// Valor total com juros (Os juros serão calculados através do incremento da porcentagem de juros no valor do crédito)
        /// </summary>        
        public double TotalAmountWithInterest { get; set; }

        /// <summary>
        /// Valor dos juros
        /// </summary>        
        public double InterestValue { get; set; }

        /// <summary>
        /// Lista com os erros referentes as validações
        /// </summary>        
        public IList<string> Errors { get; set; }

        public ResponseEvaluationResult()
        {
            Errors = new List<string>();
        }
    }
}
