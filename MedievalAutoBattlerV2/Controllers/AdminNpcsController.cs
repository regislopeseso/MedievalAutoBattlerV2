using MedievalAutoBattlerV2.Models.Dtos.Request;
using MedievalAutoBattlerV2.Models.Dtos.Response;
using MedievalAutoBattlerV2.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedievalAutoBattlerV2.Controllers
{
    [ApiController]
    [Route("admin/npcs/[action]")]
    public class AdminNpcsController : ControllerBase
    {
        private readonly AdminNpcsService _adminNpcsService;

        public AdminNpcsController(AdminNpcsService adminNpcsService)
        {
            this._adminNpcsService = adminNpcsService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminNpcsCreateRequest npc)
        {
            var message = await _adminNpcsService.Create(npc);

            var result = new Response<string>
            {
                Message = message,
            };

            return new JsonResult(result);
        }
    }
}
