using MedievalAutoBattlerV2.Models.Dtos.Request;
using MedievalAutoBattlerV2.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedievalAutoBattlerV2.Controllers
{
    [ApiController]
    [Route("[controller/[action]")]
    public class AdminCardsController : ControllerBase
    {
        private readonly AdminCardsService _adminCardsService;
        public AdminCardsController(AdminCardsService adminCardsService)
        {
            this._adminCardsService = adminCardsService;
        }     
    }
}
