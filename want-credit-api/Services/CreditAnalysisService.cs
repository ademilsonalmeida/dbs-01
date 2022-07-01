using System.Threading.Tasks;
using want_credit_api.Business;
using want_credit_api.Helpers.Enums;
using want_credit_api.ViewModels;

namespace want_credit_api.Services
{
    public class CreditAnalysisService : ICreditAnalysisService
    {
        private readonly ICreditAnalysisBusiness _creditAnalysisBusiness;

        public CreditAnalysisService(ICreditAnalysisBusiness creditAnalysisBusiness)
        {
            _creditAnalysisBusiness = creditAnalysisBusiness;
        }

        public Task<ResponseEvaluationResult> AnalyzeCredit(RequestEvaluationResult requestEvaluationResult)
        {
            switch((TypeCreditEnum)requestEvaluationResult.TypeCreditEnum)
            {
                case TypeCreditEnum.DirectCredit:
                    return _creditAnalysisBusiness.CalculateDirectCreditAnalysis(requestEvaluationResult);
                case TypeCreditEnum.PayrollCredit:
                    return _creditAnalysisBusiness.CalculatePayrollCreditAnalysis(requestEvaluationResult);
                case TypeCreditEnum.CorporateCredit:
                    return _creditAnalysisBusiness.CalculateCorporateCreditAnalysis(requestEvaluationResult);
                case TypeCreditEnum.IndividualCredit:
                    return _creditAnalysisBusiness.CalculateIndividualCreditAnalysis(requestEvaluationResult);
                case TypeCreditEnum.RealEstateCredit:
                    return _creditAnalysisBusiness.CalculateRealEstateCreditAnalysis(requestEvaluationResult);
                default:
                    return null;                    
            }
        }        
    }
}
