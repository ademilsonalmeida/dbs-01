using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using want_credit_api.Services;
using want_credit_api.ViewModels;

namespace want_credit_api.Controllers.V1
{
    public class CreditAnalysisController : ControllerBase
    {
        private readonly ILogger<CreditAnalysisController> _logger;
        private readonly ICreditAnalysisService _creditAnalysisService;

        public CreditAnalysisController(ILogger<CreditAnalysisController> logger, ICreditAnalysisService creditAnalysisService)
        {
            _logger = logger;
            _creditAnalysisService = creditAnalysisService;
        }

        /// <summary>
        /// Realiza uma análise de crédito de acordo com o tipo informado
        /// </summary>
        /// <remarks>Maravilha!</remarks>
        /// <response code="200">Crédito analisado com sucesso</response>
        /// <response code="400">Não foi possivel analisar seu crédito, verifique as mensagens de erros</response>
        /// <response code="500">Ops! Não é possível analisar seu crédito agora</response>
        [Route("v1/analise-credito")]
        [HttpPost]
        [ProducesResponseType(typeof(ResponseEvaluationResult), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] RequestEvaluationResult requestEvaluationResult)
        {
            try
            {
                ResponseEvaluationResult responseEvaluationResult = await _creditAnalysisService.AnalyzeCredit(requestEvaluationResult);

                if (responseEvaluationResult.Errors?.Count > 0)
                    return BadRequest(responseEvaluationResult);

                return StatusCode(200, responseEvaluationResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest("Não foi possível concluir a operação, tente novamente.");
            }
        }
    }
}
