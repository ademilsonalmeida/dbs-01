using System;

namespace want_credit_api.ViewModels
{
    public class RequestEvaluationResult
    {
        /// <summary>
        /// Valor do crédito
        /// </summary>                
        public double CreditAmount { get; set; }

        /// <summary>
        /// Tipo de crédito
        /// [0 = Crédito Direto | 1 = Crédito Consignado | 2 = Crédito Pessoa Jurídica | 3 = Crédito Pessoa Física | 4 = Crédito Imobiliário]
        /// </summary>        
        public int TypeCreditEnum { get; set; }

        /// <summary>
        /// Quantidade de parcelas
        /// </summary>                
        public int NumberInstallments { get; set; }

        /// <summary>
        /// Data do primeiro vencimento
        /// </summary>                
        public DateTime DateFirstExpiration { get; set; }
    }
}
