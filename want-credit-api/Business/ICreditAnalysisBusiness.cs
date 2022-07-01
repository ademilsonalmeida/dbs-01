using System.Threading.Tasks;
using want_credit_api.ViewModels;

namespace want_credit_api.Business
{
    public interface ICreditAnalysisBusiness
    {
        Task<ResponseEvaluationResult> CalculateDirectCreditAnalysis(RequestEvaluationResult requestEvaluationResult);
        Task<ResponseEvaluationResult> CalculatePayrollCreditAnalysis(RequestEvaluationResult requestEvaluationResult);
        Task<ResponseEvaluationResult> CalculateCorporateCreditAnalysis(RequestEvaluationResult requestEvaluationResult);
        Task<ResponseEvaluationResult> CalculateIndividualCreditAnalysis(RequestEvaluationResult requestEvaluationResult);
        Task<ResponseEvaluationResult> CalculateRealEstateCreditAnalysis(RequestEvaluationResult requestEvaluationResult);
    }
}
