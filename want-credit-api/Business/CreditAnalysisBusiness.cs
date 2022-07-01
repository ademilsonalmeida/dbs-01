using System.Threading.Tasks;
using want_credit_api.Helpers.Enums;
using want_credit_api.Models.Credits;
using want_credit_api.ViewModels;

namespace want_credit_api.Business
{
    public class CreditAnalysisBusiness : ICreditAnalysisBusiness
    {
        public async Task<ResponseEvaluationResult> CalculateDirectCreditAnalysis(RequestEvaluationResult requestEvaluationResult)
        {
            DirectCredit directCredit = new DirectCredit(requestEvaluationResult.CreditAmount, requestEvaluationResult.NumberInstallments, requestEvaluationResult.DateFirstExpiration);
            double totalAmountWithInterest = directCredit.CalculateTotalAmountWithInterest();
            double interestValue = directCredit.CalculateInterestValue();            

            ResponseEvaluationResult responseEvaluationResult = new ResponseEvaluationResult()
            {
                CreditStatus = directCredit.HasErrors ? (int)CreditStatusEnum.Declined : (int)CreditStatusEnum.Approved,
                TotalAmountWithInterest = totalAmountWithInterest,
                InterestValue = interestValue,
                Errors = directCredit.Errors
            };

            return await Task.FromResult(responseEvaluationResult);
        }

        public async Task<ResponseEvaluationResult> CalculatePayrollCreditAnalysis(RequestEvaluationResult requestEvaluationResult)
        {
            PayrollCredit payrollCredit = new PayrollCredit(requestEvaluationResult.CreditAmount, requestEvaluationResult.NumberInstallments, requestEvaluationResult.DateFirstExpiration);
            double totalAmountWithInterest = payrollCredit.CalculateTotalAmountWithInterest();
            double interestValue = payrollCredit.CalculateInterestValue();

            ResponseEvaluationResult responseEvaluationResult = new ResponseEvaluationResult()
            {
                CreditStatus = payrollCredit.HasErrors ? (int)CreditStatusEnum.Declined : (int)CreditStatusEnum.Approved,
                TotalAmountWithInterest = totalAmountWithInterest,
                InterestValue = interestValue,
                Errors = payrollCredit.Errors
            };

            return await Task.FromResult(responseEvaluationResult);
        }

        public async Task<ResponseEvaluationResult> CalculateCorporateCreditAnalysis(RequestEvaluationResult requestEvaluationResult)
        {
            CorporateCredit corporateCredit = new CorporateCredit(requestEvaluationResult.CreditAmount, requestEvaluationResult.NumberInstallments, requestEvaluationResult.DateFirstExpiration);
            double totalAmountWithInterest = corporateCredit.CalculateTotalAmountWithInterest();
            double interestValue = corporateCredit.CalculateInterestValue();

            ResponseEvaluationResult responseEvaluationResult = new ResponseEvaluationResult()
            {
                CreditStatus = corporateCredit.HasErrors ? (int)CreditStatusEnum.Declined : (int)CreditStatusEnum.Approved,
                TotalAmountWithInterest = totalAmountWithInterest,
                InterestValue = interestValue,
                Errors = corporateCredit.Errors
            };

            return await Task.FromResult(responseEvaluationResult);
        }

        public async Task<ResponseEvaluationResult> CalculateIndividualCreditAnalysis(RequestEvaluationResult requestEvaluationResult)
        {
            IndividualCredit individualCredit = new IndividualCredit(requestEvaluationResult.CreditAmount, requestEvaluationResult.NumberInstallments, requestEvaluationResult.DateFirstExpiration);
            double totalAmountWithInterest = individualCredit.CalculateTotalAmountWithInterest();
            double interestValue = individualCredit.CalculateInterestValue();

            ResponseEvaluationResult responseEvaluationResult = new ResponseEvaluationResult()
            {
                CreditStatus = individualCredit.HasErrors ? (int)CreditStatusEnum.Declined : (int)CreditStatusEnum.Approved,
                TotalAmountWithInterest = totalAmountWithInterest,
                InterestValue = interestValue,
                Errors = individualCredit.Errors
            };

            return await Task.FromResult(responseEvaluationResult);
        }

        public async Task<ResponseEvaluationResult> CalculateRealEstateCreditAnalysis(RequestEvaluationResult requestEvaluationResult)
        {
            RealEstateCredit realEstateCredit = new RealEstateCredit(requestEvaluationResult.CreditAmount, requestEvaluationResult.NumberInstallments, requestEvaluationResult.DateFirstExpiration);
            double totalAmountWithInterest = realEstateCredit.CalculateTotalAmountWithInterest();
            double interestValue = realEstateCredit.CalculateInterestValue();

            ResponseEvaluationResult responseEvaluationResult = new ResponseEvaluationResult()
            {
                CreditStatus = realEstateCredit.HasErrors ? (int)CreditStatusEnum.Declined : (int)CreditStatusEnum.Approved,
                TotalAmountWithInterest = totalAmountWithInterest,
                InterestValue = interestValue,
                Errors = realEstateCredit.Errors
            };

            return await Task.FromResult(responseEvaluationResult);
        }
    }
}
