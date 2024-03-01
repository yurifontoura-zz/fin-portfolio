using CreditSuisse.FinPort.Application.Interface.Applications;
using CreditSuisse.FinPort.Application.Interface.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CreditSuisse.FinPort.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FinantialInstrumentController(IFinInstrumentApp app) : Controller
    {
        private readonly IFinInstrumentApp _app = app;

        [HttpPost(Name = "Categorize")]
        public async Task<JsonResult> Categorize(FinantialInstrumentDTO[] finantialInstrument)
        {
            Envelope<string[]> envelope = await _app.Categorize(finantialInstrument);

            return Json(envelope);
        }
    }
}
