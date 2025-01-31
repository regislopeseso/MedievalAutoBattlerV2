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

            var result = new Response<string>()
            {
                Message = message
            };

            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Read()
        {
            var (response, message) = await _adminCardsService.Read();

            var result = new Response<List<AdminCardsReadResponse>>()
            {
                Content = response,
                Message = message
            };

            return new JsonResult(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var message = await _adminCardsService.Delete(id);

            var result = new Response<string>()
            {
                Message = message
            };

            return new JsonResult(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(AdminCardsUpdateRequest card)
        {
            var message = await _adminCardsService.Update(card);

            var result = new Response<string>()
            {
                Message = message
            };

            return new JsonResult(result);
        }
    }
}
