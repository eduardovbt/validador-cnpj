using Microsoft.AspNetCore.Mvc;
using Nstech.Mdm.Abstract.Services;
using Nstech.Mdm.Domain.Broker.Consumers.Message;
using Nstech.Mdm.Domain.Broker.Producer;
using Nstech.Mdm.Domain.Broker.Producer.Message;
using Nstech.Mdm.Domain.Entities;

namespace Nstech.Mdm.Api.Controllers
{
    /// <summary>
    /// Controller para facilitar nos teste da aplicação!
    /// </summary>
    [Route("api/")]
    public class CnpjIntegrationController : Controller
    {
        private readonly IProducerBase _producerBase;

        public CnpjIntegrationController(IProducerBase producerBase)
        {
            _producerBase = producerBase;
        }
        /// <summary>
        /// Metodo para facilitar nos testes da aplicação, ele vai postar uma mensagem no topic de integração/validação de cnpj
        /// </summary>
        /// <returns></returns>
        [HttpPost("publish/message")]
        public async Task<ActionResult> PostAsync([FromBody] CnpjIntegrationMessage message)
        {
            await _producerBase.ProduceAsync(message);
            return Ok("Mensagem publicada para teste!");
        }
    }
}
