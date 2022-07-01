using System.Threading.Tasks;
using want_credit_api.ViewModels;

namespace want_credit_api.Services
{
    public interface ICreditAnalysisService
    {
        Task<ResponseEvaluationResult> AnalyzeCredit(RequestEvaluationResult requestEvaluationResult);        
    }
}
