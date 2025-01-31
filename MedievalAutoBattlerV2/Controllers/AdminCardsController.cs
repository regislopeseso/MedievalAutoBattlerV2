using MedievalAutoBattlerV2.Models.Dtos.Request;
using MedievalAutoBattlerV2.Models.Dtos.Response;
using MedievalAutoBattlerV2.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedievalAutoBattlerV2.Controllers
{
    [ApiController]
    [Route("admin/cards/[action]")]
    public class AdminCardsController : ControllerBase
    {
        private readonly AdminCardsService _adminCardsService;
        public AdminCardsController(AdminCardsService adminCardsService)
        {
            this._adminCardsService = adminCardsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminCardsCreateRequest card)
        {
            var message = await _adminCardsService.Create(card);

            var result = new Response<AdminCardsCreateResponse>
            {
                Message = message
            };

            return new JsonResult(result);
        }
    }
}
